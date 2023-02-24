using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Update_Accessories;

namespace CRM.WebApi.Models
{
    public class Update_AccessoriesDto : IMap_With<Update_Accessories.Command>
    
    {
        public int ID_Accessories { get; set; }
        public string Сharacteristics_info { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Update_AccessoriesDto, Update_Accessories.Command>()
            .ForMember(ordercommand => ordercommand.ID_Accessories, opt => opt.MapFrom(orderdto => orderdto.ID_Accessories))
            .ForMember(ordercommand => ordercommand.Сharacteristics_info, opt => opt.MapFrom(orderdto => orderdto.Сharacteristics_info));

        }
    }
}
