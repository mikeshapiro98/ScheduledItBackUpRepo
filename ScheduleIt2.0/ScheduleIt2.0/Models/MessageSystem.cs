using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2._0.Models
{
    public class MessageSystem : EventModel
    {
        //Message table used for communication between admins and users.

        ///<summery>
        ///ID for the Message
        ///</summery>
        public Guid MessageID { get; set; }

        ///<summery>
        ///DateTime Sent for the Message
        /// </summery>
        [Display(Name = "Date Sent")]
        public DateTime DateSent { get; set; }

        ///<summery>
        ///DateTime Read for the Message
        ///</summery>
        [Display(Name = "Date Read")]
        public DateTime? DateRead { get; set; }

        ///<summary>
        ///Message Title
        /// </summary>
        [Display(Name = "Title")]
        public string MessageTitle { get; set; }

        ///<summery>
        ///Sets the content of the Message
        /// </summery>
        public string Content { get; set; }

        ///<summary>
        ///Whether the message has been read or not
        /// </summary>
        [Display(Name = "Unread")]
        public bool UnreadMessage { get; set; }

        ///<summery>
        ///Message System Parameterized Constructor
        /// </summery>
        public MessageSystem(ApplicationDbContext db, TimeOffEvent e, string s)
        {
            //default that the message is unread
            UnreadMessage = true;
            //assign the messageID a new Guid
            MessageID = Guid.NewGuid();
            //assign the time message sent
            DateSent = DateTime.Now;
        }

        public MessageSystem()
        {

        }
    }

}