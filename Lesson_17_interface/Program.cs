namespace Lesson_17_interface;

#region 接口声明
interface IFly
{
    void Fly();
    string name
    {
        get;
        set;
    }
    int this[int index]
    {
        get;
        set;
    }
    event Action doSomething;   // 用于委托
}
#endregion

#region 接口的使用
class Animal
{

}
// 1.可以同时继承一个类和接口，但不能通过继承多个类
// 2.继承了接口后，必须实现其中的内容 并且必须是public的
class Person : Animal, IFly
{
    // 3.实现的接口函数，可以加virtual再在子类重写
    public virtual void Fly()
    {

    }

    public string name
    {
        get;
        set;
    }

    public int this[int index]
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    public event Action doSomething;
}
#endregion

#region 接口可以继承接口
interface IWalk
{
    void Walk();
}
interface IMove : IFly, IMove
{

}
class Test : IMove
{
    public virtual void Fly()
    {

    }

    public string name
    {
        get;
        set;
    }

    public int this[int index]
    {
        get
        {
            return 0;
        }
        set
        {

        }
    }

    public event Action doSomething;

    public void Walk();
}
#endregion

#region 显示实现接口
// 显示实现接口时 不能写访问修饰符
interface IAtk
{
    void Atk();
}

interface ISuperAtk
{
    void Atk();
}

class Player : IAtk, ISuperAtk
{
    // 显示实现接口 就是用 接口明.行为名 去实现
    void IAtk.Atk()
    {
        
    }

    void ISuperAtk.Atk()
    {

    }

    public void Atk()
    {

    }
}

#endregion

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("接口(interface)");
        // 4.接口也遵循里氏替换原则
        IFly f = new Person();

        IMove im = new Test();
        IFly fly= new Test();
        IWalk IW = new Test();

        IAtk ia = new Player();
        ISuperAtk isa = new Player();
        ia.Atk();
        isa.Atk();

        Player p = new Player();
        (p as IAtk).Atk();
        (p as ISuperAtk).Atk();
    }

    /*
        总结：
        继承类：是对象间的集成 包括特征行为等等
        继承接口：是行为间的集成 继承接口的行为规范 按照规范去实现内容
        由于接口也是遵循里氏替换原则 所以可以用接口容器装对象
        那么就可以实现 装载各种毫无冠以但是却有相同行为的对象

        注意：
        1.接口值包含 成员方法、属性、索引器、时间，并且都不实现，都没有访问修饰符
        2.可以继承多个接口，但是只能继承一个类
        3.接口可以继承接口，相当于在进行行为合并，待子类继承时再去实现具体的行为
        4.接口可以被显式实现 主要用于实现不同接口中的同名函数的不同表现
        5.实现的接口方法 可以家 virtual 关键字 之后子类在进行重写
    */
}