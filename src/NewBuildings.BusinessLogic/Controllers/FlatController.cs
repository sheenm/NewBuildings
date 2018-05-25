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
            try
            {
                var flats = (await _flatRepository.GetAllFlatsWithHouseInfo())
                    .Select(flat => new FlatSummaryViewModel(flat, flat.House));

                return ServiceResponse<IEnumerable<FlatSummaryViewModel>>.Ok(flats);
            }
            catch (Exception ex)
            {
                //todo: добавить логирование ex
                return ServiceResponse<IEnumerable<FlatSummaryViewModel>>.Exception("Произошла ошибка при получении данных о квартирах");
            }
        }

    }
}
