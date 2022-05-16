using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(int nowPage = 1)
        {
            //var list = _studentService.GetStudents();
            int count = 10;
            int offset = (nowPage - 1) * count;
            var (total, list) = _studentService.GetStudents(offset, count);

            ViewData["Total"] = total;
            ViewData["nowPage"] = nowPage;

            return View(list);
        }
    }
}
