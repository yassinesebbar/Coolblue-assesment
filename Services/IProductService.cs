using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coolblue_assesment.Data;
using coolblue_assesment.Dtos;

namespace coolblue_assesment.Services
{
    public interface IProductService
    {
        public ProductReadDto? getProduct(int id);
    }
}