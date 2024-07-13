namespace Lesson_16_Voc_Abstract;

#region 多态
class GameObject
{
    public string name;
    public GameObject(string name)
    {
        this.name = name;
    }
    public virtual void Atk()
    {
        Console.WriteLine("游戏对象{0}进行攻击", name);
    }
}

class Player : GameObject
{
    public Player(string name) : base(name)
    {

    }

    override public void Atk()
    {
        // 可以通过 base 来保留父类的行为 eg: base.Atk();
        base.Atk();
        Console.WriteLine("玩家对象{0}进行攻击", name);
    }
}

class Monster : GameObject
{
    public Monster(string name) : base(name) { }
    public override void Atk()
    {
        Console.WriteLine("怪物对象进行攻击");
    }
}
#endregion

#region 抽象类
abstract class Goods
{
    // 抽象类中 封装的所有知识点都可以在其中书写
    public string name;

    // 可以在抽象类中写抽象函数
}

class Water : Goods
{

}

abstract class Fruits
{
    public string name;

    // 抽象方法只能在抽象类中使用，不需要写函数体
    public abstract void Bad();
    public virtual void Test()
    {
        // 可以选择是否写函数体
    }
}

class Apple : Fruits
{
    // 继承抽象类后必须实现抽象类的抽象方法，否则会报错
    // 虚函数可以选择是否进行重写
    public override void Bad()
    {
        throw new System.NotImplementedException();
    }
}

class SuperApple : Apple
{
    // 虚函数和抽象函数 都可以被子类无限的 去重写
    public override void Bad()
    {
        base.Bad();
    }
    public override void Test()
    {
        base.Test();
    }
}
#endregion

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("多态_VOB");

        #region 多态的使用
        GameObject p = new Player("唐老C");
        p.Atk();    // 会调用子类的方法

        GameObject m = new Monster("丑八怪");
        m.Atk();
        #endregion

        Console.WriteLine("-------------------");
        Console.WriteLine("抽象类");

        #region 抽象类的使用
        // 抽象类不能被实例化
        // Goods g = new Goods();
        // 但是可以遵循里氏替换原则
        Goods t = new Water();
        #endregion
    }

    // 抽象类总结
    // 抽象类 被abstract修饰的类 不能被实例化 可以包含抽象函数
    // 抽象函数 没有函数体的纯虚函数 继承后必须要去实现
    // 注意：
    // 如果选择普通类还是抽象类
    // 不希望被实例化的对象，但相对比较抽象的类可以使用抽象类
    // 父类中的行为不太需要被实现的，只希望子类去定义具体的规则的 可以选择 抽象类然后使用其中的抽象方法来定义规则
}
