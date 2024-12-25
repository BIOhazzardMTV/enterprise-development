using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
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
        var posts = await repository.GetAll();
        return Ok(posts);
    }

    /// <summary>
    /// Вовзращает запись по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns>Запись и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> Get(int id)
    {
        var post = await repository.Get(id);
        if (post == null) return NotFound();

        return Ok(post);
    }

    /// <summary>
    /// Добавляет запись с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемая запись</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PostDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var post = mapper.Map<Post>(value);
        await repository.Add(post);

        return Ok();
    }

    /// <summary>
    /// Заменяет запись с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемой записи</param>
    /// <param name="value">Заменяющая запись</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] PostDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingPost = await repository.Get(id);
        if (existingPost == null) return NotFound();
        var post = mapper.Map<Post>(value);
        post.Id = id;
        await repository.Replace(post, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет запись с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await repository.Get(id);
        if (post == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
