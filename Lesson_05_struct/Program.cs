namespace Lesson_05_struct
{
    class Program
    {
        #region struct 结构体
        struct Student
        {
            private string name;
            private int age;
            private bool gender;
            private int number;

            // 构造函数(变量初始化)
            public Student(string name, int age, bool gender, int number)
            {
                this.name = name;
                this.age = age;
                this.gender = gender;
                this.number = number;
            }

            // 结构体的函数不需要 static 关键字
            public void Speak()
            {
                Console.WriteLine("我的名字是{0}, 我今年{1}岁了。", name, age);
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Struct' Usage");

            Student stu = new Student("Mike", 18, true, 10001);
            stu.Speak();
        }
    }
};


