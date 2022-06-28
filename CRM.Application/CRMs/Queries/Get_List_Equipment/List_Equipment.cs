using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_List_Equipment
{
    public partial class Get_List_Equipment
    {
       public class List_Equipment : IMap_With<Equipment>
        {
            public int ID_Order { get; set; }
            public int ID_Accessories { get; set; }
            public string Name_Сomponent { get; set; }
            public string Type_Сomponent { get; set; }
            public int Price_Сomponent { get; set; }
            public string Name_Company { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Equipment, List_Equipment>()
                    .ForMember(ordervm => ordervm.ID_Accessories, opt => opt.MapFrom(order => order.ID_Accessories))
                    .ForMember(ordervm => ordervm.Type_Сomponent, opt => opt.MapFrom(order => order.Type_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.ID_Order, opt => opt.MapFrom(order => order.ID_Order))
                    .ForMember(ordervm => ordervm.Price_Сomponent, opt => opt.MapFrom(order => order.Price_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Company, opt => opt.MapFrom(order => order.Name_Company));
            }
        }
    }
}

