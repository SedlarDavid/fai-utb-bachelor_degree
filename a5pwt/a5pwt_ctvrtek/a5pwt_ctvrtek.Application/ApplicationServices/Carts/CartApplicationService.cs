using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using a5pwt_ctvrtek.Application.Mappers.Carts;
using a5pwt_ctvrtek.Application.Mappers.Products;
using a5pwt_ctvrtek.Application.ViewModels.Carts;
using a5pwt_ctvrtek.Domain.Entities.Carts;
using a5pwt_ctvrtek.Domain.Entities.Products;
using a5pwt_ctvrtek.Domain.Services.Carts;
using a5pwt_ctvrtek.Domain.Services.Products;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Carts
{
    public class CartApplicationService : ICartApplicationService
    {
        private readonly ICartService _cartService;
        private readonly ICartMapper _cartMapper;
        private readonly IProductService _productService;
        private readonly IProductMapper _productMapper;

        public CartApplicationService(
            ICartService cartService,
            ICartMapper cartMapper,
            IProductService productService,
            IProductMapper productMapper)
        {
            _cartService = cartService;
            _cartMapper = cartMapper;
            _productService = productService;
            _productMapper = productMapper;
        }

        public CartItem AddToCart(int productID, int amount, string userTrackingCode)
        {
            return _cartService.AddToCart(productID, amount, userTrackingCode);
        }

        public IndexViewModel GetIndexViewModel(string userTrackingCode)
        {
            IList<CartItem> items = _cartService.GetCartItems(userTrackingCode);
            var related = GetRelatedProducts(GetMostBuyedTag(items), items);
            return new IndexViewModel
            {
                CartItems = _cartMapper.GetViewModelsFromEntities(items),
                Total = items.Sum(x => x.Product.Price * x.Amount),
                RelatedItems = _productMapper.GetViewModelsFromEntities(related),
            };
        }

        public void RemoveFromCart(int productID, string userTrackingCode)
        {
            _cartService.RemoveFromCart(productID, userTrackingCode);
        }

        private string GetMostBuyedTag(IList<CartItem> items)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (CartItem item in items)
            {
                counts[item.Product.Category] = 0;
            }

            foreach (CartItem item in items)
            {
                if (counts.ContainsKey(item.Product.Category))
                {
                    counts[item.Product.Category]++;
                }
            }
            return counts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        }

        private List<Product> GetRelatedProducts(string tag, IList<CartItem> items)
        {
            var related = _productService.GetAll().Where(product => product.Category == tag);
            List<Product> filtered = new List<Product>();

            foreach (CartItem item in items)
            {
                if (!related.Contains(item.Product) && item.Product.Category == tag)
                {
                    filtered.Add(item.Product);
                }
            }

            //TODO on setting bool
            return filtered;
        }
    }
}
