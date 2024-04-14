using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private IConfiguration _configuration;

    public AnimalsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public ActionResult<IEnumerable<AnimalDTO>> GetAnimals()
    {
        using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));
        
        using SqlCommand com = new SqlCommand();
        com.Connection = con;

        com.CommandText = "select * from Animals";
        con.Open();

        SqlDataReader reader = com.ExecuteReader();

        List<Animal> animals = new List<Animal>();
        while (reader.Read())
        {
            Animal a = new Animal();
            a.Id = (int)reader["id"];
            a.Name = (string)reader["name"];
            a.Description = (string)reader["description"];
            a.Area = (string)reader["area"];
            a.Category = (string)reader["Category"];
            animals.Add(a);
        }
        
        return Ok();
    }

    [HttpPost]
    public ActionResult CreateAnimal(AnimalCreationDTO animal)
    {
        using SqlConnection con = new SqlConnection(_configuration.GetValue<string>("ConnectionString"));
        using SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "INSERT INTO Animals(Name, Description, Area, Category) VALUES (@Name, @Description, @Area, @Category)";
        com.Parameters.AddWithValue("@Name", animal.Name);
        com.Parameters.AddWithValue("@Description", animal.Description);
        com.Parameters.AddWithValue("@Area", animal.Area);
        com.Parameters.AddWithValue("@Category", animal.Category);
        
        con.Open();
        
        var affectedCount = (int com.)
        return Ok();
    }
}