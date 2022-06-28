using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CRM.Application.CRMs.Commands.Create_Provider
{
    public partial class Create_Provider
    {
        public class Command : IRequest<int>
        {
            public string Name_Company { get; set; }
            public string Identification_Number { get; set; }
            public string Supplier_Address { get; set; }
            public string FIO_Director { get; set; }
            public string Telefon { get; set; }
            public string Status { get; set; }
            public string Comments { get; set; }
        }
    }
}