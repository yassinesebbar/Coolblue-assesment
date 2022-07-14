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

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}