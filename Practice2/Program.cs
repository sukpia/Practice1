// 1/19/2017
// What is the virtual keyword??
// reference link : https://msdn.microsoft.com/en-us/library/9fkccyh4.aspx
// What is sealed modifier?
// reference link : https://msdn.microsoft.com/en-us/library/88c54tsw.aspx
// What is override modifier?
// reference link : https://msdn.microsoft.com/en-us/library/ebca9ah3.aspx
// What is abstract modifier?
// reference link : https://msdn.microsoft.com/en-us/library/sf985hc5.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "Terri";
            MyBaseClass basename = new MyBaseClass();
            MyDerivedClass derivedname = new MyDerivedClass();
            //basename.Name = s;
            //basename.Number = 20;

            // Display results:
            Console.WriteLine("Base Class Name is {0:S}", basename.Name );
            Console.WriteLine("Base Class Number is {0:F2}", basename.Number);
            Console.WriteLine("Derived Class Name is {0:S}", derivedname.Name);
            Console.WriteLine("Derived Class Number is {0:F2}", derivedname.Number);

            double r = 3.0, h = 5.0;
            Shape c = new Circle(r);
            Shape s = new Sphere(r);
            Shape l = new Cylinder(r, h);
            // Display results:
            Console.WriteLine("Area of Circle = {0:F2}", c.Area());
            Console.WriteLine("Area of Sphere = {0:F2}", s.Area());
            Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());

            Console.Read();
        }

        public class Shape
        {
            public const double PI = Math.PI;
            protected double x, y;
            public Shape()
            {

            }
            public Shape(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public virtual double Area()
            {
                return x * y;
            }
        }

        public class Circle : Shape
        {
            public Circle(double r) : base(r, 0)
            {

            }
            public override double Area()
            {
                return PI * x * x;
            }
        }

        public class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0)
            {

            }
            public override double Area()
            {
                return 4 * PI * x * x;
            }
        }

        public class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h)
            {

            }
            public override double Area()
            {
                return 2 * PI * x * x + 2 * PI * x * y;
            }
        }
    }

    class MyBaseClass
    {
        // virtual auto-implemented property. Overrides can only provide specialized behavior if they implement get and set accessor.
        public virtual string Name { get; set; }

        // ordinary virtual property with backing field.
        private int num;
        public virtual int Number
        {
            get { return num; }
            set { num = value; }
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        private string name;

        // Override auto-implemented property with ordinary property to provide specialized accessor behavior.
        public override string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value != String.Empty)
                {
                    name = value;
                }
                else
                {
                    name = "Unknown";
                }
            }
        }
    }

    sealed class SealedClass
    {
        public int x;
        public int y;
    }

    // you may try to inherit form the sealed class by using the following statement:
    // class MyDerivedClass : SealedClass {} // Error

    class SealedTest2
    {
        static void Main()
        {
            SealedClass sc = new SealedClass();
            sc.x = 110;
            sc.y = 150;
            Console.WriteLine("x = {0}, y = {1}", sc.x, sc.y);
        }
    }
    // Output: x = 110, y = 150

    // The abstract class is intended only to be a base class of other classes.
    // It indicates that thing being modified has a missing or incomplete implementation
    // Members marked as abstract, must be implemented by classes that derive from the abstract class
    abstract class ShapeClass
    {
        abstract public int Area();
    }

    class Square : ShapeClass
    {
        int side = 0;
        
        public Square(int n)
        {
            side = n;
        }
        // Area method is required to avoid a compile-time error
        public override int Area()
        {
            return side * side;
        }
    }
}
