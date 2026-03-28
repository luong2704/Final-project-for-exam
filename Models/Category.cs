using System.ComponentModel.DataAnnotations;

namespace Campus.Models;

public class Category
{
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? CategoryDescription { get; set; }

    public CategoryType CategoryType { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
