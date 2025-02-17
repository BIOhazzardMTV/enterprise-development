﻿namespace SocialNetworkGroups.Domain;

public class Group
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название группы
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Описание группы
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Дата создания группы
    /// </summary>
    public required DateOnly CreationDate { get; set; }

    /// <summary>
    /// Автор группы
    /// </summary>
    public required int AuthorId { get; set; }
}
