// 1/19/2017
// I wrote this project to practice C#
// All this codes are from msdn website:
// https://msdn.microsoft.com/en-us/library/ms173153.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass(); //bc is of type BaseClass, and its value is of type Baseclass. It can only access Method1.
            DerivedClass dc = new DerivedClass(); //dc is of type DerivedClass, and its value if of type DerivedClass. It can access both Method1 and Method2.
            BaseClass bcdc = new DerivedClass(); //bcdc is of type BaseClass, and its value is of type DerivedClass. It can only access Method1.

            // The following 2 calls do what you would expect. They call the methods that are defined in BaseClass
            bc.Method1();
            bc.Method2();
            // Output:
            // Base - Method1
            // Base - Method2

            // The following 2 calls do what you would expect. They call the methods that are defined in DerivedClass
            dc.Method1();
            dc.Method2();
            // Output:
            // Derived - Method1
            // Derived - Method2

            // The following 2 calls produce different results, depending on whether override (Method1) or new (Method2) is used.
            bcdc.Method1();
            bcdc.Method2();
            // Output:
            // Derived - Method1
            // Base - Method2

            Console.Read();
        }
    }

    class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }

    class DerivedClass : BaseClass
    {
        // Add new to the definition of Method2 to to hide the inherited BaseClass Method2
        public new void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }

        // the use of override modifier enables bcdc access the Method1 in DerivedClass. In order to use the override modifier, u need to put virtual modifier in BaseClass Method1
        // use override to extend the base class method.
        public override void Method1()
        {
            Console.WriteLine("Derived - Method1");
        }
    }
}
