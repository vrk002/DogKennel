using System;
using DogKennel.Data;
using DogKennel.Models;
using Microsoft.EntityFrameworkCore;

namespace DogKennel.Repositories;

public class DogRepository : IRepository<Dog>
{
    private readonly AppDbContext _context;
    public DogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Dog entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _context.Dogs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Dog entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Dogs.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Dog>> GetAllAsync()
    {
        return await _context.Dogs.ToListAsync();
    }

    public async Task<Dog> GetByIdAsync(int id)
    {
        var dog = await _context.Dogs.FindAsync(id);
        if (dog == null)
        {
            throw new ArgumentNullException(nameof(dog));
        }

        return dog;
    }

    public Task UpdateAsync(Dog entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.Dogs.Update(entity);
        return _context.SaveChangesAsync();
    }
}
