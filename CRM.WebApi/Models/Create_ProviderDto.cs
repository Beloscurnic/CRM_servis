using CRM.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using static CRM.Application.CRMs.Commands.Create_Provider.Create_Provider;

namespace CRM.WebApi.Models
{
    public class Create_ProviderDto : IMap_With<Command>
    {
        public string Name_Company { get; set; }
        public string Identification_Number { get; set; }
        public string Supplier_Address { get; set; }
        public string FIO_Director { get; set; }
        public string Telefon { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_ProviderDto, Command>()
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Identification_Number, opt => opt.MapFrom(Dto => Dto.Identification_Number))
                .ForMember(command => command.FIO_Director, opt => opt.MapFrom(Dto => Dto.FIO_Director))
                .ForMember(command => command.Supplier_Address, opt => opt.MapFrom(Dto => Dto.Supplier_Address))
                .ForMember(command => command.Status, opt => opt.MapFrom(Dto => Dto.Status))
                .ForMember(command => command.Telefon, opt => opt.MapFrom(Dto => Dto.Telefon))
                .ForMember(command => command.Comments, opt => opt.MapFrom(Dto => Dto.Comments));
        }
    }
}
