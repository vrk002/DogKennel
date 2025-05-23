using DogKennel.Models;
using DogKennel.Repositories;
using DogKennel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogKennel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogService _dogService;

        public DogController(DogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDogs()
        {
            var dogs = await _dogService.GetAllDogsAsync();
            return Ok(dogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogById(int id)
        {
            var dog = await _dogService.GetDogByIdAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            return Ok(dog);
        }

        [HttpPost]
        public async Task<IActionResult> AddDog([FromBody] Dog dog)
        {
            if (dog == null)
            {
                return BadRequest("Dog cannot be null");
            }

            await _dogService.AddDogAsync(dog);
            return CreatedAtAction(nameof(GetDogById), new { id = dog.Id }, dog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog(int id, [FromBody] Dog dog)
        {
            if (dog == null || dog.Id != id)
            {
                return BadRequest("Dog ID mismatch");
            }

            var existingDog = await _dogService.GetDogByIdAsync(id);
            if (existingDog == null)
            {
                return NotFound();
            }

            await _dogService.UpdateDogAsync(dog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            var dog = await _dogService.GetDogByIdAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            await _dogService.DeleteDogAsync(dog);
            return NoContent();
        }
        
    }
}
