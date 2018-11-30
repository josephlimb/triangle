using NUnit.Framework;
using Triangle.Services;

namespace Triangle.UnitTests.Services
{
    [TestFixture]
    public class TriangleService_IsValidTriangle
    {
        #region Valid_Triangles
        [TestCase(12, 16, 20)] // Right Triangle
        [TestCase(12, 8, 15)] // Obtuse Triangle
        [TestCase(12, 6, 14)] // Acute Triangle
        [TestCase(1, 1, 1)] // Equilateral Triangle
        [TestCase(76, 76, 76)] // Equilateral Triangle
        [TestCase(26, 26, 26)] // Equilateral Triangle
        public void ReturnTrueForValidTriangles(int sideA, int sideB, int sideC)
        {
            TriangleService triangle = new TriangleService(sideA, sideB, sideC);
            Assert.IsTrue(triangle.isValidTriangle(), $"The triangle ({sideA}, {sideB}, {sideC}) should be a valid triangle");
        }
        #endregion

        #region InValid_Triangles
        [TestCase(-12, 16, 20)]
        [TestCase(12, -16, 20)]
        [TestCase(12, 16, -20)]
        [TestCase(1, 1, 16)]
        [TestCase(1, 6, 1)]
        [TestCase(6, 1, 1)]
        [TestCase(1, 1, 2)]
        public void ReturnFalseForInValidTriangles(int sideA, int sideB, int sideC)
        {
            TriangleService triangle = new TriangleService(sideA, sideB, sideC);
            Assert.IsFalse(triangle.isValidTriangle(), $"The triangle ({sideA}, {sideB}, {sideC}) should be an invalid triangle");
        }
        #endregion
    }
}