namespace FiorelloClone.ViewModels;

public class HeaderVM
{
    public Dictionary<string, string> Settings { get; set; }
    public int BasketCount { get; set; } = 0;
    public decimal BasketPrice { get; set; }
}
