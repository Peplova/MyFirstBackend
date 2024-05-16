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
            CreateMap<CreateUserRequest, UserDto>();
            CreateMap<LoginUserRequest, UserDto>();
            CreateMap<ExchangeDevicesRequest, UserDto>();
            CreateMap<DeviceDto, DeviceResponse>();
            CreateMap<UserDto, UserResponse>();
        }
    }

}
