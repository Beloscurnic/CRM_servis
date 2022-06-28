using AutoMapper;
using System;
using CRM.Application.Common.Mapping;
using CRM.Domain;

namespace CRM.Application.CRMs.Queries.Get_List_Personnal
{
   
        public class List_Personnal : IMap_With<Personnel_Data>
        {
            public Guid ID_Personnal { get; set; }
            public string Name { get; set; }
            public string Last_Name { get; set; }
            public string Telefon { get; set; }
            public string Position { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Personnel_Data, List_Personnal>()
                .ForMember(orderlist => orderlist.ID_Personnal, opt => opt.MapFrom(order => order.ID_Personnal))
                .ForMember(orderlist => orderlist.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(orderlist => orderlist.Last_Name, opt => opt.MapFrom(order => order.Last_Name))             
                .ForMember(orderlist => orderlist.Telefon, opt => opt.MapFrom(order => order.Telefon))
                .ForMember(orderlist => orderlist.Position, opt => opt.MapFrom(order => order.Position));

            }
        }
    
}
