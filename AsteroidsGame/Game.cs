using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace AsteroidsGame
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs;
        private static Button backtomenubutton = new Button  { Width = 120, Height = 50, Location = new System.Drawing.Point (0,0), Image = System.Drawing.Image.FromFile("Assets/exitbuttonasset.png"), BackColor= Color.Empty};

        static Game() { }

        public static void Load(Form form)
        {
            form.Controls.Add(backtomenubutton);
            backtomenubutton.Click += Backtomenubutton_Click;
            Random r = new Random();

            _objs = new BaseObject[200];
            for (int i = 0; i < _objs.Length; i++)
            {
                int sizeobj = r.Next(0, 4) * 8;
                _objs[i] = new BaseObject(new Point(r.Next(1, form.Width), r.Next(1, form.Height)), new Point(r.Next(4, 15) - 9, r.Next(4, 15) - 9), new Size(sizeobj, sizeobj));
            }
            
        }

        //Крестик во время игры
        private static void Backtomenubutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Buffer.Graphics.Clear(Color.Black);
            Draw();
            Update();
        }

        public static void Init(Form gameform)
        {
            Game.Load(gameform);
            Timer timer = new Timer { Interval = 42 };
            timer.Start();
            timer.Tick += Timer_Tick;

            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = gameform.CreateGraphics();
            Width = gameform.ClientSize.Width;
            Height = gameform.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }


        public static void Draw()
        {
            foreach (BaseObject obj in _objs)
                obj.Draw();

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}
