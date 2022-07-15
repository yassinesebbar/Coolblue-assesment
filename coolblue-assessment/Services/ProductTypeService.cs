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
    public class ProductTypeService : IProductTypeService
    {
        public ProductTypeService(IProductTypeRepo repo, IMapper mapper)
        {
            ProductTypeRepository = repo;
            Mapper = mapper;
        }

        private IProductTypeRepo ProductTypeRepository { get; }
        private IMapper Mapper { get; }

        public ProductTypeReadDto? getProductType(int id)
        {
             ProductType? productType =  ProductTypeRepository.GetProductTypeById(id);
             if(productType != null){
                return Mapper.Map<ProductTypeReadDto>(productType);
             }else{
                return null;
             }
        }
    }
}