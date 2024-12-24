using SocialNetworkGroups.Domain;
namespace SocialNetworkGroups.Tests;

public static class TestDatabase
{
    public static List<User> Users = new List<User>
    {
        new User { Id = 1, FullName = "Ivan Ivanov", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1990, 5, 12), RegistrationDate = new DateOnly(2020, 1, 15) },
        new User { Id = 2, FullName = "Maria Petrova", Gender = GenderEnum.Female, DateOfBirth = new DateOnly(1995, 8, 24), RegistrationDate = new DateOnly(2021, 6, 10) },
        new User { Id = 3, FullName = "Alexey Smirnov", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1987, 3, 18), RegistrationDate = new DateOnly(2019, 11, 5) },
        new User { Id = 4, FullName = "Ekaterina Fedorova", Gender = GenderEnum.Female, DateOfBirth = new DateOnly(1992, 2, 14), RegistrationDate = new DateOnly(2020, 8, 20) },
        new User { Id = 5, FullName = "Dmitriy Sokolov", Gender = GenderEnum.Male, DateOfBirth = new DateOnly(1985, 12, 30), RegistrationDate = new DateOnly(2021, 1, 25) }
    };

    public static List<Group> Groups = new List<Group>
    {
        new Group { Id = 1, Title = "Technologies", Description = "Technology Discussion Group", CreationDate = new DateOnly(2022, 2, 20), AuthorId = 1 },
        new Group { Id = 2, Title = "Cooking", Description = "A group for cooking enthusiasts", CreationDate = new DateOnly(2023, 4, 10), AuthorId = 2 },
        new Group { Id = 3, Title = "Journeys", Description = "Travel tips and Discussions", CreationDate = new DateOnly(2021, 9, 5), AuthorId = 4 },
        new Group { Id = 4, Title = "Music", Description = "Discussing your favorite music genres", CreationDate = new DateOnly(2020, 3, 15), AuthorId = 5 }
    };

    public static List<Post> GroupPosts = new List<Post>
    {
        new Post { Id = 1, Title = "Best Programming Practices", Description = "Discussing the principles of SOLID", CreationDate = new DateOnly(2023, 6, 1), AuthorId = 1, GroupId = 1 },
        new Post { Id = 2, Title = "Borscht recipe", Description = "Step-by-step recipe for delicious borscht", CreationDate = new DateOnly(2023, 7, 15), AuthorId = 2, GroupId = 2 },
        new Post { Id = 3, Title = "How to plan a trip to Europe", Description = "A step-by-step guide for travelers", CreationDate = new DateOnly(2022, 5, 10), AuthorId = 4, GroupId = 3 },
        new Post { Id = 4, Title = "The best albums of 2023", Description = "Rating of the most popular music albums", CreationDate = new DateOnly(2023, 8, 20), AuthorId = 5, GroupId = 4 },
        new Post { Id = 5, Title = "Pilaf recipe", Description = "A step-by-step recipe for the best pilaf in the world", CreationDate = new DateOnly(2023, 7, 16), AuthorId = 2, GroupId = 2 }
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