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
            //var list = _studentService.GetStudents();
            int count = 10;
            int offset = (nowPage - 1) * count;
            var (total, list) = _studentService.GetStudents(offset, count, queryDic);

            ViewData["Total"] = total;
            ViewData["nowPage"] = nowPage;

            ViewData["query_studentName"] = queryDic["query_studentName"];
            ViewData["query_studentNo"] = queryDic["query_studentNo"];
            ViewData["query_gitHubLink"] = queryDic["query_gitHubLink"];
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

        public IActionResult Delete(string studentNo)
        {
            _studentService.DeleteStudent(studentNo);
            return RedirectToAction("Index");
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
