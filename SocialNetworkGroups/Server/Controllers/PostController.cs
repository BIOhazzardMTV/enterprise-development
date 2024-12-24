using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IRepository<Post> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех записей
    /// </summary>
    /// <returns>Список всех записей и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> Get()
    {
        var Posts = await repository.GetAll();
        return Ok(Posts);
    }

    /// <summary>
    /// Вовзращает запись по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns>Запись и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(int id)
    {
        var Post = await repository.Get(id);
        if (Post == null) return NotFound();

        return Ok(Post);
    }

    /// <summary>
    /// Добавляет запись с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемая запись</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PostDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var Post = mapper.Map<Post>(value);
        await repository.Add(Post);

        return Ok();
    }

    /// <summary>
    /// Заменяет запись с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемой записи</param>
    /// <param name="value">Заменяющая запись</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] PostDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingPost = await repository.Get(id);
        if (existingPost == null) return NotFound();
        var Post = mapper.Map<Post>(value);
        Post.Id = id;
        await repository.Replace(Post, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет запись с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var Post = await repository.Get(id);
        if (Post == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
