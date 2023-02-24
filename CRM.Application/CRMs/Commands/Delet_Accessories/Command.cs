using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Delet_Accessories
{
    public partial class Delet_Accessories
    {
       public class Command : IRequest
        {
            public int ID_Accessories { get; set; }
        }
    }
}
