using System;

namespace Lesson_01_enum
{
    #region 1. 在哪里申明枚举
    // 1. namespace语句块中（常用）
    // 2. class语句块中 struct语句块中
    // 3. 注意：枚举不能在函数语句块中
    #endregion
    #region 2.枚举命名规范
    // 以E或者E_开头 作为我们的命名规范
    enum E_MonsterType
    {
        Normal,
        Boss,
    }

    enum E_PlayerType
    {
        Main,
        Other,
    }

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum");
            // 申请枚举变量     枚举类型 枚举名 = 枚举类型.枚举值
            E_PlayerType playerType = E_PlayerType.Main;

            if (playerType == E_PlayerType.Main)
            {
                Console.WriteLine("主玩家逻辑");
            }
            else if (playerType == E_PlayerType.Other)
            {
                Console.WriteLine("其他玩家逻辑");
            }

            // 枚举和switch天生一对
            E_MonsterType monsterType = E_MonsterType.Boss;
            switch (monsterType)
            {
                case E_MonsterType.Normal:
                    Console.WriteLine("普通怪物逻辑");
                    break;
                case E_MonsterType.Boss:
                    Console.WriteLine("Boss逻辑");
                    break;
                default:
                    break;
            }

            #region 3.枚举的类型转换
            // 1.enum to int
            int i = (int)playerType;
            Console.WriteLine(i);
            // int to enum
            playerType = 0;

            // 2.enum to string
            string str = playerType.ToString();
            Console.WriteLine(str);
            // string to enum   (枚举类型)Enum.Parse(typeof(枚举类型), "用于转换的对应枚举项的字符串")
            playerType = (E_PlayerType)Enum.Parse(typeof(E_PlayerType), "Other");
            Console.WriteLine(playerType);
            #endregion

            #region 4. 枚举的作用
            // 在游戏开发中，对象有时候有很多的状态
            // 标识用户当前的状态
            #endregion
        }
    }
}
