using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Create_Radio_components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRM.WebApi.Models
{
    public class Create_Radio_componentsDto : IMap_With<Create_Radio_components.Command>
    {
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }
        public string options { get; set; }
        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_Radio_componentsDto, Create_Radio_components.Command>()
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.Price, opt => opt.MapFrom(Dto => Dto.Price))
                .ForMember(command => command.options, opt => opt.MapFrom(Dto => Dto.options));
        }
    }
}
