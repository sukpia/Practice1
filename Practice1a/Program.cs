using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1a
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare objects of the derived classes and test which version of ShowDetails is run, base or derived.
            TestCars1();

            //Declare objects of the base classes, instantiated with the derived classes, and repeat the tests.
            TestCars2();

            // Declare objects of the derived classes and call ShowDetails directly.
            TestCars3();

            // Declare objets of the base class, instantiated with the derived classes, and repeat the tests.
            TestCars4();

            Console.Read();
        }

        public static void TestCars1()
        {
            Console.WriteLine("\nTestCars1");
            Console.WriteLine("-----------");

            Car car1 = new Car();
            car1.DescribeCar();
            Console.WriteLine("-----------");

            // Notice the output from this test case. The new modifier is
            // used in the definition of ShowDetails in the ConvertibleCar class.
            ConvertibleCar car2 = new ConvertibleCar();
            car2.DescribeCar();
            Console.WriteLine("-----------");

            Minivan car3 = new Minivan();
            car3.DescribeCar();
            Console.WriteLine("-----------");
        }
        // Output:  
        // TestCars1  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Carries seven people.  
        // ----------  

        public static void TestCars2()
        {
            Console.WriteLine("\nTestCars2");
            Console.WriteLine("-----------");

            var cars = new List<Car> { new Car(), new ConvertibleCar(), new Minivan() };

            foreach (var car in cars)
            {
                car.DescribeCar();
                Console.WriteLine("-----------");
            }
        }
        // Output:  
        // TestCars2  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Standard transportation.  
        // ----------  
        // Four wheels and an engine.  
        // Carries seven people.  
        // ----------  

        public static void TestCars3()
        {
            Console.WriteLine("\nTestCars3");
            Console.WriteLine("-----------");
            ConvertibleCar car2 = new ConvertibleCar();
            Minivan car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
        }
        // Output:  
        // TestCars3  
        // ----------  
        // A roof that opens up.  
        // Carries seven people.

        public static void TestCars4()
        {
            Console.WriteLine("\nTestCars4");
            Console.WriteLine("-----------");
            Car car2 = new ConvertibleCar();
            Car car3 = new Minivan();
            car2.ShowDetails();
            car3.ShowDetails();
        }
        // Output:  
        // TestCars4  
        // ----------  
        // Standard transportation.  
        // Carries seven people.
    }

    // Define the base class, Car. The class defines 2 methods,
    // DescribeCar and ShowDetails. DescribeCar calls ShowDetails, and each derived class also defines a ShowDetails method.
    // The example tests which version of ShowDetails is selected. the base class method or the derived class method.
    class Car
    {
        public void DescribeCar()
        {
            Console.WriteLine("Four wheels and an engine.");
            ShowDetails();
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine("Standard transportation.");
        }
    }

    // Define the derived classes.

    // Class ConvertibleCar uses the new modifier to acknowledge that ShowDetails hides the base class method.
    class ConvertibleCar : Car
    {
        public new void ShowDetails()
        {
            Console.WriteLine("A roof that opens up.");
        }
    }

    // Class Minivan uses the override modifier to specify that ShowDetails extends the base class method.
    class Minivan : Car
    {
        public override void ShowDetails()
        {
            Console.WriteLine("Carries seven people.");
        }
    }
}
