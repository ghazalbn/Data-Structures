using System;
using System.Drawing;
using System.Linq;
class PaintRoom
{
    public string func;
    public Expression expression;
    public Bitmap image;
    public Graphics graph;
    public PaintRoom(Expression e)
    {
        expression = e;
        func = e.st.Postfix;
        image = new Bitmap(1800, 1500);
        // image = new Bitmap(Image(@"..\diagram.png"));

        graph = Graphics.FromImage(image);

        graph.Clear(Color.Azure);

        var pen = new Pen(Color.Black, 2);

        graph.DrawLine(pen, image.Width/2, 0, image.Width/2, image.Height);
        graph.DrawLine(pen, 0, image.Height/2, image.Width, image.Height/2);

        image.Save(@".\diagram.png", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    public void Draw(float x0, float x1, int n)
    {
        Console.WriteLine("**You can open 'diagram.png' at this folder and see your diagram so far**\n");
        float d = (x1 - x0)/n;
        var points = new (float, float)[n + 1];
        for (int i = 0; i <= n; i++)
            points[i] = ((i*d+x0, expression.ComputeFunc(i*d+x0)));

        var min = points.Min(p => p.Item2);
        var max = points.Max(p => p.Item2);

        var wn = -x0/(image.Width/2 - 200);
        float wp = Math.Abs((x1-x0))/(image.Width/2 - 200);

        var hn = -min/(image.Height/2 - 250);
        float hp = 2*Math.Abs((max-min))/(image.Height/2 - 200);

        var pen = new Pen(Color.Red, 4);
        var point1 = new PointF(x0/(x0<0?wn:wp) + image.Width/2, image.Height-points[0].Item2/(min<0?hn:hp) - image.Height/2);
        foreach ((float x, float y) in points)
        {
            var point2 = new PointF(x/(x0<0?wn:wp) + image.Width/2, image.Height-y/(min<0?hn:hp) -image.Height/2);
            if (float.IsInfinity(y) || float.IsInfinity(point1.Y) || float.IsNaN(y) || float.IsNaN(point1.Y)) 
            {
                point1 = point2;
                continue;
            }
            graph.DrawLine(pen, point1, point2);
            image.Save(@".\diagram.png", System.Drawing.Imaging.ImageFormat.Jpeg);
            point1 = point2;        
        }
    }
}