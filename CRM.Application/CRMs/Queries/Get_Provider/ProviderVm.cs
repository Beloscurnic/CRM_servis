using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_Provider
{
    public partial class Get_Provider2
    {
       public class ProviderVm : IMap_With<Provider>
        {
            public int ID_Provider { get; set; }
            public string Name_Company { get; set; }
            public string Identification_Number { get; set; }
            public string Supplier_Address { get; set; }
            public string FIO_Director { get; set; }
            public string Telefon { get; set; }
            public string Status { get; set; }
            public string Comments { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Provider, ProviderVm>()
                    .ForMember(ordervm => ordervm.ID_Provider, opt => opt.MapFrom(order => order.ID_Provider))
                    .ForMember(ordervm => ordervm.Name_Company, opt => opt.MapFrom(order => order.Name_Company))
                    .ForMember(ordervm => ordervm.Identification_Number, opt => opt.MapFrom(order => order.Identification_Number))
                    .ForMember(ordervm => ordervm.Supplier_Address, opt => opt.MapFrom(order => order.Supplier_Address))
                    .ForMember(ordervm => ordervm.FIO_Director, opt => opt.MapFrom(order => order.FIO_Director))
                 .ForMember(ordervm => ordervm.Status, opt => opt.MapFrom(order => order.Status))
                  .ForMember(ordervm => ordervm.Telefon, opt => opt.MapFrom(order => order.Telefon))
                 .ForMember(ordervm => ordervm.Comments, opt => opt.MapFrom(order => order.Comments));
            }
        }
    }
}
