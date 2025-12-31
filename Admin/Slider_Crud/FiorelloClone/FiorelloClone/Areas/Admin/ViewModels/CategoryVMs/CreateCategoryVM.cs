using System.ComponentModel.DataAnnotations;

namespace FiorelloClone.Areas.Admin.ViewModels.CategoryVMs;

public class CreateCategoryVM
{
    [Required]
    public string Name { get; set; }
}
