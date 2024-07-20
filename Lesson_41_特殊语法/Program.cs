using System;
using System.Collections;
using System.Collections.Generic;
namespace Lesson_41_特殊语法
{
    class Person
    {
        public int money;
        public bool sex;
        public string name
        {
            get;
            set;
        }

        public int age
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("特殊语法");

            #region 一、设置对象初始化
            Person person = new Person() { age = 18, name = "wxj", sex = true };
            #endregion

            #region 二、设置集合初始值
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            List<Person> listPerson = new List<Person>() { new Person(), new Person() { age = 18 } };

            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                { 1, "111" },
                { 2, "222" },
                { 3, "333" }
            };
            #endregion

            #region 三、匿名类型
            var v = new {age = 10, money = 11, name = "坦塔塔"};
            Console.WriteLine(v.age + " " + v.money + " " + v.name);
            #endregion

            #region 四、可空类型        ?
            // 1.值类型不能赋值为空     eg-> int a = null
            // 2.声明时 在值类型后面加? 可以赋值为空
            int? a = 10;
            // 3.判断是否为空
            if (a.HasValue)
            {
                Console.WriteLine(a.Value);
                Console.WriteLine(a);
            }

            // 4.安全获取可空类型值
            int? value = null;
            // 4-1.如果为空 默认返回值类型的默认值
            Console.WriteLine(value.GetValueOrDefault());
            // 4-2.也可以指定一个默认值
            Console.WriteLine(value.GetValueOrDefault(100));
            Console.WriteLine(value);


            object o = null;
            if (o != null)
            {
                o.ToString();
            }
            o?.ToString();      // 与上面效果一致（语法糖）
            #endregion

            #region 五、空合并操作符        ??
            int? intV = null;
            int intI = intV == null ? 100 : intV.Value; 
            intI = intV ?? 100;         // 与上方效果一致
            Console.WriteLine(intI);

            string str = null;
            str = str ?? "hahahahahah";
            Console.WriteLine(str);

            #endregion  

            #region 六、内插字符串      $
            string name = "呜呜呜";
            Console.WriteLine($"{name}, 天天天天奶奶");
            #endregion
        }
    }
};


