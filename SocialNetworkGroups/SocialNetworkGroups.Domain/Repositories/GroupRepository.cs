using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain.Repositories;

public class GroupRepository(SocialNetworkGroupsContext context) : IRepository<Group>
{
    public async Task<List<Group>> GetAll() => await context.Groups.ToListAsync();

    public async Task<Group?> Get(int Id) => await context.Groups.FirstOrDefaultAsync(u => u.Id == Id);

    public async Task Add(Group obj)
    {
        await context.Groups.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Replace(Group obj, int id)
    {
        var oldGroup = await Get(id);
        if (oldGroup == null)
            return;

        oldGroup.Title = obj.Title;
        oldGroup.Description = obj.Description;
        oldGroup.CreationDate = obj.CreationDate;
        oldGroup.AuthorId = obj.AuthorId;
        context.Groups.Update(oldGroup);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedGroup = await Get(id);
        if (deletedGroup == null)
            return;

        context.Groups.Remove(deletedGroup);
        await context.SaveChangesAsync();
    }
}
