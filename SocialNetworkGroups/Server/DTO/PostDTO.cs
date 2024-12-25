namespace Server.Dto;

public class PostDto
{
    /// <summary>
    /// Заголовок записи
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Описание записи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public required DateOnly CreationDate { get; set; }

    /// <summary>
    /// Группа, в которой опубликована запись
    /// </summary>
    public required int GroupId { get; set; }

    /// <summary>
    /// Автор записи
    /// </summary>
    public required int AuthorId { get; set; }
}
