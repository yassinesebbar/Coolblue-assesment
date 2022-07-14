using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;

namespace coolblue_assesment.Data
{
    public interface IProductTypeRepo
    {
        Task<ProductType?> GetProductTypeById(int id);
    }
}