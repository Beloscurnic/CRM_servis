using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Type
{
    public partial class Get_Type_Accessories
    {
      public  class Type_AccessoriesVm : IMap_With<Accessories>
        {
            public string Type_Сomponent { get; set; }
            public void Mapping(Profile profile)
            {
                profile.CreateMap<Accessories, Type_AccessoriesVm>()

                    .ForMember(ordervm => ordervm.Type_Сomponent, opt => opt.MapFrom(order => order.Type_Сomponent));
            }
        }
    }
}
