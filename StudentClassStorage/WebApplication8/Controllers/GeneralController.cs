using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Context;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class GeneralController : Controller
    {
        private readonly GeneralContext _Context;
        public GeneralController(GeneralContext context)
        {
            _Context = context;
        }
        [Route("/")]
        public IActionResult Index(string targetval)
        {
            if (targetval != null)
            {
                TempData["clicked"] = targetval;
            }
            ClassTypeStudent sharedClass = new();
            sharedClass.Students = _Context.Students.ToList();
            sharedClass.ClassTypes = _Context.ClassTypes.ToList();
            return View(sharedClass);
        }
        public IActionResult StudentDetailList(int id)
        {
            var selectedStudents = _Context.Students.Where(x => x.ClassTypeId == id).ToList();
            return View(selectedStudents);
        }
        public IActionResult StudentDelete(int id)
        {
            var selectedStudent = _Context.Students.Where(x => x.Id == id).FirstOrDefault();
            _Context.Students.Remove(selectedStudent);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
            public IActionResult StudentCreate()
        {
            ClassTypeStudent clasasStudent = new();
            clasasStudent.ClassTypes = _Context.ClassTypes.ToList();
            foreach (var item in clasasStudent.ClassTypes)
            {
                clasasStudent.StudentClassType.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Level + "-" + item.Branch });
            }
            return View(clasasStudent);
        }

        [HttpPost]
        public IActionResult StudentCreate(ClassTypeStudent classStudent)
        {

                _Context.Students.Add(classStudent.Student);
                _Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ClassCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ClassCreate(ClassType classType)
        {
            _Context.ClassTypes.Add(classType);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ClassDelete(int id)
        {
            var selectedClass = _Context.ClassTypes.Where(x => x.Id == id).FirstOrDefault();
            var targetStudent = _Context.Students.Where(x => x.ClassTypeId == id).ToList();
            foreach (var item in targetStudent)
            {
                _Context.Students.Remove(item);
            }
            _Context.ClassTypes.Remove(selectedClass);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
