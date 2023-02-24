using AutoMapper;
using CRM.Application.Common.Mapping;
using CRM.Application.CRMs.Commands.Create_Motherboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CRM.WebApi.Models
{
    public class Create_MotherboardDto : IMap_With<Create_Motherboard.Command>
    {
        public string Name_Сomponent { get; set; }
        public int Price { get; set; }
        public string Motherboard_socket { get; set; }
        public string Motherboard_chipset { get; set; }
        public string RAM { get; set; }
        public string Disk_controllers { get; set; }
        public string Expansion_slots { get; set; }
        public string Net { get; set; }
        public string audio_and_video { get; set; }
        public string Form_factor { get; set; }

        public string Name_Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Create_MotherboardDto, Create_Motherboard.Command>()
                .ForMember(command => command.Name_Company, opt => opt.MapFrom(Dto => Dto.Name_Company))
                .ForMember(command => command.Name_Сomponent, opt => opt.MapFrom(Dto => Dto.Name_Сomponent))
                .ForMember(command => command.Price, opt => opt.MapFrom(Dto => Dto.Price))
                .ForMember(command => command.Motherboard_socket, opt => opt.MapFrom(Dto => Dto.Motherboard_socket))
                .ForMember(command => command.Motherboard_chipset, opt => opt.MapFrom(Dto => Dto.Motherboard_chipset))
                .ForMember(command => command.RAM, opt => opt.MapFrom(Dto => Dto.RAM))
                .ForMember(command => command.Disk_controllers, opt => opt.MapFrom(Dto => Dto.Disk_controllers))
                .ForMember(command => command.Expansion_slots, opt => opt.MapFrom(Dto => Dto.Expansion_slots))
                .ForMember(command => command.Net, opt => opt.MapFrom(Dto => Dto.Net))
                .ForMember(command => command.audio_and_video, opt => opt.MapFrom(Dto => Dto.audio_and_video))
                .ForMember(command => command.Form_factor, opt => opt.MapFrom(Dto => Dto.Form_factor));
        }
    }
}
