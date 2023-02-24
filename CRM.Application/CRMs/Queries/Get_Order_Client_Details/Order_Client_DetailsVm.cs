using System;
using System.Collections.Generic;
using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_Order_Client_Details
{
    public class Order_Client_DetailsVm : IMap_With<Order_Client>
    {
        public int ID_Order { get; set; }
        public string Name_Client { get; set; }
        public string LastName_Client { get; set; }
        public string Email_Client { get; set; }
        public string Telefon { get; set; }
        public string Type_technology { get; set; }
        public string Model_technology { get; set; }
        public string Breaking_info { get; set; }
        public string Status_Order { get; set; }
        public Guid ID_Personnel_dispatcher { get; set; }
        public Guid ID_Personnel_master { get; set; }
        public DateTime Receipt_date { get; set; }
        public DateTime? Issue_date { get; set; }
        public int Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order_Client, Order_Client_DetailsVm>()
                .ForMember(ordervm => ordervm.ID_Order, opt => opt.MapFrom(order => order.ID_Order))
                .ForMember(ordervm => ordervm.Name_Client, opt => opt.MapFrom(order => order.Name_Client))
                .ForMember(ordervm => ordervm.LastName_Client, opt => opt.MapFrom(order => order.LastName_Client))
                .ForMember(ordervm => ordervm.Email_Client, opt => opt.MapFrom(order => order.Email_Client))
                .ForMember(ordervm => ordervm.Telefon, opt => opt.MapFrom(order => order.Telefon))
                .ForMember(ordervm => ordervm.Type_technology, opt => opt.MapFrom(order => order.Type_technology))
                .ForMember(ordervm => ordervm.Model_technology, opt => opt.MapFrom(order => order.Model_technology))
                .ForMember(ordervm => ordervm.Breaking_info, opt => opt.MapFrom(order => order.Breaking_info))
                .ForMember(ordervm => ordervm.Status_Order, opt => opt.MapFrom(order => order.Status_Order))
                .ForMember(ordervm => ordervm.ID_Personnel_dispatcher, opt => opt.MapFrom(order => order.ID_Personnel_dispatcher))
                .ForMember(ordervm => ordervm.ID_Personnel_master, opt => opt.MapFrom(order => order.ID_Personnel_master))
                .ForMember(ordervm => ordervm.Receipt_date, opt => opt.MapFrom(order => order.Receipt_date))
                .ForMember(ordervm => ordervm.Issue_date, opt => opt.MapFrom(order => order.Issue_date))
                .ForMember(ordervm => ordervm.Price, opt => opt.MapFrom(order => order.Price));
        }
    }
}