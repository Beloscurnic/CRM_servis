using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Delet_Equipment
{
    public partial class Delet_Equipment
    {
       public class Command : IRequest
        {
            public int ID_Order { get; set; }
            public int ID_Accessories { get; set; }
        }
    }
}
