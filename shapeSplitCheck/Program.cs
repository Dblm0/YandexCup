using System;
using System.Collections.Generic;
using System.Linq;

namespace shapeSplitCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            int ShapeNubmer = ReadIntLine().First();
            List<Point> centrePoints = new List<Point>();
            for (int i = 0; i < ShapeNubmer; i++)
            {
                var shapeParams = ReadIntLine().ToArray();
                switch (shapeParams[0])
                {
                    case 0:
                        centrePoints.Add(new Point(shapeParams[2], shapeParams[3]));
                        break;
                    case 1:
                        var rectPoints = new List<Point>();
                        for (int pIdx = 1; pIdx < 4 * 2; pIdx += 2)
                        {
                            rectPoints.Add(new Point(shapeParams[pIdx], shapeParams[pIdx + 1]));
                        }
                        centrePoints.Add(CalcRectangleMidPoint(rectPoints));
                        break;
                }
            }
            Console.WriteLine(CheckPoints(centrePoints) ? "Yes" : "No");
        }
        static bool CheckPoints(List<Point> points)
        {
            if (points.Count < 3)
            {
                return true;
            }
            else
            {
                var line = new Line(points[0], points[1]);
                foreach (var testPoint in points.Skip(2))
                {
                    if (!line.IsPointOnLine(testPoint))
                        return false;
                }
                return true;
            }
        }
        static Point CalcRectangleMidPoint(List<Point> points)
        {
            var mX = (points[0].X - points[2].X) / 2;
            var mY = (points[0].Y - points[2].Y) / 2;
            return new Point(mX, mY);
        }
        static IEnumerable<int> ReadIntLine()
        {
            return Console.ReadLine().Split(' ').Select(x => int.Parse(x));
        }
        class Point
        {
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; }
            public double Y { get; }
        }
        class Line
        {
            public Line(Point p1, Point p2)
            {
                double dy = (p2.Y - p1.Y);
                double dx = (p2.X - p1.X);

                _areaCalc = (p) => dx * (p.Y - p1.Y) - dy * (p.X - p1.X);
            }

            Func<Point, double> _areaCalc;
            public bool IsPointOnLine(Point p)
            {
                return _areaCalc(p) == 0;
            }
        }
    }
}
