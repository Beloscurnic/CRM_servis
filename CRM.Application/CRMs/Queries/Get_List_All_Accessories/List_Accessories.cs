using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_List_All_Accessories
{
    public partial class Get_List_All_Accessories
    {
       public class List_Accessories : IMap_With<Accessories>
        {
            public int ID_Accessories { get; set; }
            public string Type_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public string Сharacteristics_info { get; set; }
            public int Quantity_Сomponent { get; set; }
            public int Price_Сomponent { get; set; }        
            public string Name_Company { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Accessories, List_Accessories>()
                    .ForMember(ordervm => ordervm.ID_Accessories, opt => opt.MapFrom(order => order.ID_Accessories))
                    .ForMember(ordervm => ordervm.Type_Сomponent, opt => opt.MapFrom(order => order.Type_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.Сharacteristics_info, opt => opt.MapFrom(order => order.Сharacteristics_info))
                    .ForMember(ordervm => ordervm.Quantity_Сomponent, opt => opt.MapFrom(order => order.Quantity_Сomponent))
                    .ForMember(ordervm => ordervm.Price_Сomponent, opt => opt.MapFrom(order => order.Price_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Company, opt => opt.MapFrom(order => order.Name_Company));
            }
        }
    }
}

