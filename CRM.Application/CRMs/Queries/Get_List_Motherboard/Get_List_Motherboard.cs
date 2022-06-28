using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_List_Motherboard
{
    public partial class List_Motherboard
    {
        public class Get_List_Motherboard : IMap_With<Motherboard>
        {
            public Guid ID_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price { get; set; }
            public string Motherboard_socket { get; set; }
            public string RAM { get; set; }
            public string Expansion_slots { get; set; }
            public string Form_factor { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Motherboard, Get_List_Motherboard>()
                    .ForMember(ordervm => ordervm.ID_Сomponent, opt => opt.MapFrom(order => order.ID_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.Price, opt => opt.MapFrom(order => order.Price))
                    .ForMember(ordervm => ordervm.Motherboard_socket, opt => opt.MapFrom(order => order.Motherboard_socket))
                    .ForMember(ordervm => ordervm.RAM, opt => opt.MapFrom(order => order.RAM))
                    .ForMember(ordervm => ordervm.Form_factor, opt => opt.MapFrom(order => order.Form_factor))
                    .ForMember(ordervm => ordervm.Expansion_slots, opt => opt.MapFrom(order => order.Expansion_slots));
            }
        }
    }
}
