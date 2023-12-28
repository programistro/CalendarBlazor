using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Calendar.Models
{
    public class Appointment
    {
        public string ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
        public string Text { get; set; }
        
        // public string Title { get; set; }
        public string Teacher { get; set; }
        
        public string Client { get; set; }
    }
}