using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_0516.Models.DemoData
{
    public class Student
    {
        /// <summary>
        /// 學號
        /// </summary>
        public string studentNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string studentName { get; set; }

        /// <summary>
        /// GitHub連結
        /// </summary>
        public string gitHubLink { get; set; }
        public Student(string studentNo, string studentName, string gitHubLink)
        {
            this.studentNo = studentNo;
            this.studentName = studentName;
            this.gitHubLink = gitHubLink;
        }
    }
}
