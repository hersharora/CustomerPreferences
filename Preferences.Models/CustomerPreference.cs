using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Preferences.Custom;

namespace Preferences.Models
{
    public class CustomerPreference : IEntityBase
    {
        public CustomerPreference()
        {
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [EnumDataType(typeof(Template))]
        public Template TemplateId { get; set; }

        public DateTime? StartDate { get; set; }

        [EnumDataType(typeof(Frequency))]
        public Frequency Repeat { get; set; }

        public bool IsActive {get; set;}

    }
}
