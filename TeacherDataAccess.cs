using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Records_App
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TeacherDataAccess
    {
        private const string FilePath = "teachers.txt";

        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(data[0]),
                        Name = data[1],
                        ClassSection = data[2]
                    };
                    teachers.Add(teacher);
                }
            }

            return teachers;
        }

        public static void SaveTeacher(Teacher teacher)
        {
            using (StreamWriter writer = File.AppendText(FilePath))
            {
                writer.WriteLine($"{teacher.ID},{teacher.Name},{teacher.ClassSection}");
            }
        }
    }

}
