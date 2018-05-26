using NewBuildings.BusinessLogic.ViewModels;
using NewBuildings.Core;
using NewBuildings.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBuildings.BusinessLogic
{
    public class FlatController
    {
        private readonly IFlatRepository _flatRepository;

        public FlatController(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        public async Task<ServiceResponse<IEnumerable<FlatSummaryViewModel>>> GetAllFlatsSummary()
        {
            var flats = (await _flatRepository.GetAllFlatsWithHouseInfo())
                .Select(flat => new FlatSummaryViewModel(flat, flat.House)).ToList();

            return ServiceResponse<IEnumerable<FlatSummaryViewModel>>.Ok(flats);
        }

        public async Task<ServiceResponse<bool>> DeleteFlat(int id)
        {
            if (id == default(int))
                return ServiceResponse<bool>.Warning("Could not delete flat with empty identifier");

            return ServiceResponse<bool>.Ok(await _flatRepository.Delete(id));
        }

    }
}
