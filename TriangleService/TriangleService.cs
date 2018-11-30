using System;

namespace Triangle.Services
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Triangle app. Please enter each triangle's side lengths as prompted.");
            try
            {
                Console.WriteLine("Please enter side a:");
                int sideA = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter side b:");
                int sideB = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter side c:");
                int sideC = int.Parse(Console.ReadLine());

                // Disallow numbers greater than 46340 as they will cause us to exceed the integer limit when squaring them
                if (sideA > 46340 || sideB > 46340 || sideC > 46340)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // Negative and zero values are not allowed
                if (sideA < 1 || sideB < 1 || sideC < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                TriangleService triangle = new TriangleService(sideA, sideB, sideC);
                if (triangle.isValidTriangle())
                {
                    string triangleType = triangle.getTriangleClassification();
                    if (!triangleType.Equals("triangle"))
                    {
                        triangleType += " triangle";
                    }
                    Console.WriteLine("Theses side lengths produce a valid " + triangleType + ".");
                }
                else
                {
                    Console.WriteLine("The sides provided do not appear to make up a valid triangle.");
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Whoops. It looks like you did not correctly enter the triangle's information. Please re-run the program and ensure you only enter an integer for each triangle's side.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Whoops. This program only supports numbers greater than or equal to 1 and smaller than 46340.");
            }
        }
    }

    public class TriangleService
    {
        private int sideA;
        private int sideB;
        private int sideC;
        public TriangleService(int sideA, int sideB, int sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public bool isValidTriangle()
        {
            // A simple calculation for this is to know that no two sides added up can be less than the other side (EG 3+4 > 5, so the above triangle is valid)
            return ((this.sideA + this.sideB) > this.sideC && (this.sideA + this.sideC) > this.sideB && (this.sideB + this.sideC) > this.sideA);
        }

        public string getTriangleClassification()
        {
            if (this.sideA == this.sideB && this.sideB == this.sideC)
            {
                return "equilateral";
            }
            else if (this.sideA == this.sideB || this.sideB == this.sideA || this.sideA == this.sideC)
            {
                return "isosceles";
            }
            else
            {
                int sideASqr = this.sideA * this.sideA;
                int sideBSqr = this.sideB * this.sideB;
                int sideCSqr = this.sideC * this.sideC;
                if (sideASqr == (sideBSqr + sideCSqr) || sideBSqr == (sideASqr + sideCSqr) || sideCSqr == (sideBSqr + sideASqr))
                {
                    return "right";
                }
            }
            return "triangle";
        }

        public bool IsValidInput(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first");
        }
    }
}