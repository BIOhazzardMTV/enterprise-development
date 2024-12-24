namespace SocialNetworkGroups.Domain;

public enum GenderEnum
{
    Male,
    Female
}
public class User
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ФИО пользователя
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Пол пользователя (мужской/женский/Не указан)
    /// </summary>
    public required GenderEnum Gender { get; set; }

    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    public required DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public required DateOnly RegistrationDate { get; set; }
}
