using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using static CRM.Application.CRMs.Commands.Update_Provider.Update_Provider;

namespace CRM.WebApi.Models
{
    public class Update_ProviderDto : IMap_With<Command>
    {
        public string Name_Company { get; set; }
        public string Status { get; set; }
       

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Update_ProviderDto, Command>()
            .ForMember(ordercommand => ordercommand.Name_Company, opt => opt.MapFrom(orderdto => orderdto.Name_Company))
         
            .ForMember(ordercommand => ordercommand.Status, opt => opt.MapFrom(orderdto => orderdto.Status));

        }
    }
}
