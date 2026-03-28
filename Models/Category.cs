namespace Campus.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? CategoryDescription { get; set; }
    public string Color { get; set; } = "#0078D4";
    public string Icon { get; set; } = "📌";
    public CategoryType CategoryType { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
