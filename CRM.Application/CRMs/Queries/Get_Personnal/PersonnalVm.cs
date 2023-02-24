using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_Personnal
{

    public class PersonnalVm : IMap_With<Personnel_Data>
    {
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Personnel_Data, PersonnalVm>()
                .ForMember(ordervm => ordervm.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(ordervm => ordervm.Last_Name, opt => opt.MapFrom(order => order.Last_Name))
                .ForMember(ordervm => ordervm.Email, opt => opt.MapFrom(order => order.Email))
                .ForMember(ordervm => ordervm.Position, opt => opt.MapFrom(order => order.Position))
                .ForMember(ordervm => ordervm.Telefon, opt => opt.MapFrom(order => order.Telefon));
        }
    }
    
}
