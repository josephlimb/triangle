using NUnit.Framework;
using Triangle.Services;

namespace Triangle.UnitTests.Services
{
    [TestFixture]
    public class TriangleService_ValidateClassification
    {
        #region Valid_Classifications
        [TestCase(12, 16, 20, "right")] // Right Triangle
        [TestCase(5, 12, 13, "right")] // Right Triangle
        [TestCase(1, 1, 1, "equilateral")] // Equilateral Triangle
        [TestCase(76, 76, 76, "equilateral")] // Equilateral Triangle
        [TestCase(26, 26, 26, "equilateral")] // Equilateral Triangle
        [TestCase(26, 26, 2, "isosceles")] // Isosceles Triangle
        [TestCase(1, 1, 2, "isosceles")] // Isosceles Triangle
        [TestCase(76, 7, 76, "isosceles")] // Isosceles Triangle
        [TestCase(12, 8, 15, "triangle")] // Obtuse Triangle
        [TestCase(12, 6, 14, "triangle")] // Acute Triangle
        public void ReturnTrueForValidTriangles(int sideA, int sideB, int sideC, string type)
        {
            TriangleService triangle = new TriangleService(sideA, sideB, sideC);
            Assert.IsTrue(triangle.getTriangleClassification().Equals(type), $"The triangle ({sideA}, {sideB}, {sideC}) should be a valid triangle");
        }
        #endregion
    }
}