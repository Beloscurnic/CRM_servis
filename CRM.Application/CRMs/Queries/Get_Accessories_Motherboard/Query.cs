﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_Accessories_Motherboard
{
    public partial class Get_Motherboard
    {
        public class Query : IRequest<MotherboardVm>
        {
            public int ID_Accessories { get; set; }
           
        }
    }
}
