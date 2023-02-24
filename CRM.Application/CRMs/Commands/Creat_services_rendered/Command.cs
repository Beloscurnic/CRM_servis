using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Creat_services_rendered
{
    public partial class Creat_services
    {
       public class Command : IRequest<int>
        {
            public int ID_Services { get; set; }
            public int ID_Order { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Warranty { get; set; }
            public int Price_services { get; set; }
        }

    }
}
