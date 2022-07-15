using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using coolblue_assesment.Data;
using coolblue_assesment.Dtos;

namespace coolblue_assesment.Services 
{
    public class ProductTypeService : IProductTypeService
    {
        public ProductTypeService(IProductRepo repo, IMapper mapper)
        {
            ProductTypeRepository = repo;
            Mapper = mapper;
        }

        private IProductRepo ProductTypeRepository { get; }
        private IMapper Mapper { get; }

        public ProductTypeReadDto? getProductType(int id)
        {
            throw new NotImplementedException();
        }
    }
}