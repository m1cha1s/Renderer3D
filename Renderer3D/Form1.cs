using System.Numerics;

namespace Renderer3D
{
    public partial class Form1 : Form
    {
        float dir = 1.0f;
        Pyramid pyramid = new Pyramid(100, 100, 200);
        Camera camera = new Camera(new Vector3(0, 300, 100), new Vector3(0, 0, 100), (float)Math.PI / 2, 100, 1000);

        public Form1()
        {
            InitializeComponent();

            camera.UpdateViewMatrix();
            camera.UpdateProjectionMatrix(pictureBox1);
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            pyramid.Draw(g, camera);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            camera.Position += new Vector3(dir*10, 0, 0);
            camera.UpdateViewMatrix();

            //pyramid.modelMatrix *= Matrix4x4.CreateRotationX(MathF.PI / 24);
            //pyramid.modelMatrix *= Matrix4x4.CreateRotationY(MathF.PI / 24);
            pyramid.modelMatrix *= Matrix4x4.CreateRotationZ(MathF.PI / 24);
            pictureBox1.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            dir *= -1.0f;
        }
    }
}