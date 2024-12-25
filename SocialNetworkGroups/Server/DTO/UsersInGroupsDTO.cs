namespace Server.Dto;

public class UsersInGroupsDto
{
    /// <summary>
    /// Группа
    /// </summary>
    public GroupDto? Group { get; set; }

    /// <summary>
    /// Список пользователей, состоящих в группе
    /// </summary>
    public List<UserDto>? Users { get; set; }
}
