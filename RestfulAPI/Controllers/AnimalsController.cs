using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        this._animalService = animalService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AnimalDTO>> GetAnimals(String orderBy = "Name")
    {
        return Ok(_animalService.GetAnimals(orderBy));
    }

    [HttpGet("{id:int}")]
    public ActionResult<AnimalDTO> GetAnimalByID(int id)
    {
        return Ok(_animalService.GetAnimalByID(id));
    }

    [HttpPost]
    public ActionResult CreateAnimal(AnimalCreationDTO animal)
    {
        return Ok(_animalService.CreateAnimal(animal));
    }

    [HttpPut]
    public ActionResult UpdateAnimal(int id, AnimalUpdateDTO animalUpdateDto)
    {
        return Ok(_animalService.UpdateAnimal(id, animalUpdateDto));
    }

    [HttpDelete]
    public ActionResult DeleteAnimal(int id)
    {
        return Ok(_animalService.DeleteAnimal(id));
    }
}