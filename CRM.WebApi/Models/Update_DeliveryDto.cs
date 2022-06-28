using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Update_Provider;

namespace CRM.WebApi.Models
{
    public class Update_DeliveryDto : IMap_With<Update_Delivery.Command>
    {
        public int ID_Delevery { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Update_DeliveryDto, Update_Delivery.Command>()
            .ForMember(ordercommand => ordercommand.ID_Delevery, opt => opt.MapFrom(orderdto => orderdto.ID_Delevery));

        }
    }
}
