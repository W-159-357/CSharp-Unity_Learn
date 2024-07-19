using System.Reflection;

namespace Lesson_38_reflect
{
    #region 一、反射的概念
    // 程序正在运行时，可以查看其他程序集或者自身的元数据
    // 一个运行的程序查看本身或者其它程序的元数据的行为就叫做反射
    // 简答来说     -> 在程序运行时，通过反射可以得到其他程序集或者自己程序集代码的各种信息
    #endregion

    #region 二、反射的作用
    /*
        1.程序运行时得到所有元数据，包括元数据的特性
        2.程序运行时，实例化对象，操作对象
        3.程序运行时创建新对象，用这个对象执行任务
    */
    #endregion

    class Test
    {
        private int i = 1;
        public int j = 0;
        public string str = "1123";

        public Test()
        {

        }

        public Test(int i)
        {
            this.i = i;
        }

        public Test(int i, string str) : this(i)
        {
            this.str = str;
        }

        public void Speak()
        {
            Console.WriteLine(i);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("反射");

            #region 三、语法相关

            #region 1.Type(类的信息类)
            /*
                反射功能的基础
                访问元数据的主要方式
                使用 Type 的成员获取有关类型声明的信息
            */

            #region 获取Type
            // 1.通过GetType获取对象的Type
            int a = 54;
            Type type = a.GetType();
            Console.WriteLine(type);

            // 2.通过typeof得到对象的Type
            Type type2 = typeof(int);
            Console.WriteLine(type2);

            // 3.通过类的名字   注意：类名必须包含命名空间  不然找不到
            Type type3 = Type.GetType("System.Int32");
            Console.WriteLine(type3);
            #endregion

            #region 得到类的程序集
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type2.Assembly);
            Console.WriteLine(type3.Assembly);
            #endregion

            #region 获取类中所有的公共成员
            // 首先得到Type
            var t = typeof(Test);

            // 然后得到所有公共成员     需要引用命名控件 using System.Reflection
            MemberInfo[] infos = t.GetMembers();
            for (int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);
            }
            Console.WriteLine("**********************************");
            #endregion

            #region 获取类的公共构造函数并调用
            // 1.获取所有构造函数
            ConstructorInfo[] ctor = t.GetConstructors();
            for (int i = 0; i < ctor.Length; i++)
            {
                Console.WriteLine(ctor[i]);
            }

            // 2.获取其中一个构造函数 并执行
            // 2.1.得到无参构造
            ConstructorInfo info = t.GetConstructor(new Type[0]);
            // 执行无参构造     无参构造    没有参数    传null
            Test obj = info.Invoke(null) as Test;
            Console.WriteLine(obj.j);

            // 2.2.得到有参构造
            var info2 = t.GetConstructor(new Type[] { typeof(int) });
            obj = info2.Invoke(new object[] { 2 }) as Test;
            Console.WriteLine(obj.str);

            var info3 = t.GetConstructor(new Type[] { typeof(int), typeof(string) });
            obj = info3.Invoke(new object[] { 41, "777" }) as Test;
            Console.WriteLine(obj.str);
            Console.WriteLine("******************************");
            #endregion

            #region 获取类的公共成员变量
            // 1.得到所有成员变量
            FieldInfo[] fieldInfos = t.GetFields();
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                Console.WriteLine(fieldInfos[i]);
            }

            // 2.得到指定名称的公共成员变量
            FieldInfo infoJ = t.GetField("j");
            Console.WriteLine(infoJ);

            // 3.通过反射获取和设置对象的值
            Test test = new Test();
            test.j = 99;
            test.str = "str.........";
            // 3.1.通过反射 获取对象的某个变量的值(通过 GetValue 建立 j 与 Test 类的连接)
            Console.WriteLine(infoJ.GetValue(test));
            // 3.2.通过反射 设置指定对象的某个变量的值(通过 SetValue 设置 j 的值)
            infoJ.SetValue(test, 100);
            Console.WriteLine(infoJ.GetValue(test));
            Console.WriteLine("*****************************");

            #endregion

            #region 获取类的公共成员方法
            // 通过Type类中的 GetMethods() 得到类中的所有方法    MethodInfo 是方法的反射信息
            Type strType = typeof(string);
            MethodInfo[] methods = strType.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine(methods[i]);
            }

            // 1.如果存在方法重载   用Type数据表示参数类型
            MethodInfo subStr = strType.GetMethod("Substring",
                new Type[] { typeof(int), typeof(int) });

            // 2.调用该方法     注意：如果是静态方法    Invoke中的第一个参数传null即可
            string str = "Hello,World!";
            var result = subStr.Invoke(str, new object[] { 6, 6 });
            Console.WriteLine(result);

            #endregion

            #region 其他
            /*
            Type:
                得枚举:
                    GetEnumName
                    GetEnumNames
                
                得事件:
                    GetEvent
                    GetEvents

                得接口:
                    GetInterface
                    GetInterfaces

                得数据:
                    GetProperty
                    GetPropertys
            */
            #endregion

            #endregion

            #region 2.Assembly
            /*
                主要用来加载其他程序集，加载后 才能用 Type 来使用其他程序集中的信息
                如果想要使用不是自己程序集中的内容  需要先加载程序集    eg: .dll

                三种加载程序集的函数
                    加载同一文件下的其他程序集
                        1.Assembly assembly = Assembly.Load("程序集名称");
                    加载不在同一文件下的其他程序集
                        2.Assembly assembly = Assembly.LoadFrom("包含程序集清单的文件的名称或路径");
                        3.Assembly assembly = Assembly.LoadFile("要加载的文件的完全限定路径");      绝对路径
            */

            // 1.先加载一个指定的程序集     使用 @ 来取消转义字符
            Assembly assembly = Assembly.LoadFrom(@"D:\src\CSharp_Learn\CSharp-Unity_Learn\Lesson_36_Thread\bin\Debug\net8.0\Lesson_36_Thread");
            Type[] types = assembly.GetTypes();
            for(int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            } 

            // 2.再加载程序集中的一个类对象     之后才能使用反射
            Type icon = assembly.GetType("Lesson_36_Thread.Icon");
            MemberInfo[] members = icon.GetMembers();
            for(int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            } 

            // 3.通过反射   实例化一个 icon对象
            // 首先得到枚举 Type 来得到可以传入的参数
            Type moveDir = assembly.GetType("Lesson_36_Thread.E_MoveDir");
            FieldInfo right = assembly.GetField("Right");

            // 直接实例化对象
            object iconObj = Activator.CreateInstance(icon, 10, 5, right.GetValue(null));

            // 得到对象中的方法 通过反射
            MethodInfo move = icon.GetMethod("Move");
            MethodInfo draw = icon.GetMethod("Draw");
            MethodInfo clear = icon.GetMethod("Clear");

            Console.Clear();
            while(true)
            {
                Thread.Sleep(1000);
                clear.Invoke(iconObj, null);
                move.Invoke(iconObj, null);
                draw.Invoke(iconObj, null);
            }
 
            #endregion

            #region 3.Activator
            /*
                用于快速实例化对象的类
                用于将Type对象快捷实例化为对象
                先得到Type 然后 快速实例化为一个对象
            */
            var testType = typeof(Test);
            Console.WriteLine("*****************************************");

            // 1.无参构造       使用 泛型方法
            // Test testObj = Activator.CreateInstance(testType) as Type;
            Test testObj = Activator.CreateInstance<Test>();
            Console.WriteLine(testObj.j);

            // 2.有参构造
            testObj = Activator.CreateInstance(testType, 99) as Test;
            Console.WriteLine(testObj.j);

            testObj = Activator.CreateInstance(testType, 99, "wwwxxj") as Test;
            Console.WriteLine(testObj.j);
            Console.WriteLine(testObj.str);

            #endregion

            #endregion
        }
    }

    /*
        总结:
            在程序运行时，通过反射可以得到其他程序集或者自己的程序集代码的各种信息
            类、函数、变量、对象等等，实例化他们，执行他们，操作他们

        关键类:
            Type
            Assembly
            Activator

        对于我们的意义:
            在初中级阶段    基本不会使用反射
            为了之后学习Unity引擎的基本工作原理做铺垫
            Unity引擎的基本工作机制 就是建立在反射的基础上
    */
};

