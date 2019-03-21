using System;
using System.Drawing;
using System.Windows.Forms;

namespace MouseTrap
{
    public partial class Statistic : UserControl
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void Stattistic_Load(object sender, EventArgs e)
        {
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Refresh();
        }

        private void Stattistic_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawString("Statistics: ", Form1.textFont, Form1.textPen, 0, 0);
            e.Graphics.DrawString("Player wins: " + Form1.winsP, Form1.textFont, Form1.textPen, 0, 50);
            e.Graphics.DrawString("Mouse wins: " + Form1.winsM, Form1.textFont, Form1.textPen, 0, 100);
            e.Graphics.DrawString("Average Round Time: " + Form1.averageTime + " sec", Form1.textFont, Form1.textPen, 0, 150);
            e.Graphics.DrawString("Total time: " + Form1.totalTime + " sec", Form1.textFont, Form1.textPen, 0, 200);
            e.Graphics.DrawString("Press '               ' to return to game", Form1.textFont, Form1.textPen, 0, 300);
            e.Graphics.DrawString("Press '               ' to Exit the game", Form1.textFont, Form1.textPen, 0, 350);

            e.Graphics.DrawImage(Properties.Resources.black_button_for_web, new Rectangle(50, 330, 60, 60));
            e.Graphics.DrawImage(Properties.Resources.yellow_button_for_web, new Rectangle(50, 280, 60, 60));

        }

        private void Stattistic_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
    }
}
