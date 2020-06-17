using NguyenDuyNam_lab456.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenDuyNam_lab456.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }
        public DateTime GetDatetime()
        {
            return DateTime.Parse(string.Format("{0}{1}", Date, Time));
        }


    }
}