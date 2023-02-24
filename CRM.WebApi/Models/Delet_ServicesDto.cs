using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Delet_services;

namespace CRM.WebApi.Models
{
    public class Delet_ServicesDto : IMap_With<Delet_Services.Command>
    {
        public int ID_Services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delet_ServicesDto, Delet_Services.Command>()
                .ForMember(ordercommand => ordercommand.ID_Services, opt => opt.MapFrom(orderdto => orderdto.ID_Services));

        }
    }
}
