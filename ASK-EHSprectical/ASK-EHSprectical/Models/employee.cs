//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASK_EHSprectical.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class employee
    {
        public int emp_id { get; set; }
        public string emp_plant { get; set; }
        public string emp_category { get; set; }
        public string emp_code { get; set; }
        public string emp_first_name { get; set; }
        public string emp_middel_name { get; set; }
        public string emp_last_name { get; set; }
        public string emp_department { get; set; }
        public string repoting_manager { get; set; }
        public string emp_designation { get; set; }
        public string emp_contact { get; set; }
        public string emp_email { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_join { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> job_relieving { get; set; }
        public string blood_group { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> emp_age { get; set; }
        public string emp_gender { get; set; }
        public Nullable<bool> active { get; set; }
        public string emp_image { get; set; }
    }
}
