using System.Drawing;
using System.Media;

namespace MouseTrap
{
    class CurrentLock
    {
        public Point loc = new Point();
        public bool shift;

        public CurrentLock(Point _loc, bool _shift)
        {
            loc = _loc;
            shift = _shift;
        }

        /// Moves player in acordance with comands
        public void Move(CurrentLock c, int type, int width, int height)
        {
            // Registers Right/Left movment
            switch (type)
            {
                case 1:
                    if ( c.loc.X > 0)
                    {
                        c.loc.X--;
                    }
                    break;
                case 2:
                    if (c.loc.X < width / Form1.hexX - 1)
                    {
                        c.loc.X++;
                    }
                    break;
                case 3:
                    if (c.loc.Y > 0)
                    {
                        c.loc.Y--;
                        if (c.shift)
                        {
                            c.shift = false;
                        }
                        else
                        {
                            c.shift = true;
                        }
                    }
                    break;
                case 4:
                    if (c.loc.Y < height / Form1.hexY - 1)
                    {
                        c.loc.Y++;
                        if (c.shift)
                        {
                            c.shift = false;
                        }
                        else
                        {
                            c.shift = true;
                        }
                    }
                    break;
            }
        }
        // If green is pressed, returns a new hexagon to the array and inserts a new sprite on the screen
        public Hexagon TrapPut(CurrentLock c )
        {
            // Sound Player
            SoundPlayer player = new SoundPlayer(Properties.Resources.punch);
            player.Play();
            Hexagon hex;

            // Copies location
            if (c.shift)
            {
                return hex = new Hexagon(new Point(c.loc.X, c.loc.Y), true);
            }
            else
            {
                return hex = new Hexagon(new Point(c.loc.X, c.loc.Y), false);
            }
        }
    }
}
