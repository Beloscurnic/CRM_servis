using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Creat_Delivery;

namespace CRM.WebApi.Models
{
    public class Creat_DeliveryDto : IMap_With<Create_Delivery.Command>
    {
        public int ID_Accessories { get; set; }
        public Guid ID_Сomponent { get; set; }
        public string Name_Сomponent { get; set; }
        public string Type_Сomponent { get; set; }
        public int Price_Сomponent { get; set; }
        public int Quantity_Сomponent { get; set; }
        public string Issue_date { get; set; }
        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Creat_DeliveryDto, Create_Delivery.Command>()
                .ForMember(command => command.ID_Accessories, opt => opt.MapFrom(Dto => Dto.ID_Accessories))
                .ForMember(command => command.ID_Сomponent, opt => opt.MapFrom(Dto => Dto.ID_Сomponent))
                .ForMember(command => command.Type_Сomponent, opt => opt.MapFrom(Dto => Dto.Type_Сomponent))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.Quantity_Сomponent, opt => opt.MapFrom(Dto => Dto.Quantity_Сomponent))
                .ForMember(command => command.Issue_date, opt => opt.MapFrom(Dto => Dto.Issue_date))
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Price_Сomponent, opt => opt.MapFrom(Dto => Dto.Price_Сomponent));

        }
    }
}
