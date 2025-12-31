using FrontToBack.Models;

namespace FrontToBack.ViewModels;

public class HomeVM
{
    public IEnumerable<OurWork> OurWorks { get; set; }
    public IEnumerable<Category> Categories { get; set; }
}
