﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QDetect.Data.Models;

namespace QDetect.Web.ViewModels
{
    public class PeopleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UCN { get; set; }

        public string City { get; set; }

        public string QuarantineEndDate { get; set; }

        public string Image { get; set; }

        public bool HasReports { get; set; }
    }
}
