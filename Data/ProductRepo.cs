using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace coolblue_assesment.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public  Product? GetProductById(int id)
        {
            return  _context.Products.Include(p => p.ProductType).FirstOrDefault(p => p.id == id);
        }
    }
}