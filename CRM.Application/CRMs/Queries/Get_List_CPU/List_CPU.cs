using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_List_CPU
{
    public partial class Get_List_CPU
    {
        public class List_CPU : IMap_With<Central_processing>
        {
            public Guid ID_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price_CPU { get; set; }
            public int Quantity_CPU { get; set; }
            public int Number_Cores { get; set; }
            public string Purity_CPU { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Central_processing, List_CPU>()
                    .ForMember(ordervm => ordervm.ID_Сomponent, opt => opt.MapFrom(order => order.ID_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.Price_CPU, opt => opt.MapFrom(order => order.Price_CPU))
                    .ForMember(ordervm => ordervm.Quantity_CPU, opt => opt.MapFrom(order => order.Quantity_CPU))
                    .ForMember(ordervm => ordervm.Number_Cores, opt => opt.MapFrom(order => order.Number_Cores))
                    .ForMember(ordervm => ordervm.Purity_CPU, opt => opt.MapFrom(order => order.Purity_CPU));
            }
        }
    }
}
