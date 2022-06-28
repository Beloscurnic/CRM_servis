using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Create_Order
{
   public class Create_Order_Client_Command: IRequest<Guid>
    {

        public string Name_Client { get; set; }
        public string LastName_Client { get; set; }
        public string Email_Client { get; set; }
        public string Telefon { get; set; }
        public string Type_technology { get; set; }
        public string Model_technology { get; set; }
        public string Breaking_info { get; set; }
        public string Status_Order { get; set; }
        public Guid ID_Client { get; set; }
        public Guid ID_Personnel_dispatcher { get; set; }
        public Guid ID_Personnel_master { get; set; }
    }
}
