using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Update_Ored_Client;

namespace CRM.WebApi.Models
{
    public class Update_Order_ClientDto :IMap_With<Update_Order_Client_Command>
    {
        public int ID_Order { get; set; }
        public string Status_Order { get; set; }
     

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Update_Order_ClientDto, Update_Order_Client_Command>()
                .ForMember(ordercommand => ordercommand.ID_Order, opt => opt.MapFrom(orderdto => orderdto.ID_Order))
                  .ForMember(ordercommand => ordercommand.Status_Order, opt => opt.MapFrom(orderdto => orderdto.Status_Order));
                 
        }
    }
}
