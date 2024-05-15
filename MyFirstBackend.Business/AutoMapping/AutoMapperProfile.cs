using AutoMapper;
using MyFirstBackend.Business.Models.Requests;
using MyFirstBackend.Business.Models.Responses;
using MyFirstBackend.Core.Dtos;

namespace MyFirstBackend.Business.Automapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, CreateUserRequest>();
            CreateMap<UserDto, LoginUserRequest>();
            CreateMap<UserDto, ExchangeDevicesRequest>();
            CreateMap<DeviceDto, DeviceResponse>();
            CreateMap<UserDto, UserResponse>();
        }
    }

}
