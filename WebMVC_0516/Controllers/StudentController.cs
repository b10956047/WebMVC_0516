using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC_0516.Models.DemoData;
using WebMVC_0516.Sevice;

namespace WebMVC_0516.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Index(Dictionary<string, string> queryDic, int nowPage = 1)
        {
            int count = 10;
            int offset = (nowPage - 1) * count;
            var (total, list) = _studentService.GetStudents(offset, count, queryDic);

            //var list = _studentService.GetStudents();
            ViewData["Total"] = total;
            ViewData["nowPage"] = nowPage;

            ViewData["query_studentName"] = queryDic["studentName"];
            ViewData["query_studentNo"] = queryDic["studentNo"];
            ViewData["query_gitHubLink"] = queryDic["gitHubLink"];

            return View(list);
        }
        public IActionResult Update(string studentNo)
        {
            var student = _studentService.GetStudentByStudentNo(studentNo);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Update()
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string studentNo)
        {
            _studentService.DeleteStudent(studentNo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string studentNo)
        {
            var student = _studentService.GetStudentByStudentNo(studentNo);
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            _studentService.CreateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(string studentNo)
        {
            var student = _studentService.GetStudentByStudentNo(studentNo);
            
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
