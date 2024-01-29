using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository.RepositoryInterface;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositoryWalk repository;

        public WalkController(IMapper mapper, IRepositoryWalk repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        //create a new walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> createNewWalk([FromBody] AddNewWalkDTO addNewWalkDTO)
        {
            //map addNewWalkDTO to Walk DomainModel and send the domain model to create walk method
            var walk = await repository.CreateNewWalkAsync(mapper.Map<Walk>(addNewWalkDTO));
            return Ok(mapper.Map<WalkDTO>(walk));
        }

        // api/walks?filterOn&filterQuery
        [HttpGet]
        public async Task<IActionResult> getAllWalks([FromQuery] string? filterOn , [FromQuery] string? filterQuery, [FromQuery] String? orderBy, [FromQuery] bool? isDecending, int pageNumber = 1, int pageSize = 1000) {

            var walks = await repository.getAllWaksAsync(filterOn, filterQuery, orderBy, isDecending ?? true, pageNumber, pageSize);
            return Ok(mapper.Map<List<WalkDTO>>(walks));
        }

        [HttpPost]
        [Route("{id:Guid}")]
        public async Task<IActionResult> getWalkById([FromRoute] Guid id) {

            var walk = await repository.getWalkById(id);
            if (walk == null) return NotFound();
            return Ok(mapper.Map<WalkDTO>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdatWalk([FromRoute] Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {

            var domain = mapper.Map<Walk>(updateWalkDTO);
            var updatedData = await repository.updateWalkAsync(id, domain);
            if (updatedData == null) return NotFound();

            //map updated data to domain model
            return Ok(mapper.Map<WalkDTO>(updatedData));

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid id) { 
            
            await repository.deleteWalkAsync(id);
            return Ok();
        }

    }
}
