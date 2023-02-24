using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Create_RAM
{
    public partial class Create_RAM
    {
       public class Command : IRequest<int>
        {
            public int ID_Accessories { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price { get; set; }
            public string memory_type { get; set; }
            public string Form_factor { get; set; }
            public string Memory_module_key { get; set; }
            public string Volume { get; set; }
            public string Clock_frequency { get; set; }
            public string Timing { get; set; }

            public string Name_Company { get; set; }
            public int ID_Provider { get; set; }
        }
    }
}
