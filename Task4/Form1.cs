using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solution;

namespace Task4
{
    public partial class Form1 : Form
    {
        Scene scene;
        Camera camera;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            camera = new Camera();
            scene.Models.Add(new Cube(new Vector3(-0.3f, -0.3f, -0.3f), new Vector3(0.6f, 0.6f, 0.6f)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var screen = new Solution.Screen(Size, new Rectangle(-1, -1, 2, 2));
            Bitmap bmp = scene.DrawScene(screen, camera);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        Point last = new Point();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !last.IsEmpty)
            {
                int dx = e.X - last.X;
                int dy = e.Y - last.Y;
                last = e.Location;
                camera.View = Matrix.Rotation(0, dx * (float)Math.PI / 180) *
                    Matrix.Rotation(1, dy * (float)Math.PI / 180) * camera.View;
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
                last = new Point();
        }
    }
}
