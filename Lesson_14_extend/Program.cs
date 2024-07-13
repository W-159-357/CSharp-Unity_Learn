namespace Lesson_14_extend;

class Teacher
{
    public string name;
    protected int number;
    public void SpeakName()
    {
        Console.WriteLine(name);
    }

    public Teacher()
    {
        name = "";
        number = 0;
    }
}

// C#中不支持多继承
class TeachingTeacher : Teacher
{
    // 科目
    public string subject;
    public void SpeakSubject()
    {
        Console.WriteLine(subject + "老师");
    }
    public TeachingTeacher()
    {              
        number = 1;
        subject = "";
    }
}

class UnityTeacher : TeachingTeacher
{
    public void Skill()
    {
        Console.WriteLine("Unity is the one of best !");
    }
    public UnityTeacher()
    {
        number = 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("继承");

        TeachingTeacher tt = new TeachingTeacher();
        tt.name = "吴老师";
        // tt.number = 1;
        tt.SpeakName();
        
        tt.subject = "Cpp";
        tt.SpeakSubject();

        UnityTeacher ut = new UnityTeacher();
        ut.name = "汪老师";
        // ut.number = 2;
        ut.subject = "Unity";
        ut.SpeakName();
        ut.SpeakSubject();
        ut.Skill();
    }

    // 总结
    // 继承基本语法
    // 1.单根性：只能继承一个父类
    // 2.传递性：子类可以继承父类的父类的所有内容
    // 3.访问修饰性 对于成员的影响
    // 4.极其不建议使用 在子类中申明和父类同名的成员
}
