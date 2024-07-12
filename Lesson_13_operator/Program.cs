namespace Lesson_13_operator;

class Point
{
    #region 重载运算符使用的基础写法
    // public static 返回类型 operator 运算符(参数列表)
    #endregion

    public double x;
    public double y;

    public static Point operator +(Point p1, Point p2)
    {
        Point p = new Point();
        p.x = p1.x + p2.x;
        p.y = p1.y + p2.y;
        return p;
    }
}

class Vector3
{
    public int x;
    public int y;
    public int z;

    public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
    {
        Vector3 vec3 = new Vector3();
        vec3.x = vec1.x + vec2.x;
        vec3.y = vec1.y + vec2.y;
        vec3.z = vec1.z + vec2.z;
        return vec3;
    }

    public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
    {
        Vector3 vec3 = new Vector3();
        vec3.x = vec1.x - vec2.x;
        vec3.y = vec1.y - vec2.y;
        vec3.z = vec1.z - vec2.z;
        return vec3;
    }

    public static Vector3 operator *(Vector3 vector, int num)
    {
        Vector3 newVector3 = new Vector3();
        newVector3.x = vector.x * num;
        newVector3.y = vector.y * num;
        newVector3.z = vector.z * num;
        return newVector3;
    }

    public static Vector3 operator *(int num, Vector3 vector)
    {
        Vector3 newVector3 = new Vector3();
        newVector3.x = vector.x * num;
        newVector3.y = vector.y * num;
        newVector3.z = vector.z * num;
        return newVector3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        #region 重载运算符的使用
        Point p = new Point();
        p.x = 1.0d;
        p.y = 1.0d;
        Point p2 = new Point();
        p2.x = 2.5d;
        p2.y = 2.3d;
        
        var p3 = p + p2;
        Console.WriteLine("x:{0}, y:{1}", p3.x, p3.y);

        Vector3 vector = new Vector3();
        vector.x = 1;
        vector.y = 1;
        vector.z = 1;
        Vector3 vector2 = new Vector3();
        vector2.x = 2;
        vector2.y = 3;
        vector2.z = 4;
        
        var v1 = vector + vector2;
        Console.WriteLine("x:{0} y:{1} z:{2}", v1.x, v1.y, v1.z);
        var v2 = vector - vector2;
        Console.WriteLine("x:{0} y:{1} z:{2}", v2.x, v2.y, v2.z);
        var v3 = vector2 * 3;
        Console.WriteLine("x:{0} y:{1} z:{2}", v3.x, v3.y, v3.z);
        #endregion
    }
}
