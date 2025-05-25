using System.Security.Cryptography.X509Certificates;

namespace task14_5
{

    // class for Instructor
    class Instructor
    {
        public int instructorId;
        public string instructorName;
        public string specialization;

        public Instructor(int instructorId, string instructorName, string specialization)
        {
            this.instructorId = instructorId;
            this.instructorName = instructorName;
            this.specialization = specialization;
        }

        public string PrintDetails()
        {
            return $"the Instrauctor ID is {instructorId} and this name is  {instructorName} ," +
                $" and he teaching the course {specialization}";

        }
    }
    // END class for Instructor
    //===========


    // class for courses
    class Course
    {
        public int courseId;
        public string courseTitle;
        public string instructor;

        public Course(int courseId, string courseTitle, string instructor)
        {
            this.courseId = courseId;
            this.courseTitle = courseTitle;
            this.instructor = instructor;
        }

        public string PrintDetails()
        {

            return $" the course id is {courseId} , " +
                $"the course title is {courseTitle} and the instructor is {instructor}";

        }

    }
    // End  class for courses
    //===========

    // class for Student
    class Student
    {
        public int studentId;
        public string studentName;
        public int age;
        public string studentCourses;

        public Student(int studentId, string studentName, int age, string studentCourses)
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.age = age;
            this.studentCourses = studentCourses;
        }

        //public bool Enroll(Course course)
        //{

        //    if (course is not null)
        //    {

        //        this.Courses.Add(course);

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public string PrintDetails()
        {

            return $" the Student ID  id is {studentId} , the Student name is {studentName} , " +
                $"and Student age is {age}";
        }


    }
    // END class for Student


    // class for StudentManager
    class StudentManager
    {

        List<Instructor> instructors;
        List<Course> courses;
        List<Student> students;

        //store in hibe
        public StudentManager()
        {
            instructors = new();
            courses = new();
            students = new();

        }

        //mthod add instructor

        public bool AddInstructor(Instructor newInstructor)
        {

            if (newInstructor.instructorName is not null)
            {

                instructors.Add(newInstructor);
                return true;

            }
            else
            {
                return false;
            }


        }


        public Instructor? FindInstructor(int instQuery)
        {
            // search in the list of instructors
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instQuery == instructors[i].instructorId)
                {
                    return instructors[i];
                }
            }

            // Return null if no instructor is found
            return null;
        }



        public bool AddCourse (Course newCourse)
        {
            if (newCourse.courseTitle is not null)
            {

                courses.Add(newCourse);
                return true;
            }
            else { return false; }

        }


        public Course? FindCourse(int query)
        {
            // search in the list of courses
            for (int i = 0; i < courses.Count; i++)
            {
                if (query == courses[i].courseId)
                {
                    return courses[i];
                }
            }

            // Return null if no instructor is found
            return null;
        }

        public bool AddStudent (Student newStudent)
        {
            if(newStudent.studentName is not null)
            {

                students.Add(newStudent);
                return true; 
            }else
            {
                return false;
            }

        }

        public Student? Findstudent(int stuQuery)
        {
            // search in the list of courses
            for (int i = 0; i < courses.Count; i++)
            {
                if (stuQuery == courses[i].courseId)
                {
                    return students[i];
                }
            }

            // Return null if no instructor is found
            return null;
        }


        // END class for StudentManager
        //===========


        internal class Program
    {
            static void Main(string[] args)
            {

                //create object of student managment
                StudentManager studentManager = new();
                //insert mock instructor for test
                studentManager.instructors.Add(new(1, "Ahmed", "arabic"));

                //insert mock course for test
                studentManager.courses.Add(new(1, "Arabic", "Ahmed"));

                //insert mock student for test
                studentManager.students.Add(new(1, "taha", 15, "Arabic"));


                Console.WriteLine("Welcome to iSchool System ");
                Console.WriteLine("==============");

                Console.WriteLine("Main Menu ");

                Console.WriteLine(

                    "1 - Add Instructor\r\n    " +
                    "2 - Find Instructor\r\n    " +
                    "3 - Show All Instructors\r\n    " +
                    "4 - Add Course\r\n    " +
                    "5 - Find Course\r\n    " +
                    "6 - Show All Course\r\n    " +
                    "7 - Add Student\r\n    " +
                    "8 - Find student\r\n    " +
                    "9 - Show All student\r\n    " +
                    "10 - Exit");

                Console.WriteLine("==============");
                
                do
                {
                    Console.WriteLine("Please Enter your choices : ");
                    int indicator = Convert.ToInt32(Console.ReadLine());

                    switch (indicator) { 

                       //add instructor

                        case 1:

                        Console.WriteLine("Please the instructor id : ");
                        int instructorId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please the instructor name : ");
                        string instructorName = Console.ReadLine();

                        Console.WriteLine("Please the instructor specialization : ");
                        string specialization = Console.ReadLine();


                        //create new object using consturctor
                        Instructor newInstructor = new Instructor(instructorId, instructorName,
                            specialization);


                        //add this object to list of instructors inside studentmnager class
                        //using object of studentmanager
                        studentManager.AddInstructor(newInstructor);

                        Console.WriteLine("the instructor is added");

                        break;

                        case 2:

                        //find instructor

                         Console.WriteLine("search for instructor using id");

                          int instQuery = Convert.ToInt32(Console.ReadLine());

                                //create new object to store search results
                                Instructor? foundinst = studentManager.FindInstructor(instQuery);

                                if (foundinst is null)
                                {
                                    Console.WriteLine("not data found");

                                }
                                else
                                {
                                    Console.WriteLine($"the id of instructor is {foundinst.instructorId}");
                                    Console.WriteLine($"the name of instructor is {foundinst.instructorName}");
                                }
                            break;
                        case 3:
                            //show all instructors

                            Console.WriteLine("this is the list of all instructors");

                            for (int i = 0; i < studentManager.instructors.Count; i++)

                            {
                                if (studentManager.instructors is null)
                                {

                                    Console.WriteLine("no data");
                                }
                                else
                                {
                                    Console.WriteLine(studentManager.instructors[i].PrintDetails());
                                }
                            }
                            break;

                        case 4:

                        //add course
                           
                                Console.WriteLine("Please the course id : ");
                                int courseId = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Please the course title : ");
                                string courseTitle = Console.ReadLine();

                                Console.WriteLine("Please choose course instrcutor : ");
                                string instructor = Console.ReadLine();

                                Course newCourse = new Course(courseId, courseTitle, instructor);
                                studentManager.AddCourse(newCourse);
                            Console.WriteLine("the course is added");

                            break;
                        case 5:

                        //find course

                                Console.WriteLine("search for course using id");

                                int query = Convert.ToInt32(Console.ReadLine());

                                //create new object to store search results
                                Course? foundcourse = studentManager.FindCourse(query);

                                if (foundcourse is null)
                                {
                                    Console.WriteLine("not data found");

                                }
                                else
                                {
                                    Console.WriteLine($"the id of course is {foundcourse.courseId}");
                                    Console.WriteLine($"the name of course is {foundcourse.courseTitle}");

                                }
                            break;

                        case 6:

                            //show all courses
                       
                                Console.WriteLine("this is the list of all courses");

                                for (int i = 0; i < studentManager.courses.Count; i++)

                                {

                                    if (studentManager.instructors is null)
                                    {

                                        Console.WriteLine("no data");
                                    }
                                    else
                                    {
                                        Console.WriteLine(studentManager.courses[i].PrintDetails());
                                        break;
                                    }

                                }

                            break;

                        case 7:


                        //add student

                       
                                Console.WriteLine("Please enter student id");
                                int studentId = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Please enter student name");
                                string studentName = Console.ReadLine();

                                Console.WriteLine("Please enter student age");
                                int age = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Please enter student course");
                                string studentCourses = Console.ReadLine();

                                Student newStudent = new Student(studentId, studentName, age, studentCourses);
                                studentManager.AddStudent(newStudent);

                            Console.WriteLine("the student is added");

                            break;

                        case 8:

                            //find student

                            Console.WriteLine("search for course using id");

                            int stuQuery = Convert.ToInt32(Console.ReadLine());

                            //create new object to store search results
                            Student? foundStudent = studentManager.Findstudent(stuQuery);

                            if (foundStudent is null)
                            {
                                Console.WriteLine("not data found");

                            }
                            else
                            {
                                Console.WriteLine($"the id of course is {foundStudent.studentId}");
                                Console.WriteLine($"the name of course is {foundStudent.studentName}");

                            }
                            break;



                        case 9:

                            //show all student

                            Console.WriteLine("this is the list of all student");

                            for (int i = 0; i < studentManager.students.Count; i++)

                            {

                                if (studentManager.students is null)
                                {

                                    Console.WriteLine("no data");
                                }
                                else
                                {
                                    Console.WriteLine(studentManager.students[i].PrintDetails());
                                    break;
                                }

                            }

                            break;


                        default:
                        Console.WriteLine("invalid choose");

                           Console.WriteLine(
                     "1 - Add Instructor\r\n    " +
                    "2 - Find Instructor\r\n    " +
                    "3 - Show All Instructors\r\n    " +
                    "4 - Add Course\r\n    " +
                    "5 - Find Course\r\n    " +
                    "6 - Show All Course\r\n    " +
                    "7 - Add Student\r\n    " +
                    "8 - Find student\r\n    " +
                    "9 - Show All student\r\n    " +
                    "10 - Exit");

                            Console.WriteLine("==============");
                        break;
                    }


                } while (true);

            }
        }
    }
}