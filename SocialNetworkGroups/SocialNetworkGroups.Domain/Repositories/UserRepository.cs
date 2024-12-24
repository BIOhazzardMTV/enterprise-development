using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain.Repositories;

public class UserRepository (SocialNetworkGroupsContext context) : IRepository<User>
{
    public async Task<List<User>> GetAll() => await context.Users.ToListAsync();

    public async Task<User?> Get(int Id) => await context.Users.FirstOrDefaultAsync(u => u.Id == Id);

    public async Task Add(User obj)
    {
        await context.Users.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Replace(User obj, int Id)
    {
        var oldUser = await Get(Id);
        if (oldUser == null) return;

        oldUser.FullName = obj.FullName;
        oldUser.Gender = obj.Gender;
        oldUser.DateOfBirth = obj.DateOfBirth;
        oldUser.RegistrationDate = obj.RegistrationDate;
        context.Users.Update(oldUser);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int Id)
    {
        var deletedUser = await Get(Id);
        if (deletedUser == null) return;

        context.Users.Remove(deletedUser);
        await context.SaveChangesAsync();
    }
}
