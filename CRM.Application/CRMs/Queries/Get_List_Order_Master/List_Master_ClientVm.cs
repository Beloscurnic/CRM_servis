//using CRM.Application.CRMs.Queries.Get_List_Order_Client_Details;

using CRM.Application.CRMs.Queries.Get_List_Order_Master_Details;
using System.Collections.Generic;


namespace CRM.Application.CRMs.Queries.Get_List_Order_Master
{
    public class List_Master_ClientVm
    {
        public IList <List_Order_Master> Orders { get; set; }
    }
}
