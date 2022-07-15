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
    public class InsuranceService : IInsuranceService
    {
        public InsuranceService(IProductRepo productRepo, IMapper mapper)
        {
            ProductRepo = productRepo;
            Mapper = mapper;
        }

        private IProductRepo ProductRepo { get; }
        private IMapper Mapper { get; }

        public InsuranceCostReadDto? getInsuranceCost(int id)
        {
            Product? product = ProductRepo.GetProductById(id);

            if(product == null){return null;}

            InsuranceCostReadDto insuranceCostReadDto = Mapper.Map<InsuranceCostReadDto>(product);
            insuranceCostReadDto.canBeInsured = product.ProductType.canBeInsured;
            
            if (product.ProductType.canBeInsured == true){ 
                insuranceCostReadDto.insuranceCost = this.getCalculateInsuranceCost(product, product.ProductType);
            }

            return insuranceCostReadDto;
        }

        private Decimal getCalculateInsuranceCost(Product product, ProductType productType){

            Decimal insuranceCost = 0;

            if (product.salesPrice < 500)
            {
                 insuranceCost = 0;
            }else if (product.salesPrice < 2000)
            {
                insuranceCost = 1000;
            }else if (product.salesPrice >= 2000)
            {
                insuranceCost = 2000;
            }

            if (productType.productTypeEnum == ProductTypeEnum.Laptops || productType.productTypeEnum == ProductTypeEnum.Smartphones)
            {
                insuranceCost += 500;
            }

            return insuranceCost;
        }
    }
}