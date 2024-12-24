using AutoMapper;
using SocialNetworkGroups.Domain;
using Server.DTO;
using System.Xml;

namespace Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Group, GroupDTO>().ReverseMap();
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<GroupRole, GroupRoleDTO>().ReverseMap();
    }
}