using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2._0.Models
{
    public class WorkTimeEventModel : EventModel
    {
        /// <summary>
        /// Model for when a user clocks in or out, stored in the Events Table
        /// </summary>
        public WorkTimeEventModel()
        {
        }
        //Clocks the user in by creating a new worktimeevent
        public WorkTimeEventModel(ApplicationUser user, string message, DateTime? dt = null)
        {
            User = user;
            EventId = Guid.NewGuid();
            if (dt.HasValue) StartTime = dt.Value;
            else StartTime = DateTime.Now;
            Message = message;
        }
        public ClockFunctionStatus Clockout(DateTime? dt = null)
        {
            try
            {
                //If we are clocking out but there is already a value, this is an update
                if (this.EndTime.HasValue)
                {
                    this.EndTime = dt.HasValue ? dt : DateTime.Now;
                    return ClockFunctionStatus.ClockOutUpdated;
                }
                else
                {
                    this.EndTime = dt.HasValue ? dt : DateTime.Now;
                    return ClockFunctionStatus.ClockOutSuccess;
                }
            }
            catch
            {
                return ClockFunctionStatus.ClockOutFail;
            }
        }

        public enum ClockFunctionStatus
        {
            ClockInSuccess,
            ClockInFail,
            ClockOutSuccess,
            ClockOutFail,
            ClockInUpdated,
            ClockOutUpdated
        }

        /// <summary>
        /// result of total hours in shift time (shift end - shift start)
        /// </summary>
        [Display(Name = "Total Hours")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm\:ss}", ApplyFormatInEditMode = true),
        Range(typeof(TimeSpan), "00:00", "23:59")]
        public TimeSpan? TotalHours
        {
            get
            {
                if (StartTime.HasValue && EndTime.HasValue)
                {
                    return EndTime.Value.Subtract(StartTime.Value);
                }
                return null;
            }
            set { }
        }
    }
}
