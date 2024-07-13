namespace Lesson_15_Richter_substitution;

class Monster
{
    public string name = "";
}

class Boss : Monster
{
    public void Skill()
    {
        Console.WriteLine("Boss{0}释放了死亡射线", name);
    }
}

class Goblin : Monster
{
    public void goblinAtk()
    {
        Random random = new Random();
        int damage = random.Next(1, 100);
        Console.WriteLine("小怪{0}造成了{1}点伤害", name, damage);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("里氏替换");

        #region 里氏替换的使用
        List<Monster> list = new List<Monster>();
        for (int i = 0; i < 10; i++)
        {
            Random random = new Random();
            int type = random.Next(0, 2);
            if (type == 0)
            {
                Monster goblinName = new Goblin();
                goblinName.name = "goblin" + i.ToString();
                list.Add(goblinName);
            }
            else
            {
                Monster bossName = new Boss();
                bossName.name = "boss" + i.ToString();
                list.Add(bossName);
            }
        }

        foreach (var item in list)
        {
            // if (item is Boss) (item as Boss).Skill();
            // else if (item is Goblin) (item as Goblin).goblinAtk();
            #region 如下写法更好, 不会出现可以空引用的警告
            if (item is Boss boss) boss.Skill();
            else if (item is Goblin goblin) goblin.goblinAtk();
            #endregion
        }
        #endregion
    }
}
