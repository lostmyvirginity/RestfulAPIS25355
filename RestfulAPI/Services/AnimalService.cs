using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    private IAnimalRepository _repository = animalRepository;

    public IEnumerable<AnimalDTO> GetAnimals(string orderBy)
    {
        return _repository.GetAnimals(orderBy).Select(a => new AnimalDTO()
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
            Area = a.Area,
            Category = a.Category
        });
    }

    public AnimalDTO GetAnimalByID(int id)
    {
        var a = _repository.GetAnimalById(id);
        return new AnimalDTO
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
            Category = a.Category,
            Area = a.Area
        };
    }

    public int CreateAnimal(AnimalCreationDTO animal)
    {
        return _repository.CreateAnimal(new Animal
        {
            Name = animal.Name,
            Description = animal.Description,
            Category = animal.Category,
            Area = animal.Area
        });
    }

    public int UpdateAnimal(int id, AnimalUpdateDTO animalUpdateDto)
    {
        return _repository.UpdateAnimal(new Animal
        {
            Id = id,
            Name = animalUpdateDto.Name,
            Description = animalUpdateDto.Description,
            Category = animalUpdateDto.Category,
            Area = animalUpdateDto.Area
        });
    }

    public int DeleteAnimal(int id)
    {
        return _repository.DeleteAnimal(id);
    }
}