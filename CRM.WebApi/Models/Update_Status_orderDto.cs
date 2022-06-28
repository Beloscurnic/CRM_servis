using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Update_status_order;

namespace CRM.WebApi.Models
{
    public class Update_Status_orderDto : IMap_With<Update_status.Command>
    {
        public int ID_Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Update_Status_orderDto, Update_status.Command>()
                .ForMember(ordercommand => ordercommand.ID_Order, opt => opt.MapFrom(orderdto => orderdto.ID_Order));

        }
    }
}
