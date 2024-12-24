namespace SocialNetworkGroups.Domain;

public enum UserRoleEnum
{
    Administrator,
    Moderator,
    CoAuthor,
    Reader
}
public class GroupRole
{
    /// <summary>
    /// Идентификатор связи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public required int UserId { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public required int GroupId { get; set; }

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public required UserRoleEnum Role { get; set; }
}
