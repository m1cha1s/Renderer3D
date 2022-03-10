using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Renderer3D
{
    internal class Pyramid : Object3D
    {
       
        public Pyramid(float a, float b, float h)
        {
            mesh.Vertices.Add(new Vector3(-a / 2, -b / 2, 0));
            mesh.Vertices.Add(new Vector3(a / 2, -b / 2, 0));
            mesh.Vertices.Add(new Vector3(a / 2, b / 2, 0));
            mesh.Vertices.Add(new Vector3(-a / 2, b / 2, 0));

            mesh.Vertices.Add(new Vector3(0, 0, h));

            mesh.Triangles.Add((0, 1, 2));
            mesh.Triangles.Add((0, 2, 3));
            mesh.Triangles.Add((0, 1, 4));
            mesh.Triangles.Add((1, 2, 4));
            mesh.Triangles.Add((2, 3, 4));
            mesh.Triangles.Add((3, 0, 4));
        }

    }
}
