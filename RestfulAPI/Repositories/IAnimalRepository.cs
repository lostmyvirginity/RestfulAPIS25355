using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    Animal GetAnimalById(int id);
    public int CreateAnimal(Animal animal);
    public int DeleteAnimal(int id);
    public int UpdateAnimal(Animal animal);
}