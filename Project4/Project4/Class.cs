using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project4
{
    public class Class
    {
        public string CRN { get; set; }
        public string courseNumber { get; set; }
        public string sectionNumber { get; set; }
        public List<string> days = new List<string>();
        public int startTime { get; set; }
        public int endTime { get; set; }
    }
}