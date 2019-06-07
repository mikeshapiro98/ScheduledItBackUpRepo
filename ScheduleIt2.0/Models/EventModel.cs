using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleIt2._0.Models
{
    public class EventModel
    {

        [Key]
        /// <summary>
        ///event id property
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        ///start time of event property
        /// </summary>
        [Display(Name = "Start")]
        [Column(TypeName = "datetime2")]
        //add datatype.date to prevent sql datetime2 error
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///end time of event property
        /// </summary>
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.DateTime)]
        [Display(Name = "End")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        ///note attached to event property
        /// </summary>
        [Display(Name = "Optional Message")]
        public string Message { get; set; }

        /// <summary>
        ///title of event property
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///id of admin who approved event property
        /// <summary>
        public int AdminId { get; set; }

        /// <summary>
        ///conntects to attached user
        /// </summary>
        public virtual ApplicationUser User { get; set; }
    }
}

    
    
