
using AutoMapper;
using System;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_List_Order_Client_Details
{
   public class List_Order_Client: IMap_With<Order_Client>
    {
        public int ID_Order { get; set; }
      
        public string Name_Client { get; set; }
        public string LastName_Client { get; set; }
        public string Email_Client { get; set; }
        public string Telefon { get; set; }
        public int Price { get; set; }
        public string Status_Order { get; set; }
        public DateTime? Receipt_date { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Order_Client, List_Order_Client>()
            .ForMember(orderlist => orderlist.ID_Order, opt => opt.MapFrom(order => order.ID_Order))
            .ForMember(orderlist => orderlist.Name_Client, opt => opt.MapFrom(order => order.Name_Client))
            .ForMember(orderlist => orderlist.LastName_Client, opt => opt.MapFrom(order => order.LastName_Client))
            .ForMember(orderlist => orderlist.Email_Client, opt => opt.MapFrom(order => order.Email_Client))
            .ForMember(orderlist => orderlist.Telefon, opt => opt.MapFrom(order => order.Telefon))
            .ForMember(orderlist => orderlist.Price, opt => opt.MapFrom(order => order.Price))
            .ForMember(orderlist => orderlist.Status_Order, opt => opt.MapFrom(order => order.Status_Order))
            .ForMember(orderlist => orderlist.Receipt_date, opt => opt.MapFrom(order => order.Receipt_date));

        }
    }
}
