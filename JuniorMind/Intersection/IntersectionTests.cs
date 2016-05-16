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
        public void Intersection()
        {
            Directions[] directions = new Directions[] { Directions.Right, Directions.Down, Directions.Left, Directions.Up };
            Assert.AreEqual(new Point(0, 0), FindIntersectionPoint(directions, 1));
        }

        [TestMethod]
        public void NoIntersection()
        {
            Directions[] directions = new Directions[] { Directions.Right, Directions.Down, Directions.Right };
            Assert.AreEqual(new Point(2, -1), FindIntersectionPoint(directions, 1));
        }

        private Point FindIntersectionPoint(Directions[] directions, int dimension)
        {
            Point[] passingPoints = new Point[1];
            Point currentPoint = new Point();               
            for(int i = 1; i <= directions.Length; i++)
            {
                currentPoint = CheckDirections(directions, dimension, passingPoints, currentPoint, i);
                if (IsInArray(passingPoints, currentPoint))
                    return currentPoint;
                passingPoints = AddIntoArray(passingPoints, currentPoint);
            }
            return passingPoints[passingPoints.Length - 1];
        }

        private static Point CheckDirections(Directions[] directions, int dimension, Point[] passingPoints, Point currentPoint, int i)
        {
            switch (directions[i - 1])
            {
                case Directions.Right:
                    currentPoint = new Point(passingPoints[i - 1].x + dimension, passingPoints[i - 1].y);
                    break;
                case Directions.Left:
                    currentPoint = new Point(passingPoints[i - 1].x - dimension, passingPoints[i - 1].y);
                    break;
                case Directions.Up:
                    currentPoint = new Point(passingPoints[i - 1].x, passingPoints[i - 1].y + dimension);
                    break;
                case Directions.Down:
                    currentPoint = new Point(passingPoints[i - 1].x, passingPoints[i - 1].y - dimension);
                    break;
            }
            return currentPoint;
        }

        private static Point[] AddIntoArray(Point[] passingPoints, Point currentPoint)
        {
            Array.Resize(ref passingPoints, passingPoints.Length + 1);
            passingPoints[passingPoints.Length - 1] = currentPoint;
            return passingPoints;
        }

        bool IsInArray(Point[] points, Point currentPoint)
        {
            for (int j = 0; j < points.Length; j++)
                if (points[j].x == currentPoint.x && points[j].y == currentPoint.y)
                    return true;
            return false;
        }
    }
}
