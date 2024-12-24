using SocialNetworkGroups.Domain;
namespace SocialNetworkGroups.Tests;

public class SocialNetworkGroupsTests
{
    ///<summary>
    /// 1. Проверка: Вывести всех пользователей заданной группы, упорядочить по ФИО
    ///</summary>
    [Fact]
    public void GetUsersByGroupSortByFullName()
    {
        var groupId = 1;
        var expectedUsers = TestDatabase.GroupRoles
            .Where(gr => gr.GroupId == groupId)
            .Join(TestDatabase.Users, gr => gr.UserId, u => u.Id, (gr, u) => u)
            .OrderBy(u => u.FullName)
            .ToList();

        Assert.NotEmpty(expectedUsers);
        Assert.Equal("Alexey Smirnov", expectedUsers.First().FullName);
        Assert.Equal("Maria Petrova", expectedUsers.Last().FullName);
    }

    ///<summary>
    /// 2. Проверка: Вывести все записи, опубликованные в указанной группе, в порядке публикации.
    ///</summary>
    [Fact]
    public void GetAllPostsInGroupOrderedByCreationDate()
    {
        var groupId = 2;
        var expectedPosts = TestDatabase.GroupPosts
            .Where(p => p.GroupId == groupId)
            .OrderBy(p => p.CreationDate)
            .ToList();

        Assert.NotEmpty(expectedPosts);
        Assert.Equal("Borscht recipe", expectedPosts.First().Title);
        Assert.Equal("Pilaf recipe", expectedPosts.Last().Title);
    }

    ///<summary>
    /// 3. Проверка: Вывести суммарное число записей в каждой группе.
    ///</summary>
    [Fact]
    public void GetPostCountForEachGroup()
    {
        var groupPostCounts = TestDatabase.GroupPosts
            .GroupBy(p => p.GroupId)
            .Select(g => new { GroupId = g.Key, PostCount = g.Count() })
            .ToList();

        Assert.NotEmpty(groupPostCounts);
        Assert.Contains(groupPostCounts, g => g.GroupId == 1 && g.PostCount == 1);
        Assert.Contains(groupPostCounts, g => g.GroupId == 2 && g.PostCount == 2);
        Assert.Contains(groupPostCounts, g => g.GroupId == 3 && g.PostCount == 1);
        Assert.Contains(groupPostCounts, g => g.GroupId == 4 && g.PostCount == 1);
    }

    ///<summary>
    /// 4. Проверка: Вывести топ 5 пользователей по созданным записям за указанный период.
    ///</summary>
    [Fact]
    public void GetTop5UsersByPostsInPeriod()
    {
        var startDate = new DateOnly(2023, 1, 1);
        var endDate = new DateOnly(2023, 12, 31);

        var topUsers = TestDatabase.GroupPosts
            .Where(p => p.CreationDate >= startDate && p.CreationDate <= endDate)
            .GroupBy(p => p.AuthorId)
            .Select(g => new { UserId = g.Key, PostCount = g.Count() })
            .OrderByDescending(g => g.PostCount)
            .Take(5)
            .ToList();

        Assert.NotEmpty(topUsers);
        Assert.Contains(topUsers, u => u.UserId == 1 && u.PostCount == 1);
        Assert.Contains(topUsers, u => u.UserId == 2 && u.PostCount == 2);
        Assert.Contains(topUsers, u => u.UserId == 5 && u.PostCount == 1);
    }

    ///<summary>
    /// 5. Проверка: Вывести информацию о количестве администраторов, модераторов, соавторов и читателей в каждой группе.
    ///</summary>
    [Fact]
    public void GetRoleCountsInEachGroup()
    {
        var groupRoleCounts = TestDatabase.GroupRoles
            .GroupBy(gr => gr.GroupId)
            .Select(g => new
            {
                GroupId = g.Key,
                AdministratorCount = g.Count(gr => gr.Role == UserRoleEnum.Administrator),
                ModeratorCount = g.Count(gr => gr.Role == UserRoleEnum.Moderator),
                CoAuthorCount = g.Count(gr => gr.Role == UserRoleEnum.CoAuthor),
                ReaderCount = g.Count(gr => gr.Role == UserRoleEnum.Reader)
            })
            .ToList();

        Assert.NotEmpty(groupRoleCounts);
        Assert.Contains(groupRoleCounts, g => g.GroupId == 1 && g.AdministratorCount == 1 && g.ModeratorCount == 1 && g.CoAuthorCount == 0 && g.ReaderCount == 1);
        Assert.Contains(groupRoleCounts, g => g.GroupId == 2 && g.AdministratorCount == 1 && g.ModeratorCount == 0 && g.CoAuthorCount == 0 && g.ReaderCount == 0);
        Assert.Contains(groupRoleCounts, g => g.GroupId == 3 && g.AdministratorCount == 1 && g.ModeratorCount == 1 && g.CoAuthorCount == 0 && g.ReaderCount == 0);
        Assert.Contains(groupRoleCounts, g => g.GroupId == 4 && g.AdministratorCount == 1 && g.ModeratorCount == 0 && g.CoAuthorCount == 0 && g.ReaderCount == 1);
    }

    ///<summary>
    /// 6. Проверка: Вывести информацию о группах, в которых опубликовано максимальное число записей.
    ///</summary>
    [Fact]
    public void GetGroupsWithMaxPosts()
    {
        var maxPostCount = TestDatabase.GroupPosts
            .GroupBy(p => p.GroupId)
            .Max(g => g.Count());

        var groupsWithMaxPosts = TestDatabase.GroupPosts
            .GroupBy(p => p.GroupId)
            .Where(g => g.Count() == maxPostCount)
            .Select(g => g.Key)
            .ToList();

        Assert.NotEmpty(groupsWithMaxPosts);
        Assert.Contains(groupsWithMaxPosts, g => g == 2);
    }
}