using AMuthurajApi.Presentation.ActionFilters;
using AMuthurajApi.Presentation.ModelBinders;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Text.Json;
using SharedDto.RequestFeatures;
using SharedDto.DataTransferObjects.Masters;

namespace AMuthurajApi.Presentation.Controllers
{
    [Route("api/ServProviders")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class ServProvidersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ServProvidersController(IServiceManager service) => _service = service;

        /// <summary>
        /// Creates a New ServProvider
        /// </summary>
        /// <param name="servprovider"></param>
        /// <returns>A newly created ServProvider</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateServProvider")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateServProviders([FromBody] ServProviderCreateDto servprovider)
        {
            var createdEntity = await _service.ServProviderService.CreateServProviderAsync(servprovider);
            return CreatedAtRoute("ServProviderById", new { id = createdEntity.Id }, createdEntity);
        }

        /// <summary>
        /// Deletes a ServProvider
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> The ServProvider Record </returns>
        /// <response code="400">If the item is null</response>
        [HttpDelete(Name = "DeleteServProvider")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteServProvider(int Id)
        {
            await _service.ServProviderService.DeleteServProviderAsync(Id, trackChanges: false);
            return NoContent();
        }

        /// <summary>
        /// Gets a record based on ID from ServProvider
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> NoContent </returns>
        [HttpGet("{Id:int}", Name = "ServProviderById")]
        public async Task<IActionResult> GetServProvider(int Id)
        {
            var returnEntity = await _service.ServProviderService.GetByIdAsync(Id, trackChanges: false);
            return Ok(returnEntity);
        }

        /// <summary>
        /// Gets All the records ServProvider
        /// </summary>
        /// <returns> All the Records in ServProvider</returns>
        [HttpGet(Name = "GetServProviders")]
        public async Task<IActionResult> GetServProviders([FromQuery] GeneralParameters generalParamters)
        {
            var pagedResult = await _service.ServProviderService.GetAllAsync(generalParamters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.servprovider);
        }

        /// <summary>
        /// Updates ServProvider
        /// </summary>
        /// <param name="Id"></param>
        [HttpPut("{Id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int Id, [FromBody] ServProviderUpdateDto servprovider)
        {
            await _service.ServProviderService.UpdateServProviderAsync(Id, servprovider, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateServProvider(int id, [FromBody] JsonPatchDocument<ServProviderUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");
            var result = await _service.ServProviderService.GetServProviderForPatchAsync(id, trackChanges: true);
            patchDoc.ApplyTo(result.servproviderToPatch, ModelState);
            TryValidateModel(result.servproviderToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.ServProviderService.SaveChangesForPatchAsync(result.servproviderToPatch, result.servproviderEntity);
            return NoContent();
        }
    }
}
