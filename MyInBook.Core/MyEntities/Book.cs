using System.ComponentModel.DataAnnotations;

namespace MyInBook.Core.MyEntities;

public class Book
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Description { get; set; } = null!;
    [Required, MaxLength(100)]
    public string Author { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
    public ICollection<Chapter>? Chapters { get; set; }

}
