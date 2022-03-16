﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
  public  class Order_Client
    {
        public Guid ID_Order { get; set; }
        public Guid ID_Client { get; set; }
        public Guid ID_Personnel { get; set; }
        public string Name_Client { get; set; }
        public string LastName_Client { get; set; }
        public string Email_Client { get; set; }
        public string Telefon { get; set; }
        public string Type_technology { get; set; }
        public string Model_technology { get; set; }
        public string Breaking_info { get; set; }
        public string Quipment_info { get; set; }
        public string Status_Order { get; set; }
        [Column(TypeName = "date")]
        public DateTime Receipt_date { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Issue_date { get; set; }
        public int Price { get; set; }
    }
}
