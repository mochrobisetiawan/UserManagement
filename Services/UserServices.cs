using AutoMapper;
using UserManagement.Models;

namespace UserManagement
{
    public class UerServices : Profile
    {    
        public UerServices()
        {
            CreateMap<UserDTO, Muser>()
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => $"{src.Username}")
                )
                .ForMember(
                    dest => dest.Fullname,
                    opt => opt.MapFrom(src => $"{src.Fullname}")
                )
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => $"{src.Password}")
                );
        }
    }
}
