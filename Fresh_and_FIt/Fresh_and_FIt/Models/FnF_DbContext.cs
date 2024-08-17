using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Fresh_and_FIt.Models
{
    public class FnF_DbContext : DbContext
    {


        public FnF_DbContext() : base("name=Fresh_and_Fit")
        {

        }



    }
}

 