using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Creat_services_rendered;

namespace CRM.WebApi.Models
{
    public class Creat_servicesDto : IMap_With<Creat_services.Command>
    {
        public int ID_Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price_services { get; set; }
        public string Warranty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Creat_servicesDto, Creat_services.Command>()
                .ForMember(command => command.ID_Order, opt => opt.MapFrom(Dto => Dto.ID_Order))
                .ForMember(command => command.Name, opt => opt.MapFrom(Dto => Dto.Name))
                .ForMember(command => command.Description, opt => opt.MapFrom(Dto => Dto.Description))
                  .ForMember(command => command.Warranty, opt => opt.MapFrom(Dto => Dto.Warranty))
                .ForMember(command => command.Price_services, opt => opt.MapFrom(Dto => Dto.Price_services));
        }
    }
}
