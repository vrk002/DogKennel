using System;

namespace DogKennel.Models;

public class Dog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Breed { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string OwnerName { get; set; } = string.Empty;
}
