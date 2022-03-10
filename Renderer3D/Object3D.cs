using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Renderer3D
{
    internal abstract class Object3D
    {
        public int PointSize = 10;
        public Matrix4x4 modelMatrix = Matrix4x4.Identity;
        protected Mesh mesh = new Mesh();


        public void Draw(Graphics g, Camera cam)
        {
            //g.DrawLine(Pens.Black, 10, 10, g.VisibleClipBounds.Width - 10, g.VisibleClipBounds.Height - 10);

            List<Vector3> vertices = new List<Vector3>();


            foreach (var vertex in mesh.Vertices)
            {
                Vector4 v = Vector4.Transform(new Vector4(vertex, 1), modelMatrix * cam.viewMatrix * cam.projectionMatrix);
                vertices.Add(new Vector3(v.X / v.W, v.Y / v.W, v.Z / v.W));
            }

            foreach (var vertex in vertices)
            {
                int x = (int)((vertex.X + 1.0f) * g.VisibleClipBounds.Width / 2);
                int y = (int)(g.VisibleClipBounds.Height - ((vertex.Y + 1.0f) * g.VisibleClipBounds.Height / 2));
                g.FillEllipse(Brushes.Red, x - PointSize/2, y - PointSize/2, PointSize, PointSize);
            }

            List<Point[]> faces = new List<Point[]>();

            foreach (var triangle in mesh.Triangles)
            {
                int x1 = (int)((vertices[triangle.Item1].X + 1.0f) * g.VisibleClipBounds.Width / 2);
                int y1 = (int)(g.VisibleClipBounds.Height - ((vertices[triangle.Item1].Y + 1.0f) * g.VisibleClipBounds.Height / 2));

                int x2 = (int)((vertices[triangle.Item2].X + 1.0f) * g.VisibleClipBounds.Width / 2);
                int y2 = (int)(g.VisibleClipBounds.Height - ((vertices[triangle.Item2].Y + 1.0f) * g.VisibleClipBounds.Height / 2));

                int x3 = (int)((vertices[triangle.Item3].X + 1.0f) * g.VisibleClipBounds.Width / 2);
                int y3 = (int)(g.VisibleClipBounds.Height - ((vertices[triangle.Item3].Y + 1.0f) * g.VisibleClipBounds.Height / 2));

                Point[] points = { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) };

                faces.Add(points);
            } 

            foreach (Point[] points in faces)
            {
                g.FillPolygon(Brushes.Aqua, points);
            }

            foreach (Point[] points in faces)
            {
                g.DrawLines(Pens.Black, points);
            }
        }
    }
}
