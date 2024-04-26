using Oracle.ManagedDataAccess.Client;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
 
    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        List<Animal> animals = new List<Animal>();
        using var connection =
            new OracleConnection(_configuration.GetValue<String>("ConnectionString"));
        {
            connection.Open();

            using (OracleCommand command =
                   new OracleCommand("select * from s25355.Animals order by " + orderBy, connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            Animal a = new Animal();
                            a.Id = (decimal)reader["id"];
                            a.Name = (string)reader["name"];
                            a.Description = (string)reader["description"];
                            a.Area = (string)reader["area"];
                            a.Category = (string)reader["Category"];
                            animals.Add(a);
                        }
                    }
                }
            }
        }
        return animals;
    }

    public Animal GetAnimalById(int id)
    {
        var connection = new OracleConnection(_configuration.GetValue<string>("ConnectionString"));
        connection.Open();
        var commandText = "SELECT * FROM Animals WHERE Id = :Id";
        
        using (var command = new OracleCommand(commandText, connection))
        {
            command.Parameters.Add("Id", OracleDbType.Int32).Value = id;
            
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read()){
                    return new Animal
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        Area = reader.GetString(reader.GetOrdinal("Area")),
                        Category = reader.GetString(reader.GetOrdinal("Category"))
                    };
                }
                else
                {
                    return null; 
                }
            }
        }
    }

    public int CreateAnimal(Animal animal)
    {
        var connection = new OracleConnection(_configuration.GetValue<string>("ConnectionString"));
        connection.Open();
    
        var command = new OracleCommand("INSERT INTO Animals(Name, Description, Area, Category) VALUES (:Name, :Description, :Area, :Category)", connection);
        command.Parameters.Add("Name", OracleDbType.Varchar2).Value = animal.Name;
        command.Parameters.Add("Description", OracleDbType.Varchar2).Value = animal.Description;
        command.Parameters.Add("Area", OracleDbType.Varchar2).Value = animal.Area;
        command.Parameters.Add("Category", OracleDbType.Varchar2).Value = animal.Category;

        int rowsAffected = command.ExecuteNonQuery();

        connection.Close();
        return rowsAffected;
    }


    public int DeleteAnimal(int id)
    {
        var connectionString = _configuration.GetValue<string>("ConnectionString");
    
        using (var connection = new OracleConnection(connectionString))
        {
            connection.Open();
        
            var commandText = "DELETE FROM Animals WHERE Id = :Id";
        
            using (var command = new OracleCommand(commandText, connection))
            {
                command.Parameters.Add("Id", OracleDbType.Int32).Value = id;
                return command.ExecuteNonQuery();
            }
        }
    }

    public int UpdateAnimal(Animal animal)
    {
        var connection = new OracleConnection(_configuration.GetValue<string>("ConnectionString"));
        connection.Open();
        
        var commandText = "UPDATE Animals SET Name = :Name, Description = :Description, Area = :Area, Category = :Category WHERE Id = :Id";
        
        using (var command = new OracleCommand(commandText, connection))
        {
            command.Parameters.Add("Name", OracleDbType.Varchar2).Value = animal.Name;
            command.Parameters.Add("Description", OracleDbType.Varchar2).Value = animal.Description;
            command.Parameters.Add("Area", OracleDbType.Varchar2).Value = animal.Area;
            command.Parameters.Add("Category", OracleDbType.Varchar2).Value = animal.Category;
            command.Parameters.Add("Id", OracleDbType.Int32).Value = animal.Id; 
            
           
            return command.ExecuteNonQuery();;
        }

    }
}