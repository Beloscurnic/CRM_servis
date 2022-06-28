using System;
using System.Collections.Generic;
using System.Text;
using MediatR;


namespace CRM.Application.CRMs.Commands.Creat_Equipment_radio
{
    public partial class Creat_Equipment_radio
    {
       public class Command : IRequest<int>
        {
            public int ID_Order { get; set; }
            public string Name_Сomponent { get; set; }
            public int quintity { get; set; }
        }

    }
}
