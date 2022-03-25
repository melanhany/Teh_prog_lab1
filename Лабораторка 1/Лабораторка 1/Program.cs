using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {


        class Person
        {
            private string Name; //закрытое поле типа string, в котором хранится имя
            private string LastName; //закрытое поле типа string, в котором хранится фамилия
            private System.DateTime BDate;//закрытое поле типа System.DateTime для даты рождения
            //конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса
            public Person(string studentName, string studentLastName, DateTime studentBDate)
            {
                Name = studentName;
                LastName = studentLastName;
                BDate = studentBDate;
            }

            //конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию.
            public Person() : this("Sabitova", "Gulshat", new DateTime(1999, 3, 22))
            { }

            // Свойства c методами get и set: 

            string StdName //свойство типа string для доступа к полю с именем;
            {
                get
                {
                    return Name;
                }

            }

            string StdLastName //свойство типа string для доступа к полю с фамилией
            {
                get
                {
                    return LastName;
                }

            }

            DateTime StdBDate //x свойство типа DateTime для доступа к полю с датой рождения
            {
                get
                {
                    return BDate;
                }

            }

            //Свойство типа int c методами get и set для получения информации(get) и изменения (set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения
            int intStdBdate
            {
                get
                {
                    return Convert.ToInt32(BDate);
                }
                set
                {
                    BDate = Convert.ToDateTime(value);
                }
            }


            //Перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса       
            public override string ToString()
            {
                return "\n" + "Name " + Name + "\n" + "LastName " + LastName + "\n" + "Date of birth: " + BDate + "\n";
            }


            //Виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию.
            public string ToShortString()
            {
                return "\n" + "Имя: " + Name + "\n" + "Фамилия: " + LastName + "\n";
            }

            //Определить тип Education - перечисление(enum) со значениями Specialist, Вachelor, SecondEducation. 
            enum Education { Specialist, Bachelor, SecondEducation }
            // Определить класс Exam, который имеет три открытых автореализуемых свойства, доступных для чтения и записи
            class Exam
            {
                public string Discipline { get; set; }
                public int Rate { get; set; }
                public DateTime DateOfExam { get; set; }
                //конструктор с параметрами типа string, int и DateTime для инициализации всех свойств класса;
                public Exam(string discipline, int rate, DateTime dateOfExam)
                {
                    this.Discipline = discipline;
                    this.Rate = rate;
                    this.DateOfExam = dateOfExam;
                }
                //конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию;
                public Exam()
                {
                    this.Discipline = "";
                    this.Rate = 0;
                    this.DateOfExam = DateTime.Now;
                }
                // перегруженную(override) версию виртуального метода string ToString() для формирования строки со значениями всех свойств класса.
                public override string ToString()
                {
                    return "Predmet:" + Discipline + " " + "Ocenka:" + Rate + " " + "Data exam:" + DateOfExam;
                }
            }
            //Определить класс Student
            class Student
            {
                private Person person;
                private Education education;
                private int group;
                private readonly List<Exam> exams = new List<Exam>();
                //конструктор c параметрами типа Person, Education, int для инициализации соответствующих полей класса;
                public Student(Person person, Education education, int group)
                {
                    this.person = person;
                    this.education = education;
                    this.group = group;
                }
                //конструктор без параметров, инициализирующий поля класса значениями по умолчанию.
                public Student()
                {
                    this.person = new Person();
                    this.education = Education.Bachelor;
                    this.group = 204;
                }
                //определить свойства c методами get и set
                public Person Person
                {
                    get { return person; }
                    set { person = value; }
                }

                public Education Education
                {
                    get { return education; }
                    set { education = value; }
                }

                public int Group
                {
                    get { return group; }
                    set { group = value; }
                }

                public Exam[] Exams
                {
                    get { return exams.ToArray(); }

                }
                // свойство типа double (только с методом get), в котором вычисляется средний балл как среднее значение оценок в списке сданных экзаменов;
                public double AvgRate
                {
                    //get { return exams.Count > 0 ? exams.Average(e=>e.Rate) : 0; }
                    get
                    {
                        double sum = 0;
                        foreach (Exam qwee in Exams)
                        {
                            sum += qwee.Rate;
                        }
                        return exams.Count == 0 ? -1 : sum / exams.Count;
                    }
                }
                //индексатор булевского типа (только с методом get) с одним параметром типа Education; значение индексатора равно true, если значение поля с

                // формой обучения студента совпадает со значением индекса, и false в противном случае
                public bool this[Education index]
                {
                    get
                    {
                        return this.Education == index;
                    }
                }
                //метод void AddExams ( params Exam [] ) для добавления элементов в список экзаменов
                public void AddExams(params Exam[] exams)
                {
                    this.exams.AddRange(exams);
                }
                //перегруженную версию виртуального метода string ToString() для формирования строки со значениями всех полей класса, включая список экзаменов;
                public override string ToString()
                {
                    return string.Format("Person: {0}\n Education: {1}\n group: {2}\n exams: {3}\n ", person, education, group, string.Join(", ", exams));
                }
                //виртуальный метод string ToShortString(), который формирует строку со значениями всех полей класса без списка экзаменов, но со значением среднего балла
                public string ToShortString()
                {
                    return string.Format("Person: {0}\n Education: {1}\n group: {2}\n AvgRate: {3:0.00}\n", person, education, group, AvgRate);
                }
            }

            private static void Main(string[] args)
            {
                Student std = new Student(); //Создать один объект типа Student,
                Console.WriteLine(std.ToShortString()); //преобразовать данные в текстовый вид с помощью метода ToShortString() и вывести данные
                                                        //Присвоить значения всем определенным в типе Student свойствам, преобразовать данные в текстовый вид с помощью метода ToString() и вывести данные.
                std = new Student(new Person("Ivan", "Ivanov", new DateTime(1990, 4, 5)), Education.Bachelor, 3);
                Console.WriteLine(std.ToString());
                // Вывести значения индексатора для значений индекса Education.Specialist, Education.Bachelor и Education.SecondEducation.
                Console.WriteLine(std[Education.Bachelor]);
                Console.WriteLine(std[Education.Specialist]);
                Console.WriteLine(std[Education.SecondEducation]);
                // C помощью метода AddExams(params Exam*+ ) добавить элементы в список экзаменов и вывести данные объекта Student, используя метод ToString().
                std.AddExams(new Exam("Math", 4, new DateTime(2019, 1, 23)), new Exam("C#", 5, new DateTime(2019, 1, 25)));

                Console.WriteLine(std.ToString());

                Console.WriteLine("Сравнить время выполнения операций с элементами одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов типа Exam.");

                Exam[] odnomer = new Exam[10];

                Exam[,] dvumer = new Exam[2, 5];

                Exam[][] stup = new Exam[4][];

                stup[0] = new Exam[1];

                stup[1] = new Exam[2];

                stup[2] = new Exam[3];

                stup[3] = new Exam[4];

                long milliseconds = DateTime.Now.Ticks;

                for (int p = 0; p < 10000; p++)

                    for (int i = 0; i < 10; i++)

                        odnomer[i] = new Exam();

                for (int i = 0; i < 10; i++)

                    Console.WriteLine(odnomer[i] + " ");

                milliseconds = DateTime.Now.Ticks - milliseconds;

                Console.WriteLine("time wasted: " + milliseconds + "\n");

                milliseconds = DateTime.Now.Ticks;

                for (int p = 0; p < 10000; p++)

                    for (int i = 0; i < 2; i++)

                        for (int j = 0; j < 5; j++)

                            dvumer[i, j] = new Exam();

                Console.WriteLine("\n");

                for (int i = 0; i < 2; i++)

                    for (int j = 0; j < 5; j++)

                        Console.WriteLine(dvumer[i, j] + " ");

                milliseconds = DateTime.Now.Ticks - milliseconds;

                Console.WriteLine("time wasted: " + milliseconds + "\n");

                milliseconds = DateTime.Now.Ticks;

                for (int p = 0; p < 10000; p++)

                    for (int i = 0; i < 4; i++)

                        for (int j = 0; j < i + 1; j++)

                            stup[i][j] = new Exam();

                Console.WriteLine("\n");

                for (int i = 0; i < 4; i++)

                    for (int j = 0; j < i + 1; j++)

                        Console.WriteLine(stup[i][j] + " ");

                milliseconds = DateTime.Now.Ticks - milliseconds;

                Console.WriteLine("time wasted: " + milliseconds + "\n");

                milliseconds = DateTime.Now.Ticks;

                Console.ReadKey();

            }
        }
    }
}
