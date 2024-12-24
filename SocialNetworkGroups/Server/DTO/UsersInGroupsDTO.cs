namespace Server.DTO;

public class UsersInGroupsDTO
{
    /// <summary>
    /// Группа
    /// </summary>
    public GroupDTO? Group { get; set; }

    /// <summary>
    /// Список пользователей, состоящих в группе
    /// </summary>
    public List<UserDTO>? Users { get; set; }
}
