using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Creat_Equipment
{
    public partial class Create_Equipment
    {
       public class Command : IRequest<int>
        {
            public int ID_Order { get; set; }
            public int ID_Accessories { get; set; }
            public string Name_Company { get; set; }
        }

    }
}
