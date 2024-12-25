using SocialNetworkGroups.Domain;

namespace Server.Dto
{
    public class GroupRoleDto
    {
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
}
