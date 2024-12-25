using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain.Repositories;

public class GroupRoleRepository(SocialNetworkGroupsContext context) : IRepository<GroupRole>
{
    public async Task<List<GroupRole>> GetAll() => await context.GroupRoles.ToListAsync();

    public async Task<GroupRole?> Get(int id) => await context.GroupRoles.FirstOrDefaultAsync(u => u.Id == id);

    public async Task Add(GroupRole obj)
    {
        await context.GroupRoles.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Replace(GroupRole obj, int id)
    {
        var oldGroupRole = await Get(id);
        if (oldGroupRole == null)
            return;
        oldGroupRole.UserId = obj.UserId;
        oldGroupRole.GroupId = obj.GroupId;
        oldGroupRole.Role = obj.Role;
        context.GroupRoles.Update(oldGroupRole);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedGroupRole = await Get(id);
        if (deletedGroupRole == null)
            return;

        context.GroupRoles.Remove(deletedGroupRole);
        await context.SaveChangesAsync();
    }
}
