using System.ComponentModel.DataAnnotations;

namespace FiorelloClone.Areas.Admin.ViewModels.CategoryVMs;

public class UpdateCategoryVM
{
    [Required]
    public string Name { get; set; }
}
