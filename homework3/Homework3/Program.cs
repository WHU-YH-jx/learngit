using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework3
{
    public abstract class Product
    {
        public void methodSame()                       //公共方法的实现
        {
            Console.WriteLine("该图形的面积是： ");
        }
        public abstract double Area                    //为产品设置面积属性
        {
            get;
        }
       
    }

    class ConcreteCircle : Product                     //创建具体类 圆
    {
        private int myRadius; //半径

        public ConcreteCircle(int radius) 
        {
            myRadius = radius;
        }

        public override double Area  //实现面积
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }

    }
    class ConcreteTriangle : Product                               //创建具体类 三角形
    {
        public static double a;
        public static double b;
        public static double c;
        private static double Circumference;

        public ConcreteTriangle(int side1, int side2, int side3)   //三条边
        {
            a = side1;
            b = side2;
            c = side3;
            Circumference = (a + b + c) / 2;
        }
        public override double Area
        {
            get
            {
                return Math.Sqrt(Circumference * (Circumference - a) * (Circumference - b) * (Circumference - c));     //运用海伦公式
            }
        }

    }
    class ConcreteSquare : Product
    {
        private int side; //边长

        public ConcreteSquare(int side)
        {
            this.side = side;
        }

        public override double Area //实现面积
        {
            get
            {
                return side*side;
            }
        }

    }
    class ConcreteRectangle : Product
    {
        private int Width;           //宽
        private int Height;          //高

        public ConcreteRectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }
        
    }

    class Factory                       //创建工厂类
    {
         
        public static Product getProduct(String arg,int a)                   //进行函数的重载 分别对应不同的具体类
        {
            Product product = null;
            if (arg == "Circle")
            {
                product = new ConcreteCircle(a);
            }
            else if (arg == "Square")
            {
                product = new ConcreteSquare(a);
            }
            return product;
        }

        public static Product getProduct(String arg, int a,int b)             //进行函数的重载 分别对应不同的具体类
        {
            Product product = null;
            product = new ConcreteRectangle(a, b);
                return product;
        }
        public static Product getProduct(String arg, int a, int b,int c)
        {
            Product product = null;
            product = new ConcreteTriangle(a, b, c);
            return product;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Product product;
            product = Factory.getProduct("Triangle",3,4,5); //通过工厂类创建产品对象  
            product.methodSame();
            Console.WriteLine(product.Area);
        }
    }
}
