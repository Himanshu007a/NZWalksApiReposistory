using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.DTO_s;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]



    public class RegionsController : Controller
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()

        {
            //Convert regionDomain into the RegionDto
            var regionDomains = dbContext.Regions.ToList();

            var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionDomains)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });



            };


            return Ok(regionsDto);
        }

     [HttpGet]
     [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var regionDomain = dbContext.Regions.Find(id);
            //  var regionDomain = dbContext.Regions.FirstOrDefault(x =x.Id == id)
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionsDto);
        }

       // Convert or map Dto into DomainModel
       [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,

            };
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            var regionsDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,

            };

            return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);
        }
    }
}
