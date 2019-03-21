using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MouseTrap
{
    public partial class MainGame : UserControl
    {
        public MainGame()
        {
            InitializeComponent();
            // Removes cursor
            Cursor.Hide();
        }

        CurrentLock playerLocation = new CurrentLock(new Point(4, 4), true);
        MousePosition computerLocation = new MousePosition(new Point(3, 3), false);
        List<Hexagon> hexGrid = new List<Hexagon>();

        public void TrapPut()
        {
            // After the trap was put, mouse gets to move to playerLocation diffrent hexagon
            // Since mice are not the most intelegent creatures they move in an almost random direction

            hexGrid.Add(playerLocation.TrapPut(playerLocation));
            computerLocation.Move(computerLocation, hexGrid);


            // Check if player won
            if((Form1.win == 0))
            {
                for (int i = 0; i < hexGrid.Count; i++)
                {
                    if (hexGrid[i].loc == computerLocation.loc)
                    {
                        Form1.win = 2;
                        Form1.winsP++;
                        Form1.times.Add(Convert.ToInt32(Form1.gameWatch.Elapsed.TotalSeconds));
                        this.Refresh();
                    }
                }
            }

            // Checks if the mouse won
            if ((Form1.win == 0) && (computerLocation.loc.X == 0 || computerLocation.loc.Y == 0 || computerLocation.loc.X == 7 || computerLocation.loc.Y == 7))
            {
                Form1.win = 1;
                Form1.winsM++;
                Form1.times.Add(Convert.ToInt32(Form1.gameWatch.Elapsed.Seconds));
                Form1.gameWatch.Restart();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Centers the Control on the screen
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            // Starts stopwatches
            Form1.gameWatch.Start();
            Form1.openWatch.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            // Draw grid if not on playerLocation 'Menu' or an 'End Game' screen 
            if (Form1.win == 0)
            {
                for (int y = Form1.hexY; y < this.Height; y += 2 * Form1.hexY) // Selects row (even rows)
                {
                    for (int x = 0; x < this.Width; x += Form1.hexX) // Draws hexagons in the said row 
                    {
                        // Generates the Hexagon that is going to be replicated
                        Form1.hexPoints[0] = new PointF(Form1.hexX / 2 + x, 1 + y);
                        Form1.hexPoints[1] = new PointF(1 + x, Form1.hexX / 4 + y);
                        Form1.hexPoints[5] = new PointF(Form1.hexX + x, Form1.hexX / 4 + y);
                        Form1.hexPoints[2] = new PointF(1 + x, Form1.hexY + y);
                        Form1.hexPoints[4] = new PointF(Form1.hexX + x, Form1.hexY + y);
                        Form1.hexPoints[3] = new PointF(Form1.hexX / 2 + x, Form1.hexX + y);

                        // Checks for edges, if edge, draw in Red
                        if (x == 0||x == Form1.hexX*7)
                        {
                            e.Graphics.DrawPolygon(Form1.borderPen, Form1.hexPoints);
                        }
                        else
                        {
                            e.Graphics.DrawPolygon(Form1.hexPen, Form1.hexPoints);
                        }

                        if (y == Form1.hexY*(this.Height/Form1.hexY -1))
                        {
                            e.Graphics.DrawPolygon(Form1.borderPen, Form1.hexPoints);
                        }
                        else
                        {
                            e.Graphics.DrawPolygon(Form1.hexPen, Form1.hexPoints);
                        }
                    }
                }
                for (int y = 0; y < this.Height; y += 2 * Form1.hexY) // Selects row (odd rows)
                {
                    for (int x = -Form1.hexX / 2; x < this.Width; x += Form1.hexX) // Draws hexagons in the said row (with playerLocation shift)
                    {
                        // Generates the Hexagon that is going to be replicated
                        Form1.hexPoints[0] = new PointF(Form1.hexX / 2 + x, 1 + y);
                        Form1.hexPoints[1] = new PointF(1 + x, Form1.hexX / 4 + y);
                        Form1.hexPoints[5] = new PointF(Form1.hexX + x, Form1.hexX / 4 + y);
                        Form1.hexPoints[2] = new PointF(1 + x, Form1.hexY + y);
                        Form1.hexPoints[4] = new PointF(Form1.hexX + x, Form1.hexY + y);
                        Form1.hexPoints[3] = new PointF(Form1.hexX / 2 + x, Form1.hexX + y);

                        // Checks for edges, if edge, draw in Red
                        if (x == -Form1.hexX / 2 + Form1.hexX || x == Form1.hexX* 8 - Form1.hexX / 2)
                        {
                            e.Graphics.DrawPolygon(Form1.borderPen, Form1.hexPoints);
                        }
                        else
                        {
                            e.Graphics.DrawPolygon(Form1.hexPen, Form1.hexPoints);
                        }

                        if (y == 0)
                        {
                            e.Graphics.DrawPolygon(Form1.borderPen, Form1.hexPoints);
                        }
                        else
                        {
                            e.Graphics.DrawPolygon(Form1.hexPen, Form1.hexPoints);
                        }
                    }
                }

                // Draws player
                if (playerLocation.shift) // Checks for shift
                {
                    Form1.hexPoints[0] = new PointF(Form1.hexX + (playerLocation.loc.X) * Form1.hexX, 1 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[1] = new PointF(1 + Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, Form1.hexX / 4 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[5] = new PointF(Form1.hexX + Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, Form1.hexX / 4 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[2] = new PointF(1 + Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, Form1.hexY + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[4] = new PointF(Form1.hexX + Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, Form1.hexY + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[3] = new PointF(Form1.hexX + (playerLocation.loc.X) * Form1.hexX, Form1.hexX + (playerLocation.loc.Y) * Form1.hexY);
                }
                else
                {
                    Form1.hexPoints[0] = new PointF(Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, 1 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[1] = new PointF(1 + (playerLocation.loc.X) * Form1.hexX, Form1.hexX / 4 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[5] = new PointF(Form1.hexX + (playerLocation.loc.X) * Form1.hexX, Form1.hexX / 4 + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[2] = new PointF(1 + (playerLocation.loc.X) * Form1.hexX, Form1.hexY + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[4] = new PointF(Form1.hexX + (playerLocation.loc.X) * Form1.hexX, Form1.hexY + (playerLocation.loc.Y) * Form1.hexY);
                    Form1.hexPoints[3] = new PointF(Form1.hexX / 2 + (playerLocation.loc.X) * Form1.hexX, Form1.hexX + (playerLocation.loc.Y) * Form1.hexY);
                }
                e.Graphics.DrawPolygon(Form1.playerLocPen, Form1.hexPoints);

                // Draws the mouse sprite in appropriet location
                if (computerLocation.shift)
                {
                    e.Graphics.DrawImage(Properties.Resources.mouse, computerLocation.loc.X * Form1.hexX + 3 * Form1.hexX / 4, computerLocation.loc.Y * Form1.hexY + Form1.hexY / 3);
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.mouse, computerLocation.loc.X * Form1.hexX + Form1.hexX / 3, computerLocation.loc.Y * Form1.hexY + Form1.hexY / 3);
                }

                // Draws traps with help of hexArray
                for (int i = 0; i < hexGrid.Count; i++)
                {
                    if (hexGrid[i].shift)
                    {
                        e.Graphics.DrawImage(Properties.Resources.trap, hexGrid[i].loc.X * Form1.hexX + 3 * Form1.hexX / 4, hexGrid[i].loc.Y * Form1.hexY + Form1.hexY / 3, 30, 30);
                    }
                    else
                    {
                        e.Graphics.DrawImage(Properties.Resources.trap, hexGrid[i].loc.X * Form1.hexX + Form1.hexX / 3, hexGrid[i].loc.Y * Form1.hexY + Form1.hexY / 3, 30, 30);
                    }
                }
            }

            // End Game screen
            // You lose
            if (Form1.win == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.yellow_button_for_web, new Rectangle(103, 50, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.blue_button_for_web, new Rectangle(103, 100, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.red_button_for_web, new Rectangle(103, 150, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.green_button_for_web, new Rectangle(413, 200, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.black_button_for_web, new Rectangle(103, 250, 60, 60));

                e.Graphics.DrawString("You Lose, The mouse got away", Form1.menuFont, Form1.menuText, 0, 0);
                e.Graphics.DrawString("Press '      ' to restart", Form1.menuFont, Form1.menuText, 0, 50);
                e.Graphics.DrawString("Press '      ' for help", Form1.menuFont, Form1.menuText, 0, 100);
                e.Graphics.DrawString("Press '      ' to view the statistics", Form1.menuFont, Form1.menuText, 0, 150);
                e.Graphics.DrawString("Current difficulty is " + Form1.difficulty + " Press '      ' change", Form1.menuFont, Form1.menuText, 0, 200);
                e.Graphics.DrawString("Press '      ' to Exit the game", Form1.menuFont, Form1.menuText, 0, 250);
            }

            // You win
            if (Form1.win == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.yellow_button_for_web, new Rectangle(103, 50, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.blue_button_for_web, new Rectangle(103, 100, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.red_button_for_web, new Rectangle(103, 150, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.green_button_for_web, new Rectangle(413, 200, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.black_button_for_web, new Rectangle(103, 250, 60, 60));

                e.Graphics.DrawString("You Win, Great job!", Form1.menuFont, Form1.menuText, 0, 0);
                e.Graphics.DrawString("Press '      ' to restart", Form1.menuFont, Form1.menuText, 0, 50);
                e.Graphics.DrawString("Press '      ' for help", Form1.menuFont, Form1.menuText, 0, 100);
                e.Graphics.DrawString("Press '      ' to view the statistics", Form1.menuFont, Form1.menuText, 0, 150);
                e.Graphics.DrawString("Current difficulty is " + Form1.difficulty + " Press '      ' change", Form1.menuFont, Form1.menuText, 0, 200);
                e.Graphics.DrawString("Press '      ' to Exit the game", Form1.menuFont, Form1.menuText, 0, 250);
            }

            // Menu screen
            if (Form1.win == 3)
            {
                e.Graphics.DrawImage(Properties.Resources.yellow_button_for_web, new Rectangle(103, 0, 60,60));
                e.Graphics.DrawImage(Properties.Resources.blue_button_for_web, new Rectangle(103, 100, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.red_button_for_web, new Rectangle(103, 200, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.green_button_for_web, new Rectangle(413, 300, 60, 60));
                e.Graphics.DrawImage(Properties.Resources.black_button_for_web, new Rectangle(103, 390, 60, 60));

                e.Graphics.DrawString("Press '      ' to start", Form1.menuFont, Form1.menuText, 0, 0);
                e.Graphics.DrawString("Press '      ' for help", Form1.menuFont, Form1.menuText, 0, 100);
                e.Graphics.DrawString("Press '      ' to view the statistics", Form1.menuFont, Form1.menuText, 0, 200);
                e.Graphics.DrawString("Current difficulty is " + Form1.difficulty + " Press '      ' change", Form1.menuFont, Form1.menuText, 0, 300);
                e.Graphics.DrawString("Press '      ' to Exit the game", Form1.menuFont, Form1.menuText, 0, 400);
            }
        }

        private void MainGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (Form1.win == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        playerLocation.Move(playerLocation, 1, this.Width, this.Height);
                        break;
                    case Keys.Right:
                        playerLocation.Move(playerLocation, 2, this.Width, this.Height);
                        break;
                    case Keys.Up:
                        playerLocation.Move(playerLocation, 3, this.Width, this.Height);
                        break;
                    case Keys.Down:
                        playerLocation.Move(playerLocation, 4, this.Width, this.Height);
                        break;
                    case Keys.Space:
                        TrapPut();
                        break;
                }
                this.Refresh();
            }
            if (Form1.win > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        Form1.win = 0;
                        int yvalue = Form1.randGen.Next(3, 6);
                        computerLocation.loc = new Point(Form1.randGen.Next(3,6), yvalue);
                        if(yvalue%2 == 0)
                        {
                            computerLocation.shift = true;
                        }
                        else
                        {
                            computerLocation.shift = false;
                        }
                        hexGrid.Clear();
                        Form1.gameWatch.Restart();
                        this.Refresh();
                        break;
                    case Keys.B:
                        Form f = this.FindForm();
                        f.Controls.Remove(this);
                        Help h = new Help();
                        f.Controls.Add(h);
                        h.Focus();
                        this.Dispose();
                        break;
                    case Keys.M:
                        int total = 0;
                        Form1.totalTime = Convert.ToInt32(Form1.openWatch.Elapsed.TotalSeconds);
                        for(int i = 0; i < Form1.times.Count; i++)
                        {
                            total += Form1.times[i];
                            Form1.averageTime = total / Form1.times.Count;
                        }
                        Form fo = this.FindForm();
                        fo.Controls.Remove(this);
                        Statistic s = new Statistic();
                        fo.Controls.Add(s);
                        s.Focus();
                        this.Dispose();
                        break;
                    case Keys.Escape:
                        Application.Exit();
                        break;
                    case Keys.Space:
                        if(Form1.difficulty == 3)
                        {
                            Form1.difficulty = 1;
                        }
                        else
                        {
                            Form1.difficulty++;
                        }
                        this.Refresh();
                        break;
                }
            }
        }
    }
}
