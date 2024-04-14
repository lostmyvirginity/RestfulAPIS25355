using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    public IEnumerable<Animal> getAnimals()
    {
        throw new NotImplementedException();
    }

    public Animal getAnimalById(int id)
    {
        throw new NotImplementedException();
    }

    public int CreateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }

    public int DeleteAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public int UpdateAnimal(Animal animal)
    {
        throw new NotImplementedException();
    }
}