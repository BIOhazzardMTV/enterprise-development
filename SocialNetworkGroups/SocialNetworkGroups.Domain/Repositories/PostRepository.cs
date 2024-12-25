using Microsoft.EntityFrameworkCore;

namespace SocialNetworkGroups.Domain.Repositories;

public class PostRepository(SocialNetworkGroupsContext context) : IRepository<Post>
{
    public async Task<List<Post>> GetAll() => await context.Posts.ToListAsync();

    public async Task<Post?> Get(int id) => await context.Posts.FirstOrDefaultAsync(p => p.Id == id);

    public async Task Add(Post obj)
    {
        await context.Posts.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Replace(Post obj, int id)
    {
        var oldPost = await Get(id);
        if (oldPost == null)
            return;

        oldPost.Title = obj.Title;
        oldPost.Description = obj.Description;
        oldPost.CreationDate = obj.CreationDate;
        oldPost.GroupId = obj.GroupId;
        oldPost.AuthorId = obj.AuthorId;
        context.Posts.Update(oldPost);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedPost = await Get(id);
        if (deletedPost == null)
            return;

        context.Posts.Remove(deletedPost);
        await context.SaveChangesAsync();
    }
}
