using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebMVC_0516.Models.DemoData
{
    public class Student : IBaseData
    {
        /// <summary>
        /// 學號
        /// </summary>
        [Key]
        [DisplayName("學生學號")]
        public string studentNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不可空白")]
        [DisplayName("學生姓名")]
        public string studentName { get; set; }

        /// <summary>
        /// GitHub連結
        /// </summary>
        [MinLength(10, ErrorMessage = "長度不可小於10")]
        [DisplayName("GitHub連結")]
        public string gitHubLink { get; set; }

        /// <summary>
        /// 是否刪除
        /// </summary>
        public bool isDelete { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime creDateTime { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime updateDateTime { get; set; }

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
