using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController(IRepository<Group> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех групп
    /// </summary>
    /// <returns>Список всех групп и http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> Get()
    {
        var groups = await repository.GetAll();
        return Ok(groups);
    }

    /// <summary>
    /// Вовзращает группу по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор группы</param>
    /// <returns>Группа и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> Get(int id)
    {
        var group = await repository.Get(id);
        if (group == null) return NotFound();

        return Ok(group);
    }

    /// <summary>
    /// Добавляет группу с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемая группа</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GroupDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var group = mapper.Map<Group>(value);
        await repository.Add(group);

        return Ok();
    }

    /// <summary>
    /// Заменяет группу с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемой группы</param>
    /// <param name="value">Заменяющая группа</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] GroupDto value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingGroup = await repository.Get(id);
        if (existingGroup == null) return NotFound();
        var group = mapper.Map<Group>(value);
        group.Id = id;
        await repository.Replace(group, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет группу с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор группы</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var group = await repository.Get(id);
        if (group == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
