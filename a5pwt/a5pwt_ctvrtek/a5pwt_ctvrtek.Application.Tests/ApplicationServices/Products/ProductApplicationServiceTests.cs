using a5pwt_ctvrtek.Application.ApplicationServices.Products;
using a5pwt_ctvrtek.Application.Configuration;
using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Domain.Entities.Products;
using a5pwt_ctvrtek.Infrastructure.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace a5pwt_ctvrtek.Application.Tests.ApplicationServices.Products
{
    public class ProductApplicationServiceTests : IDisposable
    {
        private readonly IServiceScope _scope;
        private readonly IProductApplicationService _productApplicationService;
        private IServiceProvider _serviceProvider => _scope.ServiceProvider;

        public ProductApplicationServiceTests()
        {
            _scope = SetupDI().CreateScope();
            _productApplicationService = _serviceProvider.GetService<IProductApplicationService>();
        }

        [Fact]
        public void GetIndexViewModelTest()
        {
            //Arrange
            var dataContext = _serviceProvider.GetService<DataContext>();
            dataContext.Products.AddRange(
                new Product { ID = 1, Name = "Produkt 1", Price = 42 },
                new Product { ID = 2, Name = "Produkt 2", Price = 2 }
                );
            dataContext.SaveChanges();

            //Act
            var indexViewModel = _productApplicationService.GetIndexViewModel();


            //Assert
            Assert.NotNull(indexViewModel);
            Assert.True(indexViewModel.Products.Any());
        }

        [Fact]
        public void InsertTest()
        {
            //Arrange
            var image = _scope.ServiceProvider.GetService<IFormFile>();
            var productViewModel = new ProductViewModel
            {
                Name = "Produkt 8",
                Price = 10M,
                ImageURL = "http",
                Image = image,
                Category = "home",
            };

            //Act
            var product = _productApplicationService.Insert(productViewModel);

            //Assert
            Assert.NotNull(product);
            Assert.True(product.ID > 0);
            Assert.Equal(productViewModel.Name, product.Name);
            Assert.Equal(productViewModel.Price, product.Price);
            Assert.Equal(productViewModel.Category, product.Category);
        }

        private IServiceProvider SetupDI()
        {
            var services = new ServiceCollection();
            var environment = new HostingEnvironment
            {
                WebRootPath = @"C:\Users\student\Documents\A5PWT\ctvrtek\utb_eshop_ctvrtek\a5pwt_ctvrtek\a5pwt_ctvrtek.Application.Tests\images\output",
                ContentRootPath = @"C:\Users\student\Documents\A5PWT\ctvrtek\utb_eshop_ctvrtek\a5pwt_ctvrtek\a5pwt_ctvrtek.Application.Tests\images\output"
            };

            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationDependencyModule>();
            ServiceConfiguration.Load(services, environment);
            MockIFormFile(services);
            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        private void MockIFormFile(ServiceCollection services)
        {
            var fileMock = new Mock<IFormFile>();
            var fileName = "input.jpg";
            var fileInfo = new FileInfo($@"C:\Users\student\Documents\A5PWT\ctvrtek\utb_eshop_ctvrtek\a5pwt_ctvrtek\a5pwt_ctvrtek.Application.Tests\images\input\{fileName}");
            var data = new byte[fileInfo.Length];

            using (var fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.Write(data);
                    sw.Flush();
                    ms.Position = 0;
                    fileMock.Setup(x => x.OpenReadStream()).Returns(ms);
                    fileMock.Setup(x => x.FileName).Returns(fileName);
                    fileMock.Setup(x => x.Length).Returns(ms.Length);
                    fileMock.Setup(x => x.ContentType).Returns("image/jpg");
                }
            }

            services.AddSingleton(fileMock.Object);
        }

        public void Dispose() => _scope.Dispose();
    }
}
