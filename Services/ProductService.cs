using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coolblue_assesment.Data;
using coolblue_assesment.Dtos;
using coolblue_assesment.Models;

namespace coolblue_assesment.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepo repo, IMapper mapper)
        {
            ProductRepository = repo;
            Mapper = mapper;
        }

        private IProductRepo ProductRepository { get; }
        private IMapper Mapper { get; }

        public  ProductReadDto? getProduct(int id)
        {
             Product? product =  ProductRepository.GetProductById(id);
             if(product != null){
                return Mapper.Map<ProductReadDto>(product);
             }else{
                return null;
             }
        }
    }
}