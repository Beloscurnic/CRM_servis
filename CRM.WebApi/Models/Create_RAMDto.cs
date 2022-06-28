using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Create_RAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.WebApi.Models
{
    public class Create_RAMDto : IMap_With<Create_RAM.Command>
    {
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }
        public string memory_type { get; set; }
        public string Form_factor { get; set; }
        public string Memory_module_key { get; set; }
        public string Volume { get; set; }
        public string Clock_frequency { get; set; }
        public string Timing { get; set; }

        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_RAMDto, Create_RAM.Command>()
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.Price, opt => opt.MapFrom(Dto => Dto.Price))
                .ForMember(command => command.memory_type, opt => opt.MapFrom(Dto => Dto.memory_type))
                .ForMember(command => command.Form_factor, opt => opt.MapFrom(Dto => Dto.Form_factor))
                .ForMember(command => command.Memory_module_key, opt => opt.MapFrom(Dto => Dto.Memory_module_key))
                .ForMember(command => command.Volume, opt => opt.MapFrom(Dto => Dto.Volume))
                .ForMember(command => command.Clock_frequency, opt => opt.MapFrom(Dto => Dto.Clock_frequency))
                .ForMember(command => command.Timing, opt => opt.MapFrom(Dto => Dto.Timing));
        }
    }
}
