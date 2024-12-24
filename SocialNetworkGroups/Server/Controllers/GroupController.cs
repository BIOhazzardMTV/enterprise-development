using AutoMapper;
using SocialNetworkGroups.Domain;
using SocialNetworkGroups.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Server.DTO;
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
        var Groups = await repository.GetAll();
        return Ok(Groups);
    }

    /// <summary>
    /// Вовзращает группу по указанному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор группы</param>
    /// <returns>Группа и http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> Get(int id)
    {
        var Group = await repository.Get(id);
        if (Group == null) return NotFound();

        return Ok(Group);
    }

    /// <summary>
    /// Добавляет группу с указанным идентификатором
    /// </summary>
    /// <param name="value">Добавляемая группа</param>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] GroupDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var Group = mapper.Map<Group>(value);
        await repository.Add(Group);

        return Ok();
    }

    /// <summary>
    /// Заменяет группу с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор заменяемой группы</param>
    /// <param name="value">Заменяющая группа</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Replace(int id, [FromBody] GroupDTO value)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existingGroup = await repository.Get(id);
        if (existingGroup == null) return NotFound();
        var Group = mapper.Map<Group>(value);
        Group.Id = id;
        await repository.Replace(Group, id);

        return Ok();
    }

    /// <summary>
    /// Удаляет группу с указанным идентификатором
    /// </summary>
    /// <param name="id">Идентификатор группы</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var Group = await repository.Get(id);
        if (Group == null) return NotFound();
        await repository.Delete(id);
        return Ok();
    }
}
