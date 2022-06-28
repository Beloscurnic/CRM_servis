using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Delet_Equipment;

namespace CRM.WebApi.Models
{
    public class Delet_EquipmentDto: IMap_With<Delet_Equipment.Command>
    {
        public int ID_Order { get; set; }
        public int ID_Accessories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delet_EquipmentDto, Delet_Equipment.Command>()
                .ForMember(ordercommand => ordercommand.ID_Accessories, opt => opt.MapFrom(orderdto => orderdto.ID_Accessories))
                .ForMember(ordercommand => ordercommand.ID_Order, opt => opt.MapFrom(orderdto => orderdto.ID_Order));

        }
    }
}
