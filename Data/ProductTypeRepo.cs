using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace coolblue_assesment.Data
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        private readonly AppDbContext _context;

        public ProductTypeRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductType?> GetProductTypeById(int id)
        {
            return await _context.ProductTypes.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}