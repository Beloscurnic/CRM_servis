using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Delet_services
{
    public partial class Delet_Services
    {
       public class Command : IRequest
        {
            public int ID_Services { get; set; }
        }
    }
}
