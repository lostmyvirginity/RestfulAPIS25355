using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IAnimalService
{
    public IEnumerable<AnimalDTO> GetAnimals(String orderBy);
    public AnimalDTO GetAnimalByID(int id);
    public int CreateAnimal(AnimalCreationDTO animal);
    public int UpdateAnimal(int id, AnimalUpdateDTO animalUpdateDto);
    public int DeleteAnimal(int id);
}