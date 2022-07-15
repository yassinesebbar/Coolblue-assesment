using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Dtos;

namespace coolblue_assesment.Services
{
    public interface IInsuranceService
    {
        public InsuranceCostReadDto? getInsuranceCost(int id);
    }
}