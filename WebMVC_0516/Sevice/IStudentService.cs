using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC_0516.Models.DemoData;

namespace WebMVC_0516.Sevice
{
    public interface IStudentService
    {
        List<Student> GetStudents();

        (int total, List<Student>) GetStudents(int offset, int count);
        (int total, List<Student>) GetStudents(int offset, int count, Dictionary<string, string> queryDic);

        Student GetStudentByStudentNo(string studentNo);

        bool UpdateStudent(Student student);

        bool DeleteStudent(string studentNo);

        bool CreateStudent(Student student);
    }
}
