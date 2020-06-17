using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NguyenDuyNam_lab456.Models
{
    public class Following
    {
        public Courses Courses { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }
        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
        public string FolloweeId { get; internal set; }
    }
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var attendance = new Following
            {
                CourseId = courseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}