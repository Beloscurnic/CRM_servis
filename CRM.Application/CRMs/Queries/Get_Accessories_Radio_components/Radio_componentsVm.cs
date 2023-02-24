using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Radio_components
{
    public partial class Get_Accessories_Radio_components
    {
        public class Radio_componentsVm : IMap_With<Radio_component>
        {
            public Guid ID_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price { get; set; }
            public string options { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Radio_component, Radio_componentsVm>()
                    .ForMember(ordervm => ordervm.ID_Сomponent, opt => opt.MapFrom(order => order.ID_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.Price, opt => opt.MapFrom(order => order.Price))
                    .ForMember(ordervm => ordervm.options, opt => opt.MapFrom(order => order.options));
            }
        }
    }
}
