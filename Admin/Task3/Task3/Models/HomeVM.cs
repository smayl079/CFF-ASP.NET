using Task3.Models.Base;

namespace Task3.Models;

public class HomeVM
{
    public IEnumerable<Slider> Sliders { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
