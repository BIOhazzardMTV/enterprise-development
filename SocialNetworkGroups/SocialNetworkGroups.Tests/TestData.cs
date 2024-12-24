using SocialNetworkGroups.Domain;
namespace SocialNetworkGroups.Tests;

public static class TestDatabase
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, FullName = "Иван Иванов", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1990, 5, 12), RegistrationDate = new DateOnly(2020, 1, 15) },
        new User { Id = 2, FullName = "Мария Петрова", Gender = GenderEnum.Female, DateOfBirth = new DateOnly(1995, 8, 24), RegistrationDate = new DateOnly(2021, 6, 10) },
        new User { Id = 3, FullName = "Алексей Смирнов", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1987, 3, 18), RegistrationDate = new DateOnly(2019, 11, 5) },
        new User { Id = 4, FullName = "Екатерина Фёдорова", Gender = GenderEnum.Female, DateOfBirth = new DateOnly(1992, 2, 14), RegistrationDate = new DateOnly(2020, 8, 20) },
        new User { Id = 5, FullName = "Дмитрий Соколов", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1985, 12, 30), RegistrationDate = new DateOnly(2021, 1, 25) }
    };

    public static List<Group> Groups = new List<Group>
    {
        new Group { Id = 1, Title = "Технологии", Description = "Группа для обсуждения технологий", CreationDate = new DateOnly(2022, 2, 20), AuthorId = 1 },
        new Group { Id = 2, Title = "Кулинария", Description = "Группа для любителей готовить", CreationDate = new DateOnly(2023, 4, 10), AuthorId = 2 },
        new Group { Id = 3, Title = "Путешествия", Description = "Советы и обсуждения о путешествиях", CreationDate = new DateOnly(2021, 9, 5), AuthorId = 4 },
        new Group { Id = 4, Title = "Музыка", Description = "Обсуждение любимых музыкальных жанров", CreationDate = new DateOnly(2020, 3, 15), AuthorId = 5 }
    };

    public static List<Post> GroupPosts = new List<Post>
    {
        new Post { Id = 1, Title = "Лучшие практики программирования", Description = "Обсуждаем принципы SOLID", CreationDate = new DateOnly(2023, 6, 1), AuthorId = 1, GroupId = 1 },
        new Post { Id = 2, Title = "Рецепт борща", Description = "Пошаговый рецепт вкусного борща", CreationDate = new DateOnly(2023, 7, 15), AuthorId = 2, GroupId = 2 },
        new Post { Id = 3, Title = "Как спланировать поездку в Европу", Description = "Пошаговый гид для путешественников", CreationDate = new DateOnly(2022, 5, 10), AuthorId = 4, GroupId = 3 },
        new Post { Id = 4, Title = "Лучшие альбомы 2023 года", Description = "Рейтинг самых популярных музыкальных альбомов", CreationDate = new DateOnly(2023, 8, 20), AuthorId = 5, GroupId = 4 },
        new Post { Id = 5, Title = "Рецепт плова", Description = "Пошаговый рецепт лучшего плова на свете", CreationDate = new DateOnly(2023, 7, 16), AuthorId = 2, GroupId = 2 }
    };

    public static List<GroupRole> GroupRoles = new List<GroupRole>
    {
        new GroupRole { Id = 1, UserId = 1, GroupId = 1, Role = UserRoleEnum.Administrator },
        new GroupRole { Id = 2, UserId = 2, GroupId = 1, Role = UserRoleEnum.Moderator },
        new GroupRole { Id = 3, UserId = 2, GroupId = 2, Role = UserRoleEnum.Administrator },
        new GroupRole { Id = 4, UserId = 3, GroupId = 1, Role = UserRoleEnum.Reader },
        new GroupRole { Id = 5, UserId = 4, GroupId = 3, Role = UserRoleEnum.Administrator },
        new GroupRole { Id = 6, UserId = 5, GroupId = 4, Role = UserRoleEnum.Administrator },
        new GroupRole { Id = 7, UserId = 1, GroupId = 4, Role = UserRoleEnum.Reader },
        new GroupRole { Id = 8, UserId = 3, GroupId = 3, Role = UserRoleEnum.Moderator }
    };
}