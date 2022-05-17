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
    [Route("api/Countries")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]

    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, MaxAge = 60)]
    [HttpCacheValidation(MustRevalidate = true)]
    public class CountriesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CountriesController(IServiceManager service) => _service = service;

        /// <summary>
        /// Creates a New Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns>A newly created Country</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost(Name = "CreateCountry")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCountries([FromBody] CountryCreateDto country)
        {
            var createdEntity = await _service.CountryService.CreateCountryAsync(country);
            return CreatedAtRoute("CountryById", new { id = createdEntity.Id }, createdEntity);
        }

        /// <summary>
        /// Deletes a Country
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> The Country Record </returns>
        /// <response code="400">If the item is null</response>
        //[HttpDelete(Name = "DeleteCountry")]
        [HttpDelete("{Id:int}")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCountry(int Id)
        {
            await _service.CountryService.DeleteCountryAsync(Id, trackChanges: false);
            return NoContent();
        }

        /// <summary>
        /// Gets a record based on ID from Country
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> NoContent </returns>
        [HttpGet("{Id:int}", Name = "CountryById")]
        public async Task<IActionResult> GetCountry(int Id)
        {
            var returnEntity = await _service.CountryService.GetByIdAsync(Id, trackChanges: false);
            return Ok(returnEntity);
        }

        /// <summary>
        /// Gets All the records Country
        /// </summary>
        /// <returns> All the Records in Country</returns>
        [HttpGet(Name = "GetCountries")]
        [HttpCacheIgnore]
        public async Task<IActionResult> GetCountries([FromQuery] CountryParameters countryParameters)
        {
            var pagedResult = await _service.CountryService.GetAllAsync(countryParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.country);
        }

        /// <summary>
        /// Updates Country
        /// </summary>
        /// <param name="Id"></param>
        [HttpPut("{Id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int Id, [FromBody] CountryUpdateDto country)
        {
            await _service.CountryService.UpdateCountryAsync(Id, country, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateCountry(int id, [FromBody] JsonPatchDocument<CountryUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");
            var result = await _service.CountryService.GetCountryForPatchAsync(id, trackChanges: true);
            patchDoc.ApplyTo(result.countryToPatch, ModelState);
            TryValidateModel(result.countryToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.CountryService.SaveChangesForPatchAsync(result.countryToPatch, result.countryEntity);
            return NoContent();
        }
    }
}
