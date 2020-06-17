using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenDuyNam_lab456.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public object LectureredId { get; internal set; }
        public bool IsCancaled { get; internal set; }
        public bool IsCanCeled { get; internal set; }
    }
}