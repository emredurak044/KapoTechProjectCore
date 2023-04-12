using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectURL { get; set; }
        public bool Status { get; set; }
    }
}