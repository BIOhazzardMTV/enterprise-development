namespace Server.DTO;

public class GroupPostCountDTO
{
    ///<summary>
    /// Запись
    ///</summary>
    public PostDTO? Post { get; set; }

    ///<summary>
    /// Число записей в группе
    ///</summary>
    public int PostCount { get; set; }
}
