using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_Accessories
{
    public partial class Get_Accessories
    {
        public class Info_AccessoriesVm : IMap_With<Accessories>
        {
            public string Сharacteristics_info { get; set; }
            public string Name_Company { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Accessories, Info_AccessoriesVm>()
                       .ForMember(ordervm => ordervm.Сharacteristics_info, opt => opt.MapFrom(order => order.Сharacteristics_info))
                    .ForMember(ordervm => ordervm.Name_Company, opt => opt.MapFrom(order => order.Name_Company));
            }
        }
    }
}
