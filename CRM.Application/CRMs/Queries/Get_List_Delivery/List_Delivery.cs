using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;


namespace CRM.Application.CRMs.Queries.Get_List_Delivery
{
    public partial class Get_List_Delivery
    {
       public class List_Delivery : IMap_With<Delivery>
        {
            public int ID_Delevery { get; set; }
            public string Name_Company { get; set; }
            public int ID_Accessories { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price_Сomponent { get; set; }
            public int Quantity_Сomponent { get; set; }
            public int Summa { get; set; }
            public DateTime Receipt_date { get; set; }
            public string Issue_date { get; set; }
            public string Status { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Delivery, List_Delivery>()
                     .ForMember(ordervm => ordervm.Issue_date, opt => opt.MapFrom(order => order.Issue_date))
                     .ForMember(ordervm => ordervm.Receipt_date, opt => opt.MapFrom(order => order.Receipt_date))
                     .ForMember(ordervm => ordervm.Summa, opt => opt.MapFrom(order => order.Summa))
                     .ForMember(ordervm => ordervm.Quantity_Сomponent, opt => opt.MapFrom(order => order.Quantity_Сomponent))
                     .ForMember(ordervm => ordervm.Price_Сomponent, opt => opt.MapFrom(order => order.Price_Сomponent))
                     .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                     .ForMember(ordervm => ordervm.ID_Accessories, opt => opt.MapFrom(order => order.ID_Accessories))
                     .ForMember(ordervm => ordervm.ID_Delevery, opt => opt.MapFrom(order => order.ID_Delevery))
                      .ForMember(ordervm => ordervm.Name_Company, opt => opt.MapFrom(order => order.Name_Company))
                    .ForMember(ordervm => ordervm.Status, opt => opt.MapFrom(order => order.Status));
              

            }
        }
    }
}
