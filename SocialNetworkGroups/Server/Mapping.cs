using AutoMapper;
using SocialNetworkGroups.Domain;
using Server.DTO;

namespace Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Group, GroupDTO>().ReverseMap();
        CreateMap<GroupRole, GroupRoleDTO>().ReverseMap();
        CreateMap<Post, PostDTO>().ReverseMap();
    }
}