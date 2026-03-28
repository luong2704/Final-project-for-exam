using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class Event : ObservableObject
{
    [Key]
    public int EventId { get; set; }

    [Required]
    [MaxLength(200)]
    public string EventName { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? EventDescription { get; set; }

    public DateTime EventDate { get; set; }

    [MaxLength(200)]
    public string? Location { get; set; }

    public int? CategoryId { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
