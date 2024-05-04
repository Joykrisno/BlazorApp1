using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DamoModels.Models
{
    public partial class EmployeInfo
    {
        



        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string YearoffExprience { get; set; }
    }
}
