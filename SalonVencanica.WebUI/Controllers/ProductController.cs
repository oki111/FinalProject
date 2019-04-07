using SalonVencanica.Domain.Abstract;
using SalonVencanica.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        public int pageSize = 4;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        } 
        
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = repo.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    //TotalItems = repo.Products.Count()

                    TotalItems = category == null ? repo.Products.Count() : repo.Products.Where(p => p.Category == category).Count()

                },

                CurrentCategory = category
            };

            return View(model);
        }
    }
}