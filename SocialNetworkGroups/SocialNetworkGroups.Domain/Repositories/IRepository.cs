﻿namespace SocialNetworkGroups.Domain.Repositories;

public interface IRepository<T>
{
    /// <summary>
    /// Возвращает список всех объектов
    /// </summary>
    /// <returns>Список всех объектов</returns>
    public Task<List<T>> GetAll();

    /// <summary>
    /// Возвращает объект по указанному идентификатору
    /// </summary>
    /// <param name="Id">Идентификатор объекта</param>
    /// <returns>Найденный объект, или null</returns>
    public Task<T?> Get(int Id);

    /// <summary>
    /// Добавляет новый объект
    /// </summary>
    /// <param name="obj">Новый объект</param>
    public Task Add(T obj);

    /// <summary>
    /// Заменяет объект, соответствующий идентификатору, на новый
    /// </summary>
    /// <param name="obj">Новый объект</param>
    /// <param name="Id">Идентификатор объекта</param>
    /// <returns>true, если замена прошла успешно, иначе false</returns>
    public Task Replace(T obj, int Id);

    /// <summary>
    /// Удаляет объект, соответствующий идентификатору
    /// </summary>
    /// <param name="Id">Идентификатор объекта</param>
    /// <returns>true, если удаление прошло успешно, иначе false</returns>
    public Task Delete(int Id);
}