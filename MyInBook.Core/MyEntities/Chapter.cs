namespace MyInBook.Core.MyEntities;

public class Chapter
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
}
