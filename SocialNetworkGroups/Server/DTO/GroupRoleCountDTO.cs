namespace Server.Dto;

public class GroupRoleCountDto
{
    /// <summary>
    /// Список ролей в группе
    /// </summary>
    public GroupRoleDto? GroupRoleDto { get; set; }
    /// <summary>
    /// Количество различных групп пользователей в каждой группе
    /// </summary>
    public int GroupRoleCount { get; set; }
}
