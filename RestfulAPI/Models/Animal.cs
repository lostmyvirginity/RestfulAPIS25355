namespace WebApplication1.Models;

public class Animal
{
    public decimal Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } = null;
    public string Area { get; set; } = null;

    public override string ToString()
    {
        return "Animal{Id=" + this.Id + ", Name=" + this.Name + ", Description=" + this.Description + ", Category=" +
               this.Category + ", Area=" + this.Area + "}";
    }
}