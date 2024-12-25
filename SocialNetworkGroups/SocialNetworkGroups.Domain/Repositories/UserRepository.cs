using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain.Repositories;

public class UserRepository (SocialNetworkGroupsContext context) : IRepository<User>
{
    public async Task<List<User>> GetAll() => await context.Users.ToListAsync();

    public async Task<User?> Get(int id) => await context.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task Add(User obj)
    {
        await context.Users.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Replace(User obj, int id)
    {
        var oldUser = await Get(id);
        if (oldUser == null) return;

        oldUser.FullName = obj.FullName;
        oldUser.Gender = obj.Gender;
        oldUser.DateOfBirth = obj.DateOfBirth;
        oldUser.RegistrationDate = obj.RegistrationDate;
        context.Users.Update(oldUser);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedUser = await Get(id);
        if (deletedUser == null) return;

        context.Users.Remove(deletedUser);
        await context.SaveChangesAsync();
    }
}
