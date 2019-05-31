using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScheduleIt2._0.Models
{
    public class TimeOffEvent : EventModel
    {
        // Add the two properties needed that are not inherited from EventModel
        
        //Date of Submission
        [DataType(DataType.Date)]        
        public DateTime Submitted { get; set; }


        //Request Status
        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }

    }

    public class TimeOffViewModel
    {

        [Display(Name = "Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime StartTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "End")]
        public DateTime EndTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Display(Name = "Time of Request")]
        public DateTime Submitted { get; set; }
        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }
        [Display(Name = "Optional Message")]
        public string Message { get; set; }

    }
}