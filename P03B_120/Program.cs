using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P03B_120
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 設計一個類別來表示一個學生，擁有姓名、生日、成績、聯絡人等屬性，以及計算年齡的方法，並且支援按姓名排序和按成績排序的方法。
            List<Student> students = new List<Student> {new Student("Allen",new Birthday("1994-01-01"),80,new ContactPerson("A")),
                                                        new Student("Ted",new Birthday("1994-02-02"),90,new ContactPerson("B")),
                                                        new Student("Lorry",new Birthday("1994-05-01"),70,new ContactPerson("C")),
                                                        new Student("Emma",new Birthday("1994-06-09"),60,new ContactPerson("J"))};
            
            Console.WriteLine("姓名排序");
            students.Sort(new NameCompare());
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
            }
            Console.WriteLine();

            Console.WriteLine("成績排序");
            students.Sort(new GradeCompare());
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
            }

        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; }
        public Birthday StdBirthday { get; }
        public int Grade { get; }

        public ContactPerson ContPerson { get; set; }
        public Student(string name, Birthday date, int grade, ContactPerson contactPerson)
        {
            Name = name;
            StdBirthday = date;
            Grade = grade;
            ContPerson = contactPerson;
        }
        /// <summary>
        /// 獲得年齡
        /// </summary>
        /// <returns></returns>
        public int GetAge()
        {
            DateTime today = DateTime.Now;
            DateTime birthday = StdBirthday.Date;

            int age = today.Year - birthday.Year;

            return birthday > today.AddYears(-age) ? age - 1 : age;
        }
        /// <summary>
        /// 實作排序方式
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }
        public string GetInfo()
        {
            return $"姓名: {Name,5} ,生日為 {StdBirthday} ,年齡為 {this.GetAge()} 歲,成績為 {Grade} 分,聯絡人為 {ContPerson} .";
        }
       
    }

    /// <summary>
    /// 姓名排序
    /// </summary>
    public class NameCompare : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    /// <summary>
    /// 成績排序
    /// </summary>
    public class GradeCompare : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Grade.CompareTo(y.Grade);
        }
    }

    /// <summary>
    /// 聯絡人
    /// </summary>
    public class ContactPerson
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Relation { get; set; }
        public ContactPerson(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return this.Name.ToString();
        }
    }

    /// <summary>
    /// 生日
    /// </summary>
    public class Birthday
    {
        public DateTime Date { get; }

        public Birthday(string dateStr)
        {
            ValidBirthday(dateStr, out DateTime date);
            Date = date;
        }
        public Birthday(DateTime date)
        {
            ValidBirthday(date);
            Date = date;
        }
        private void ValidBirthday(string dateStr, out DateTime date)
        {
            bool result = DateTime.TryParse(dateStr, out date);

            if (string.IsNullOrEmpty(dateStr) || !result) throw new Exception("生日格式不正確");

            ValidBirthday(date);

        }

        private void ValidBirthday(DateTime date)
        {
            DateTime oldestBirthday = new DateTime(1900, 01, 01);

            if (date == null || date > DateTime.Today || date < oldestBirthday) throw new Exception("生日數值不正確");

        }

        public override string ToString()
        {
            return this.Date.ToString("yyyy/MM/dd");
        }
    }

    
}
