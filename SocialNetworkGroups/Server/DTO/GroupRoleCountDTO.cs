namespace Server.DTO;

public class GroupRoleCountDTO
{
    /// <summary>
    /// Список ролей в группе
    /// </summary>
    public GroupRoleDTO? GroupRoleDTO { get; set; }
    /// <summary>
    /// Количество различных групп пользователей в каждой группе
    /// </summary>
    public int GroupRoleCount { get; set; }
}
