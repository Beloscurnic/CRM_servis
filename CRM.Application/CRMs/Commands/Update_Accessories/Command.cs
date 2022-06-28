using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Commands.Update_Accessories
{
    public partial class Update_Accessories
    {
        public class Command : IRequest
        {
            public int ID_Accessories { get; set; }
            public string Сharacteristics_info { get; set; }
        }
    }
}
