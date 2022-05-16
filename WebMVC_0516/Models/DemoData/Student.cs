using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebMVC_0516.Models.DemoData
{
    public class Student
    {
        /// <summary>
        /// 學號
        /// </summary>
        [Key]
        public string studentNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不可空白")]
        public string studentName { get; set; }

        /// <summary>
        /// GitHub連結
        /// </summary>
        [MinLength(10, ErrorMessage = "長度不可小於10")]
        public string gitHubLink { get; set; }
        public Student(string studentNo, string studentName, string gitHubLink)
        {
            this.studentNo = studentNo;
            this.studentName = studentName;
            this.gitHubLink = gitHubLink;
        }
        public Student()
        {
        }


    }
}
