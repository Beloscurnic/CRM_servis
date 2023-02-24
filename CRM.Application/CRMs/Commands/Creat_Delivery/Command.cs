using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Creat_Delivery
{
    public partial class Create_Delivery
    {
       public class Command : IRequest<int>
        {
            public int ID_Accessories { get; set; }
            public Guid ID_Сomponent { get; set; }
            public string Name_Сomponent { get; set; }
            public string Type_Сomponent { get; set; }
            public int Price_Сomponent { get; set; }
            public int Quantity_Сomponent { get; set; }
            public string Issue_date { get; set; }
            public string Name_Company { get; set; }
        }

    }
}
