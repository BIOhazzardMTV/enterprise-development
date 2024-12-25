namespace Server.Dto;

public class GroupPostCountDto
{
    ///<summary>
    /// Запись
    ///</summary>
    public PostDto? Post { get; set; }

    ///<summary>
    /// Число записей в группе
    ///</summary>
    public int PostCount { get; set; }
}
