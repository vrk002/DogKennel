using System;
using DogKennel.Models;
using Microsoft.EntityFrameworkCore;

namespace DogKennel.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Dog> Dogs { get; set; }
}
