﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.CRMs.Queries.Get_List_Accessories_company
{
    public partial class Get_List_Accessories2
    {
        public class Query : IRequest<List_Accessories2Vm>
        {
            public string Name_Company { get; set; }
        }
    }
}
