using NewBuildings.BusinessLogic.ViewModels;
using NewBuildings.Core;
using NewBuildings.Data.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBuildings.BusinessLogic.Services
{
    public class FlatService
    {
        private readonly IFlatRepository _flatRepository;

        public FlatService(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        public async Task<ServiceResponse<IEnumerable<FlatSummaryViewModel>>> GetAllFlatsSummary()
        {
            var flats = (await _flatRepository.GetAllFlatsWithHouseInfo())
                .Select(flat => new FlatSummaryViewModel(flat, flat.House)).ToList();

            return ServiceResponse<IEnumerable<FlatSummaryViewModel>>.Ok(flats);
        }

        public async Task<ServiceResponse<FlatFullInformationViewModel>> GetFlatFullInformation(int id)
        {
            if (id == default(int))
                return ServiceResponse<FlatFullInformationViewModel>.Warning("Couldn't find a flat with an empty identifier");

            var flat = await _flatRepository.GetFullFlatInformation(id);

            return ServiceResponse<FlatFullInformationViewModel>.Ok(new FlatFullInformationViewModel(flat));
        }

        public async Task<ServiceResponse<bool>> EditFlat(FlatFullInformationViewModel flatViewModel)
        {
            if(flatViewModel == null)
                return ServiceResponse<bool>.Warning("Did not receive flat's information");

            if (flatViewModel.Id == default(int))
                return ServiceResponse<bool>.Warning("Couldn't find a flat with an empty identifier");

            if(flatViewModel.KitchenArea >= flatViewModel.FullArea)
                return ServiceResponse<bool>.Warning("Kitchen area should be less than full area");

            var flat = await _flatRepository.GetById(flatViewModel.Id);
            if (flat == null)
                return ServiceResponse<bool>.Warning($"Couldn't find a flat with id = {flatViewModel.Id}");

            flat.FullArea = flatViewModel.FullArea;
            flat.KitchenArea = flatViewModel.KitchenArea;
            flat.Floor = flatViewModel.Floor;
            flat.Cost = flatViewModel.Cost;

            return ServiceResponse<bool>.Ok(await _flatRepository.Save(flat));
        }

        public async Task<ServiceResponse<bool>> DeleteFlat(int id)
        {
            if (id == default(int))
                return ServiceResponse<bool>.Warning("Could not delete a flat with an empty identifier");

            return ServiceResponse<bool>.Ok(await _flatRepository.Delete(id));
        }
    }
}
