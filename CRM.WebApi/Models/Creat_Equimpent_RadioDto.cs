using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Creat_Equipment;
using CRM.Application.CRMs.Commands.Creat_Equipment_radio;

namespace CRM.WebApi.Models
{
    public class Creat_Equimpent_RadioDto : IMap_With<Creat_Equipment_radio.Command>
    {
        public int ID_Order { get; set; }
        public string Name_Сomponent { get; set; }
        public int quintity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Creat_Equimpent_RadioDto, Creat_Equipment_radio.Command>()
                .ForMember(command => command.ID_Order, opt => opt.MapFrom(Dto => Dto.ID_Order))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.quintity, opt => opt.MapFrom(Dto => Dto.quintity));

        }
    }
}
