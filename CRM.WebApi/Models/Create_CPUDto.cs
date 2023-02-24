using AutoMapper;
using CRM.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CRM.Application.CRMs.Commands.Create_Accessories.Create_CPU;

namespace CRM.WebApi.Models
{
    public class Create_CPUDto : IMap_With<Command>
    {
        public string Name_Сomponent { get; set; }
        public int Price_CPU { get; set; }
        public int Quantity_CPU { get; set; }
        public int Number_Cores { get; set; }
        public string Purity_CPU { get; set; }
        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_CPUDto, Command>()
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.Price_CPU, opt => opt.MapFrom(Dto => Dto.Price_CPU))
                .ForMember(command => command.Number_Cores, opt => opt.MapFrom(Dto => Dto.Number_Cores))
                 .ForMember(command => command.Quantity_CPU, opt => opt.MapFrom(Dto => Dto.Quantity_CPU))
                .ForMember(command => command.Purity_CPU, opt => opt.MapFrom(Dto => Dto.Purity_CPU));
        }
    }
}
