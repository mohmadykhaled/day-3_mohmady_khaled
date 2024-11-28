using System;
using System.Reflection.Metadata;
using System.Text;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace day_3
{
    internal class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            #region problem1
            Console.Write("Please enter a number: ");
            string s = Console.ReadLine();

            try
            {

                int parsedValue = int.Parse(s);
                Console.WriteLine("Converted using int.Parse: " + parsedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input is not a valid number for int.Parse.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error: The input is empty for int.Parse.");
            }

            try
            {

                int convertedValue = Convert.ToInt32(s);
                Console.WriteLine("Converted using Convert.ToInt32: " + convertedValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: The input is not a valid number for Convert.ToInt32.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error: The input is empty for Convert.ToInt32.");
            }


            Console.WriteLine("Program execution completed.");
            #endregion
            /*
             * Difference Between int.Parse and Convert.ToInt32 When Handling null?
               >> int.Parse: Cannot handle null and will throw an ArgumentNullException if the input is null. It expects a valid numeric string.

               >> Convert.ToInt32: Can handle null without throwing an exception. If the input is null, it returns 0 instead of an error.
        
             */

            #region problem2
            Console.Write("Please enter a number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {

                Console.WriteLine($"You entered a valid number: {result}");
            }
            else
            {

                Console.WriteLine("ERROR: Invalid input! ");
            }
            #endregion
            /*
              Why is TryParse Recommended Over Parse in User-Facing Applications?
                No Exceptions:
                TryParse is safer in user-facing applications because it does not throw exceptions.

                When you use int.Parse, an invalid input (such as a non-numeric string) results in a FormatException being thrown,
                which you need to handle with a try-catch block.

                This adds complexity and can make the application less responsive if errors are frequent.
                TryParse, on the other hand,simply returns false if the input is invalid,
                allowing you to handle the error without the overhead of exception handling.
            */

            #region problem3
            object obj;

            obj = 42;
            Console.WriteLine($"HashCode of int (42): {obj.GetHashCode()}");

        
            obj = "Hello, world!";
            Console.WriteLine($"HashCode of string ('Hello, world!'): {obj.GetHashCode()}");

            obj = 3.14159;
            Console.WriteLine($"HashCode of double (3.14159): {obj.GetHashCode()}");
            #endregion
            /*
            What is the Purpose of the GetHashCode() Method?
            The GetHashCode() method is a part of the base System.

            Object class, and it provides a hash value (an int) that is used for hashing-based operations.
            The primary purpose of GetHashCode() is as follows:
               Efficient Lookups in Hash-Based Collections,Object Comparison,Consistency and Uniqueness
           */


            #region problem4
            Person person1 = new Person();
            person1.Name = "mohmady";
            person1.Age = 20;

            Person person2 = person1;


            person1.Name = "khaled";
            person1.Age = 25;


            Console.WriteLine($"Person2's Name: {person2.Name}, Age: {person2.Age}");

            Console.WriteLine($"Person1's Name: {person1.Name}, Age: {person1.Age}");

            /*
           ignificance of Reference Equality in .NET:
           In .NET, reference equality refers to the situation where two variables (references) point to the same memory location,
           they refer to the same object instance.
           The significance of reference equality includes the following:

           Shared Mutability,
           Memory Efficiency,
           Performance Considerations,
           Equality Comparison
           */
            #endregion


            #region problem 5
            string message = "Hello";

            // Print the GetHashCode before modification
            Console.WriteLine($"Original message: {message}");
            Console.WriteLine($"GetHashCode before modification: {message.GetHashCode()}");

            
            message = message + " mohmady";  

            // Print the GetHashCode after modification
            Console.WriteLine($"Modified message: {message}");
            Console.WriteLine($"GetHashCode after modification: {message.GetHashCode()}");

            /*Why Is String Immutable in C#?
            Performance Benefits: Immutable strings help to conserve memory.
               Since strings are immutable, multiple references can point to the same string object 
           without risk of unintended modifications.
           This reduces the need to create multiple copies of the same string.
            Interning: C# uses string interning,
             which means that identical string literals are stored only once in memory. */

            #endregion


            #region problem6
            StringBuilder sb = new StringBuilder("hello mohmady");

            // Print the GetHashCode before modification
            Console.WriteLine($"Original StringBuilder: {sb.ToString()}");

            Console.WriteLine($"GetHashCode before modification: {sb.GetHashCode()}");

            
            sb.Append(" Welcome to the C# World mohmady!");

            
            Console.WriteLine($"Modified StringBuilder: {sb.ToString()}");
            Console.WriteLine($"GetHashCode after modification: {sb.GetHashCode()}");

            /*How StringBuilder Addresses Inefficiencies of String Concatenation:
            strings  immutable.
            This means that each time you modify a string,
             new string is created, and the old string discarded.
           especially in loops or when dealing with large strings.
             Each concatenation involves allocating new memory, copying data from the old string,
            and then adding the new content. This can cause performance problems,
               particularly with large or numerous string modifications.*/


            #endregion

            #region problem7
            /*
   *  Question: Why is StringBuilder faster for large-scale string modifications?
   * 
   In C#, strings are immutable, meaning they cannot be changed once created. Any modification
            
            such as concatenation or replacement, creates a new string object.

   This process involves:

      Allocating new memory for the modified string.
      Copying the original string.
      Appending new content, leading to performance overhead in repeated modifications.
      StringBuilder is much faster for large-scale modifications because:

      It works with the same memory space without creating new objects.
      Reduces memory allocation and copying overhead.

  */
            #endregion


            #region problem 8
            Console.Write("Enter the first number: ");
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int input2 = int.Parse(Console.ReadLine());

            
            int sum = input1 + input2;

            Console.WriteLine("Concatenation: Sum is " + input1 + " + " + input2 + " = " + sum);

            Console.WriteLine("Composite formatting: Sum is {0} + {1} = {2}", input1, input2, sum);

            Console.WriteLine($"String interpolation: Sum is {input1} + {input2} = {sum}");
            /*Which String Formatting Method is Most Used and Why?
           In modern C#,
              string interpolation ($) is genera lly considered the most preferred
           and commonly used string formatting method. Here's why:

          Clarity and Readability:

          String Interpolation is the most readable and straightforward method.
             It directly integrates expressions inside the string,
          making the code more intuitive to read and maintain.
         For ex:
            Console.WriteLine($"Sum is {input1} + {input2} = {sum}");
           This is clear because you can directly see the expression inside the {} within the string.*/



            #endregion

            #region problem 9
            StringBuilder sbb = new StringBuilder("Hello World");

          
            sbb.Append(" - Welcome to C# programming!");
            Console.WriteLine($"After Append: {sbb}");

           
            sbb.Replace("World", "Universe");
            Console.WriteLine($"After Replace: {sbb}");

           
            sbb.Insert(6, "Amazing ");
            Console.WriteLine($"After Insert: {sbb}");

            sbb.Remove(6, 8);  
            Console.WriteLine($"After Remove: {sbb}");

             /*How StringBuilder Handles Frequent Modifications:
               Internal Buffer:
            StringBuilder uses an internal buffer Instead of creating new string objects each time it is modified
           (like in the case of immutable strings),
              StringBuilder modifies the contents of its buffer.
             This reduces memory usage and eliminates the overhead of
               allocating and copying data each time a modification is made.*/
            #endregion
        }
    }
}