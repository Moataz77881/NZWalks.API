using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository.RepositoryInterface;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRepositoryRegion repository;
        private readonly IMapper autoMapper;

        public RegionController(IRepositoryRegion repository ,IMapper autoMapper)
        {
            this.repository = repository;
            this.autoMapper = autoMapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader , Writer")]
        public async Task<IActionResult> GetAllRegions()
        {
            // domain Data : get data from database
            var regions = await repository.getAllRegions();

            //Map Domain models to DTO
            
            return Ok(autoMapper.Map<List<RegionDTO>>(regions));
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader , Writer")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {

            // var region = dbContext.Regions.Find(id); search with primary key only
            //Domain Model : get data from database
            var region = await repository.getRegionById(id);   // search with any parameter 

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO =  autoMapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        // create new region 
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddNewRegionDTO addNewRegionDTO)
        {

            var regions = autoMapper.Map<Region>(addNewRegionDTO);

            await repository.createRegion(regions);

            var regionsDTO = autoMapper.Map<RegionDTO>(regions);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionsDTO.Id }, regionsDTO); // 201 response
        }

        //update region
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateData([FromRoute] Guid id, [FromBody] UpdateDTO updateDTO)
        {

            // covert DTO to domain

            var domain = autoMapper.Map<Region>(updateDTO);

            //Domain Model : get data from database by id
            var updatedregionDomain = await repository.updateRegion(id, domain);
            if (updatedregionDomain == null)
            {
                return NotFound();
            }

            // convert domain model to DTO

            var regionDTO = autoMapper.Map<RegionDTO>(domain);
           
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {

            var regionDomainModel = await repository.deleteRegion(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
