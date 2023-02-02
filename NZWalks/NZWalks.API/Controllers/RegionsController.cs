using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repostories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    //[Route("Regions")][Route("nz-regions")]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private IRegionRepository _regionRepository;
        private IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRegion()
        {
            #region return result using  static data

            //var regions = new List<Region>()
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington",
            //        Code = "WLG",
            //        Area = 227755,
            //        Lat = -1.8822,
            //        Long = 299.88,
            //        Population = 500000
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Aucklamd",
            //        Code = "AUCK",
            //        Area = 227755,
            //        Lat = -1.8822,
            //        Long = 299.88,
            //        Population = 500000
            //    }
            //};

            #endregion

            var regions = _regionRepository.GetAll();

            #region map data into DTO object
            //   var regionsDTOs = new List<Models.Domain.Region>();
            //regions?.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.Domain.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };
            //    regionsDTOs.Add(regionDTO);
            //});

            #endregion

            var regionsDTOs = _mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTOs);
        }
    }
}
