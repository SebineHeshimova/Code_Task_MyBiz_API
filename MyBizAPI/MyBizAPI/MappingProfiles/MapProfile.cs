using AutoMapper;
using MyBizAPI.DTOs.BookDTOs;
using MyBizAPI.DTOs.PositionDTOs;
using MyBizAPI.Entity;

namespace MyBizAPI.MappingProfiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<Position, CreatePositionDTO>().ReverseMap();
            CreateMap<Position, UpdatePositionDTO>().ReverseMap();
            CreateMap<Position, GetPositionDTO>().ReverseMap();
        }
    }
}
