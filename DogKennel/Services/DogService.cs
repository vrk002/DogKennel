using System;
using DogKennel.Models;
using DogKennel.Repositories;

namespace DogKennel.Services;

public class DogService
{
    private readonly IRepository<Dog> _dogRepository;
    public DogService(IRepository<Dog> dogRepository)
    {
        _dogRepository = dogRepository;
    }

    public async Task AddDogAsync(Dog dog)
    {
        if (dog == null)
        {
            throw new ArgumentNullException(nameof(dog));
        }

        await _dogRepository.AddAsync(dog);
    }

    public async Task UpdateDogAsync(Dog dog)
    {
        if (dog == null)
        {
            throw new ArgumentNullException(nameof(dog));
        }

        await _dogRepository.UpdateAsync(dog);
    }

    public async Task DeleteDogAsync(Dog dog)
    {
        if (dog == null)
        {
            throw new ArgumentNullException(nameof(dog));
        }

        await _dogRepository.DeleteAsync(dog);
    }

    public async Task<Dog> GetDogByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        return await _dogRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Dog>> GetAllDogsAsync()
    {
        return await _dogRepository.GetAllAsync();
    }
    
}
