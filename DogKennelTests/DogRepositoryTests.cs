using System;
using DogKennel.Data;
using DogKennel.Models;
using DogKennel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DogKennelTests;

public class DogRepositoryTests
{
    private DogRepository GetRepository(out AppDbContext context)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Isolated DB
            .Options;

        context = new AppDbContext(options);
        return new DogRepository(context);
    }

    [Fact]
    public async Task AddAsync_Should_Add_Dog_To_Database()
    {
        // Arrange
        var repo = GetRepository(out var context);
        var dog = new Dog { Name = "Rex", Breed = "Labrador", DateOfBirth = new DateTime(2020, 1, 1), OwnerName = "Alice" };

        // Act
        await repo.AddAsync(dog);
        var result = await context.Dogs.FirstOrDefaultAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Rex", result.Name);
    }
}
