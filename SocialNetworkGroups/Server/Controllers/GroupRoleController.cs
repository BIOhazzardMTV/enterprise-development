using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupRoleController(IRepository<GroupRole> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех ролей групп
    /// </summary>
    /// <returns>Список всех ролей групп и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupRole>>> Get()
    {
        var groupRoles = await repository.GetAll();
        return Ok(groupRoles);
    }

    /// <summary>
    /// Вовзращает роль пользователя в группе по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Роль пользователя в группе и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupRole>> Get(int id)
    {
        var groupRole = await repository.Get(id);
        if (groupRole == null) return NotFound();

        return Ok(groupRole);
    }

    /// <summary>
    /// Добавляет роль пользователя в группе с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемая роль пользователя в группе </param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GroupRoleDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var groupRole = mapper.Map<GroupRole>(value);
        await repository.Add(groupRole);

        return Ok();
    }

    /// <summary>
    /// Заменяет роль пользователя в группе с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемой роли пользователя в группе </param>
    /// <param name="value">Заменяющая роль пользователя в группе </param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] GroupRoleDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingGroupRole = await repository.Get(id);
        if (existingGroupRole == null) return NotFound();
        var groupRole = mapper.Map<GroupRole>(value);
        groupRole.Id = id;
        await repository.Replace(groupRole, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет роль пользователя в группе с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор роли пользователя в группе </param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var groupRole = await repository.Get(id);
        if (groupRole == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
