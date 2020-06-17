using Microsoft.AspNet.Identity;
using NguyenDuyNam_lab456.DTOs;
using NguyenDuyNam_lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenDuyNam_lab456.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbConText;

        public FollowingsController()
        {
            _dbConText = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId))
                return BadRequest("The Attendance altrady exists !");
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
       
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
