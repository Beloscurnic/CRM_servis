using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Create_Motherboard
{
    public partial class Create_Motherboard
    {
       public class Command : IRequest<int>
        {
            public int ID_Accessories { get; set; }
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
            public int ID_Provider { get; set; }
        }
    }
}
