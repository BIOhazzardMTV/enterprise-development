using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository<User> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех пользователей
    /// </summary>
    /// <returns>Список всех пользователей и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await repository.GetAll();
        return Ok(users);
    }

    /// <summary>
    /// Вовзращает пользователя по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Пользователь и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await repository.Get(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    /// <summary>
    /// Добавляет пользователя с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемый пользователь</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = mapper.Map<User>(value);
        await repository.Add(user);

        return Ok();
    }

    /// <summary>
    /// Заменяет пользователя с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемого пользователя</param>
    /// <param name="value">Заменяющий пользователь</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] UserDTO value)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        var existingUser = await repository.Get(id);
        if (existingUser == null) return NotFound();
        var  user = mapper.Map<User>(value);
        user.Id = id;
        await repository.Replace(user, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет пользователя с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await repository.Get(id);
        if (user == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
