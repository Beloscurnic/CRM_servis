using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;


namespace CRM.Application.CRMs.Queries.Get_List_Services
{
    public partial class Get_List_services
    {
       public class List_Services : IMap_With<Services_rendered>
        {
            public int ID_Services { get; set; }
            public int ID_Order { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price_services { get; set; }
            public string Warranty { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Services_rendered, List_Services>()
                    .ForMember(ordervm => ordervm.ID_Services, opt => opt.MapFrom(order => order.ID_Services))
                    .ForMember(ordervm => ordervm.ID_Order, opt => opt.MapFrom(order => order.ID_Order))
                    .ForMember(ordervm => ordervm.Name, opt => opt.MapFrom(order => order.Name))
                    .ForMember(ordervm => ordervm.Description, opt => opt.MapFrom(order => order.Description))
                     .ForMember(ordervm => ordervm.Warranty, opt => opt.MapFrom(order => order.Warranty))
                    .ForMember(ordervm => ordervm.Price_services, opt => opt.MapFrom(order => order.Price_services));
            }
        }
    }
}
