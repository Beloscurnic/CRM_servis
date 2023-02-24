using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Create_Radio_components
{
    public partial class Create_Radio_components
    {
       public class Command : IRequest<int>
        {
            public int ID_Accessories { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price { get; set; }
            public string options { get; set; }

            public string Name_Company { get; set; }
            public int ID_Provider { get; set; }
        }
    }
}
