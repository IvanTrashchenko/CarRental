using System;
using System.Net;
using System.Threading.Tasks;
using CarRentalWebApplication.Models;
using CarRentalWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService service;

        public CarsController(ICarService service)
        {
            this.service = service ?? throw new ArgumentNullException($"{nameof(service)} cannot be null.");
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddItem([FromBody] UpdateCarRequest createRequest)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = await this.service.CreateItemAsync(createRequest);
            var location = $"/api/cars/{item.CarId}";
            return this.Created(location, item);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await this.service.DeleteItemAsync(id);
                return this.NoContent();
            }
            catch (InvalidOperationException)
            {
                return this.Conflict();
            }
            catch (CarNotFoundException)
            {
                return this.NotFound();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetItem(int id)
        {
            try
            {
                var item = await this.service.GetItemAsync(id);
                return this.Ok(item);
            }
            catch (InvalidOperationException)
            {
                return this.Conflict();
            }
            catch (CarNotFoundException)
            {
                return this.NotFound();
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItems()
        {
            var boardGames = await this.service.GetItemsAsync();
            return this.Ok(boardGames);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateCarRequest updateRequest)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {
                await this.service.UpdateItemAsync(id, updateRequest);
                return this.NoContent();
            }
            catch (InvalidOperationException)
            {
                return this.Conflict();
            }
            catch (CarNotFoundException)
            {
                return this.NotFound();
            }
        }
    }
}
