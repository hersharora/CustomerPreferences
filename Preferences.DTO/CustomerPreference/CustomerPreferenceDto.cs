using System;
using Preferences.Custom;

namespace Preferences.DTO
{
    public class CustomerPreferenceDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public Template TemplateId { get; set; }

        public DateTime? StartDate { get; set; }

        public Frequency Repeat { get; set; }

        public bool IsActive { get; set; }

    }
}
