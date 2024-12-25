using AutoMapper;
using SocialNetworkGroups.Domain;
using Server.Dto;

namespace Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<GroupRole, GroupRoleDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
    }
}