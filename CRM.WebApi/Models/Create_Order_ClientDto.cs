using CRM.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Application.CRMs.Commands.Create_Order;
using AutoMapper;
namespace CRM.WebApi.Models
{
    public class Create_Order_ClientDto: IMap_With<Create_Order_Client_Command>
    {
        public Guid ID_Client { get; set; }
        public string Name_Client { get; set; }
        public string LastName_Client { get; set; }
        public string Email_Client { get; set; }
        public string Telefon { get; set; }
        public string Type_technology { get; set; }
        public string Model_technology { get; set; }
        public string Breaking_info { get; set; }
        public string Quipment_info { get; set; }
        public string Status_Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_Order_ClientDto, Create_Order_Client_Command>()
                .ForMember(order_command => order_command.ID_Client, opt => opt.MapFrom(order_Dto => order_Dto.ID_Client))
                .ForMember(order_command => order_command.Name_Client, opt => opt.MapFrom(order_Dto => order_Dto.Name_Client))
                .ForMember(order_command => order_command.LastName_Client, opt => opt.MapFrom(order_Dto => order_Dto.LastName_Client))
                .ForMember(order_command => order_command.Email_Client, opt => opt.MapFrom(order_Dto => order_Dto.Email_Client))
                .ForMember(order_command => order_command.Telefon, opt => opt.MapFrom(order_Dto => order_Dto.Telefon))
                .ForMember(order_command => order_command.Type_technology, opt => opt.MapFrom(order_Dto => order_Dto.Type_technology))
                .ForMember(order_command => order_command.Model_technology, opt => opt.MapFrom(order_Dto => order_Dto.Model_technology))
                .ForMember(order_command => order_command.Breaking_info, opt => opt.MapFrom(order_Dto => order_Dto.Breaking_info))
                .ForMember(order_command => order_command.Quipment_info, opt => opt.MapFrom(order_Dto => order_Dto.Quipment_info))
                .ForMember(order_command => order_command.Status_Order, opt => opt.MapFrom(order_Dto => order_Dto.Status_Order));

        }
    }
}
