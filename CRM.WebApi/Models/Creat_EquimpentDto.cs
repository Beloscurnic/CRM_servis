using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Creat_Equipment;

namespace CRM.WebApi.Models
{
    public class Creat_EquimpentDto : IMap_With<Create_Equipment.Command>
    {
        public int ID_Order { get; set; }
        public int ID_Accessories { get; set; }
        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Creat_EquimpentDto, Create_Equipment.Command>()
                  .ForMember(command => command.ID_Order, opt => opt.MapFrom(Dto => Dto.ID_Order))
                .ForMember(command => command.ID_Accessories, opt => opt.MapFrom(Dto => Dto.ID_Accessories))
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company));

        }
    }
}
