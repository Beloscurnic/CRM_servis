using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;
using System;

namespace CRM.Application.CRMs.Queries.Get_Accessories_RAM
{
    public partial class Get_Accessories_RAM
    {
        public class Accessories_RAMVm : IMap_With<Random_Access_Memory>
        {
            public Guid ID_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price { get; set; }
            public string memory_type { get; set; }
            public string Form_factor { get; set; }
            public string Memory_module_key { get; set; }
            public string Volume { get; set; }
            public string Clock_frequency { get; set; }
            public string Timing { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Random_Access_Memory, Accessories_RAMVm>()
                    .ForMember(ordervm => ordervm.ID_Сomponent, opt => opt.MapFrom(order => order.ID_Сomponent))
                    .ForMember(ordervm => ordervm.Name_Сomponent, opt => opt.MapFrom(order => order.Name_Сomponent))
                    .ForMember(ordervm => ordervm.Price, opt => opt.MapFrom(order => order.Price))
                    .ForMember(ordervm => ordervm.memory_type, opt => opt.MapFrom(order => order.memory_type))
                    .ForMember(ordervm => ordervm.Form_factor, opt => opt.MapFrom(order => order.Form_factor))
                    .ForMember(ordervm => ordervm.Memory_module_key, opt => opt.MapFrom(order => order.Memory_module_key))
                    .ForMember(ordervm => ordervm.Volume, opt => opt.MapFrom(order => order.Volume))
                    .ForMember(ordervm => ordervm.Clock_frequency, opt => opt.MapFrom(order => order.Clock_frequency))
                    .ForMember(ordervm => ordervm.Timing, opt => opt.MapFrom(order => order.Timing));
            }
        }
    }
}
