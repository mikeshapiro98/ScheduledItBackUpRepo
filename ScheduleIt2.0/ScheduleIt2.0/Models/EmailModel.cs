namespace ScheduleIt2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class EmailModel
    {
        [Key]
        public Guid EventId { get; set; }

        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        public string MessageBody { get; set; }

        public EmailModel()
        {

        }
    }
}