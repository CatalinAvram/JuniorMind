using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ți se dă o listă de tronsoane verticale și orizontale consecutive de dimensiuni fixe.
Scrie o funcție care verifică dacă tronsoanele se intersectează. Dacă se intersectează întoarce primul punct de intersecție.
Notă: având în vedere că tronsoanele sunt de dimensiuni fixe, alege cel mai simplu mod de a le reprezenta, 
de ex: ca și o succesiune de direcții stânga, dreapta, sus, jos.*/

namespace Intersection
{
    public enum Directions
    {
        Right, Left, Up, Down
    }

    public struct Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [TestClass]
    public class IntersectionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Directions[] directions = new Directions[] { Directions.Right, Directions.Down, Directions.Left, Directions.Up };
            Assert.AreEqual(new Point(0, 0), FindIntersectionPoint(directions, 1));
        }

        private Point FindIntersectionPoint(Directions[] directions, int dimension)
        {
            Point[] passingPoints = new Point[directions.Length];
            Point currentPoint = new Point();

            for(int i = 1; i <= directions.Length; i++)
            {
                if (directions[i - 1] == Directions.Right)                   
                    currentPoint = new Point(passingPoints[i - 1].x + dimension, passingPoints[i - 1].y);
                if (directions[i - 1] == Directions.Down)
                    currentPoint = new Point(passingPoints[i - 1].x, passingPoints[i - 1].y - dimension);
                if (directions[i - 1] == Directions.Left)
                    currentPoint = new Point(passingPoints[i - 1].x - dimension, passingPoints[i - 1].y);
                if (directions[i - 1] == Directions.Up)
                    currentPoint = new Point(passingPoints[i - 1].x, passingPoints[i - 1].y + dimension);

                for (int j = 0; j < i; j++)
                    if (passingPoints[j].x == currentPoint.x && passingPoints[j].y == currentPoint.y)
                        return currentPoint;
                passingPoints[i] = currentPoint;                               
            }
            return new Point(9, 9);
        }
    }
}
