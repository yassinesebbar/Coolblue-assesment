using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;

namespace coolblue_assesment.Data
{
    public interface IProductRepo
    {
        Task<Product?> GetProductById(int id);
         
    }
}