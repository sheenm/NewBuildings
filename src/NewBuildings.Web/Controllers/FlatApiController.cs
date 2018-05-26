using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewBuildings.BusinessLogic.Services;
using NewBuildings.BusinessLogic.ViewModels;
using NewBuildings.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewBuildings.Web.Controllers
{
    [Route("api/flat")]
    public class FlatApiController : Controller
    {
        private FlatService _flatService;
        private readonly ILogger<FlatApiController> _logger;

        public FlatApiController(FlatService flatService, ILogger<FlatApiController> logger)
        {
            _flatService = flatService;
            _logger = logger;
        }

        [HttpGet("all-flats-summary")]
        public async Task<ServiceResponse<IEnumerable<FlatSummaryViewModel>>> GetAllFlatsSummary()
        {
            try
            {
                return await _flatService.GetAllFlatsSummary();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "exception in  GetAllFlatsSummary");
                return ServiceResponse<IEnumerable<FlatSummaryViewModel>>.Exception("An error occured during all-flats-summary request");
            }
        }

        [HttpGet("get-flat-details/{id:int}")]
        public async Task<ServiceResponse<FlatFullInformation>> GetFlatDetails(int id)
        {
            try
            {
                return await _flatService.GetFlatFullInformation(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"exception in  GetFlatDetails, called with id = {id}");
                return ServiceResponse<FlatFullInformation>.Exception("An error occured during get-flat-details request");
            }
        }

        [HttpPost("delete-flat")]
        public async Task<ServiceResponse<bool>> DeleteFlat(int id)
        {
            try
            {
                return await _flatService.DeleteFlat(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"exception in  DeleteFlat, called with id = {id}");
                return ServiceResponse<bool>.Exception("An error occured during delete-flat request");
            }
        }
    }
}
