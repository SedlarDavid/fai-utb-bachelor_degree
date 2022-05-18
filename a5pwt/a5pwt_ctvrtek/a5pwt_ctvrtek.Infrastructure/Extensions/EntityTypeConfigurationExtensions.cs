using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace a5pwt_ctvrtek.Infrastructure.Extensions
{
    public static class EntityTypeConfigurationExtensions
    {
		static readonly MethodInfo entityMethod = typeof(ModelBuilder).GetMethods()
			.Single(m => m.Name == "Entity" &&
				m.IsGenericMethod &&
				m.GetParameters().Length == 0); 

		public static ModelBuilder ApplyConfiguration<T>(this ModelBuilder modelBuilder, IEntityTypeConfiguration<T> configuration)
			where T : class
		{
			var entityTypeArgs = FindEntityTypeGenericArguments(configuration.GetType());

			dynamic entityBuilder = entityMethod
				.MakeGenericMethod(entityTypeArgs)
				.Invoke(modelBuilder, null);

			configuration.Configure(entityBuilder);

			return modelBuilder;
		}

		public static ModelBuilder UseEntityTypeConfiguration(this ModelBuilder modelBuilder)
		{
			var mappingTypes = Assembly.GetCallingAssembly()
				.GetExportedTypes()
				.Where(x => x.GetTypeInfo().IsClass &&
					!x.GetTypeInfo().IsAbstract &&
					x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType &&
						y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
					);

			var configurations = mappingTypes.Select(Activator.CreateInstance);

			foreach (dynamic configuration in configurations)
			{
				ApplyConfiguration(modelBuilder, configuration);
			}

			return modelBuilder;
		}

		public static ModelBuilder UseDefaultStringMaxlength(this ModelBuilder modelBuilder, int maxLength = 4000)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes()
			.SelectMany(t => t.GetProperties())
			.Where(p => p.ClrType == typeof(string)))
			{
				property.Relational().ColumnType = $"nvarchar({maxLength})";
			}

			return modelBuilder;
		}

		static Type FindEntityTypeGenericArguments(Type type)
		{
			return type.GetInterfaces()
				.Single(x => x.GetTypeInfo().IsGenericType &&
					x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
				.GetGenericArguments()
				.Single();
		}
	}
}
