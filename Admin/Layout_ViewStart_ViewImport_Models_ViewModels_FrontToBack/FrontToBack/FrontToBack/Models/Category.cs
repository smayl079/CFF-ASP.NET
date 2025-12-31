namespace FrontToBack.Models;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<OurWork> OurWorks { get; set; } = new HashSet<OurWork>();
}
