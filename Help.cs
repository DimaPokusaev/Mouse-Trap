using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseTrap
{
    public partial class Help : UserControl
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
        }

        private void Help_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    MainGame mg = new MainGame();
                    f.Controls.Add(mg);
                    mg.Focus();
                    this.Dispose();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void Help_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(" Objective: ", Form1.textFont, Form1.textPen, 0, 0);
            e.Graphics.DrawString(" Do not let the mouse reach the outer hexagons(filled with red)", Form1.textFont, Form1.textPen, 0, 50);
            e.Graphics.DrawString(" Use traps to prevent the mouse from moving into the hexagon", Form1.textFont, Form1.textPen, 0, 100);
            e.Graphics.DrawString(" Controls:", Form1.textFont, Form1.textPen, 0, 150);
            e.Graphics.DrawString(" Movment: Use the first joystick to move \n the green hexagon(your position) around the screen", Form1.textFont, Form1.textPen, 0, 200);
            e.Graphics.DrawString(" Press '               ' to set a trap for the mouse", Form1.textFont, Form1.textPen, 0, 300);
            e.Graphics.DrawString(" Press '               ' to return to game", Form1.textFont, Form1.textPen, 0, 350);
            e.Graphics.DrawString(" Press '               ' to Exit the game", Form1.textFont, Form1.textPen, 0, 400);

            e.Graphics.DrawImage(Properties.Resources.green_button_for_web, new Rectangle(60, 280, 55, 55));
            e.Graphics.DrawImage(Properties.Resources.black_button_for_web, new Rectangle(60, 330, 55, 55));
            e.Graphics.DrawImage(Properties.Resources.yellow_button_for_web, new Rectangle(60, 380, 55, 55));
        }
    }
}
