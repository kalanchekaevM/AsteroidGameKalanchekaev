using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidsGame
{
    class SplashScreen 
    {
      private  static Form startingform = new Form {Width = 500, Height = 500, Text = "Asteroids Game", Icon = new System.Drawing.Icon("Assets/32х32.ico")};
      private  static Button startbutton = new Button {Text = "Начать игру", Width = 120, Height = 50 };
      private  static Button endbutton = new Button {Text = "Выйти из игры", Width = 120, Height = 50 };
        
        public  SplashScreen()
        {
            // Настраиваем стартовый экран
            startbutton.Location = new System.Drawing.Point(200, 200);
            endbutton.Location = new System.Drawing.Point (200, 300);

            startingform.Controls.Add(startbutton);
            startingform.Controls.Add(endbutton);

            startingform.StartPosition = FormStartPosition.CenterScreen;
            startbutton.Click += Startbutton_Click;
            endbutton.Click += Endbutton_Click;


            Application.Run(startingform);
        }
          
        // Настройка кнопки старт
        private void Startbutton_Click(object sender, EventArgs e)
        { 
            startingform.Hide();
            Form gameform = new Form { Width = 1080, Height = 720, Text = "Asteroids Game", Icon = new System.Drawing.Icon("Assets/32х32.ico") };
            Game.Init(gameform);
            Game.Draw();
            gameform.ShowDialog();
        }
        //Настройка кнопки выхода
        private void Endbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
