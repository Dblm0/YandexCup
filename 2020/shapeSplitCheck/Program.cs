using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if (shapeParams[0] == 0)
                    centrePoints.Add(new Point(shapeParams[2], shapeParams[3]));
                else
                    centrePoints.Add(new Point((shapeParams[1] + shapeParams[5]) / 2.0, (shapeParams[2] + shapeParams[6]) / 2.0));
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
                var check = new LineCheck(points[0], points[1]);
                foreach (var testPoint in points.Skip(2))
                {
                    if (!check.IsPointOnLine(testPoint))
                        return false;
                }
                return true;
            }
        }

        static IEnumerable<int> ReadIntLine()
        {
            return Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x));
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
        class LineCheck
        {
            public LineCheck(Point p1, Point p2)
            {
                double dy = (p2.Y - p1.Y);
                double dx = (p2.X - p1.X);

                _areaCalc = (p) => Math.Abs(dx * (p.Y - p1.Y) - dy * (p.X - p1.X));
            }

            Func<Point, double> _areaCalc;
            double epsilon = 1e-9;
            public bool IsPointOnLine(Point p)
            {
                return _areaCalc(p) < epsilon;
            }
        }
    }
}
