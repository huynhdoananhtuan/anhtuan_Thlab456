using System.Linq;
using System.Web.Mvc;
using NguyenDuyNam_lab456.Models;
using NguyenDuyNam_lab456.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System;

namespace NguyenDuyNam_lab456.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Create()
        {
            var ViewModels = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Heading = "Add Course"
            };
            return View(ViewModels);
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Attendances
                 .Where(a => a.AttendeeId == userId)
                 .Select(a => a.Courses)
                 .Include(l => l.Lecturer)
                 .Include(l => l.Category)
                 .ToList();
            var viewModel = new CourseViewModel
            {
                UpcommingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Course
                 .Where(c => c.LecturerId == userId && c.DateTime > DateTime.Now)
                 .Include(l => l.Lecturer)
                 .Include(c => c.Category)
                 .ToList();
           
            return View(courses);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel ViewModels)
        {
            if (!ModelState.IsValid)
            {
                ViewModels.Categories = _dbContext.Categories.ToList();
                return View("Create", ViewModels);
            }
            var course = new Courses
            {
                LectureredId = User.Identity.GetUserId(),
                DateTime = ViewModels.GetDatetime(),
                CategoryId = ViewModels.Category,
                Place = ViewModels.Place
           };
            _dbContext.Course.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CourseViewModel ViewModels)
        {
            if (!ModelState.IsValid)
            {
                ViewModels.Categories = _dbContext.Categories.ToList();
                return View("Create", ViewModels);
            }
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Course.Single(c => c.Id == ViewModels.Id && c.LecturerId == userId);

            course.Place = ViewModels.Place;
            course.DateTime = ViewModels.GetDatetime();
            course.CategoryId = ViewModels.Category;
       
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Course.Single(c => c.Id == id && c.LecturerId == userId);

            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Date = course.DateTime.ToString("dd/M/yyyy"),
                Time = course.DateTime.ToString("HH:mm"),
                Category = course.CategoryId,
                Place = course.Place,
                Heading = "Edit Course",
                Id = course.Id
            };
            return View("Create", viewModel);
        }

    }
}