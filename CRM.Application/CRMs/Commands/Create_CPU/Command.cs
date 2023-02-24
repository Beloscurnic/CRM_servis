using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Create_Accessories
{
    public partial class Create_CPU
    {
       public class Command : IRequest<int>
        {
            public int ID_Accessories { get; set; }
            public string Name_Сomponent { get; set; }
            public int Price_CPU { get; set; }
            public int Quantity_CPU { get; set; }
            public int Number_Cores { get; set; }
            public string Purity_CPU { get; set; }

            public string Name_Company { get; set; }
            public int ID_Provider { get; set; }
        }
    }
}
