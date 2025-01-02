using System.ComponentModel.DataAnnotations;

namespace MyInBook.Core.MyEntities;

public class Book
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Title { get; set; }
    [Required, MaxLength(100)]
    public string Description { get; set; }
    [Required, MaxLength(100),]
    public string Author { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; }
    public ICollection<Chapter>? Chapters { get; set; }

}
