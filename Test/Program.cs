using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace Foundations.Geometry
{
    class Program
    {
        static double NextNormal(Random rand) => Math.Sqrt(-2 * Math.Log(1 - rand.NextDouble())) * Math.Cos(Math.PI * rand.NextDouble());

        static void Main(string[] args)
        {
            var count = 0L;
            var next = DateTime.UtcNow.AddSeconds(1);

            var tasks = Enumerable.Range(0, Environment.ProcessorCount).Select(taskNum => Task.Run(() =>
            {
                var rand = new Random();

                while (true)
                {
                    try
                    {
                        var c = Interlocked.Increment(ref count);
                        var now = DateTime.UtcNow;

                        if (taskNum == 0 && now >= next)
                        {
                            next = now.AddSeconds(1);
                            Debug.WriteLine($"{c:N0}");
                        }

                        // Define a point.
                        var x = NextNormal(rand);
                        var y = NextNormal(rand);
                        var p = new Point(x, y);

                        // Verify that homogenous values match.
                        double w = (double)p.W;
                        var xx = (double)p.X / w;
                        var yy = (double)p.Y / w;
                        Debug.Assert(x == xx);
                        Debug.Assert(y == yy);

                        // Define another point.
                        x = NextNormal(rand);
                        y = NextNormal(rand);
                        var q = new Point(x, y);

                        // Get vector from points.
                        var v = q - p;

                        // Recreate second point from vector.
                        var r = p + v;
                        Debug.Assert(r == q);

                        // Recreate second point from null vector.
                        r = q + Vector.Zero;
                        Debug.Assert(r == q);

                        // Recreate point from vector and origin.
                        r = Point.Origin + v;
                        Debug.Assert(r.X == v.X && r.Y == v.Y && r.W == v.W);

                        // Create line from points.
                        var line = new Line(p, q);

                        // Verify that both points are on the line.
                        Debug.Assert(line.Intersects(p));
                        Debug.Assert(line.Intersects(q));

                        // Verify that the midpoint is on the line.
                        var mid = p + (q - p) / 2;
                        Debug.Assert(line.Intersects(mid));

                        // Verify the line equation.
                        var z = line.A * p.X + line.B * p.Y + line.C * p.W;
                        Debug.Assert(z.IsZero);

                        // Verify that the midpoint is on the line's boundary.
                        Debug.Assert(line.Side(mid) == 0);

                        // Create a third point.
                        x = NextNormal(rand);
                        y = NextNormal(rand);
                        r = new Point(x, y);

                        // Determine which side its on.
                        var side = line.Side(r);
                        Debug.Assert(side != 0); // super almost impossible

                        // Make a line with opposite orientation.
                        var opp = line.Opposite;

                        // Verify that the point is on the opposite side.
                        var side2 = opp.Side(r);
                        Debug.Assert(side * side2 == -1);

                        // Make a second line.
                        var s = new Point(NextNormal(rand), NextNormal(rand));
                        var line2 = new Line(r, s);

                        // Get intersection of the two lines.
                        var ipt = line.Intersection(line2);
                        Debug.Assert(ipt is Point pt);

                        // Verify that point is on both lines.
                        Debug.Assert(line.Intersects(pt));
                        Debug.Assert(line2.Intersects(pt));

                        // Make a ray.
                        var ray = new Ray(p, q);

                        // Pick a point on the ray.
                        var t = Math.Abs(NextNormal(rand));
                        r = ray.Source + new Vector(ray.Direction) * t;

                        // Verify that it is on the ray.
                        Debug.Assert(ray.Intersects(r));
                        Debug.Assert(r.Intersects(ray));

                        // Pick a point in the opposite direction.
                        r = ray.Source - new Vector(ray.Direction) * t;

                        // Verify that it is not on the ray.
                        Debug.Assert(!ray.Intersects(r));

                        // Verify that a random point is not on the ray.
                        Debug.Assert(!ray.Intersects(line2.Point(0)));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                        Debugger.Break();
                    }
                }
            })).ToArray();

            Task.WaitAll(tasks);
        }
    }
}
