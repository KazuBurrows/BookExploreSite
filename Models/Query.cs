using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExploreSite.Models
{
    public class Query
    {
        // To make sure request and response match
        //public int QueryID { get; set; }




        // What the query is for e.g login or register
        public string PayloadType { get; set; }
        // Data required to perform query e.g email, password
        public string[] Payload { get; set; }

    }
}