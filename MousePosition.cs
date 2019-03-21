using System.Collections.Generic;
using System.Drawing;

namespace MouseTrap
{
    class MousePosition
    {
        public Point loc = new Point();
        public bool shift;

        public MousePosition(Point _loc, bool _shift)
        {
            loc = _loc;
            shift = _shift;
        }

        public void Move(MousePosition c, List<Hexagon> list)
        {
            Point test = new Point(c.loc.X, c.loc.Y);
            int ic = 2, listcount = 0;
            bool sc = false;

            // difficulty settings effect the movment
            // third difficuly is imposible to beat
            if(Form1.difficulty == 3)
            {
                // purposfully moves trawrds an edge
                if (c.loc.Y < 4 && ic == 2) // if in the top halp of the grid
                {
                    ic = 0;
                    test = new Point(c.loc.X, c.loc.Y);

                    test.Y--;
                    sc = true;
                    locationCheck();

                    if (c.shift)
                    {
                        if (ic == 2)
                        {
                            ic = 0;
                            test.X++;
                            locationCheck();
                        }
                    }
                    else
                    {
                        if (ic == 2)
                        {
                            ic = 0;
                            test.X--;
                            locationCheck();
                        }
                    }
                }
                if (c.loc.Y > 3 && ic == 2) // if in the botton halp of the grid
                {
                    ic = 0;
                    test = new Point(c.loc.X, c.loc.Y);

                    test.Y++;
                    sc = true;
                    locationCheck();

                    if (c.shift)
                    {
                        if (ic == 2)
                        {
                            ic = 0;
                            test.X++;
                            locationCheck();
                        }
                    }
                    else
                    {
                        if (ic == 2)
                        {
                            ic = 0;
                            test.X--;
                            locationCheck();
                        }
                    }
                }
                if (c.loc.X < 4 && ic == 2) // if on the left side of the grid
                {
                    test = new Point(c.loc.X, c.loc.Y);

                    ic = 0;
                    test.X--;
                    sc = false;
                    locationCheck();
                }
                if (c.loc.X > 3 && ic == 2) // if on the left side of the grid
                {
                    test = new Point(c.loc.X, c.loc.Y);

                    ic = 0;
                    test.X++;
                    sc = false;
                    locationCheck();
                }
            }

            if(Form1.difficulty == 2)
            {
                // Randomly chouses a direction, but checks for potential loss
                bool d = false;
                while(d == false)
                {
                    listcount = 0;
                    test = new Point(c.loc.X, c.loc.Y);
                    switch (Form1.randGen.Next(1, 7))
                    {
                        case 1:
                            test.X++;
                            sc = false;
                            break;
                        case 2:
                            test.X--;
                            sc = false;
                            break;
                        case 3:
                            test.Y++;
                            sc = true;
                            break;
                        case 4:
                            test.Y--;
                            sc = true;
                            break;
                        case 5:
                            test.Y++;
                            if (c.shift)
                            {
                                test.X++;
                            }
                            else
                            {
                                test.X--;
                            }
                            sc = true;
                            break;
                        case 6:
                            c.loc.Y--;
                            if (c.shift)
                            {
                                test.X--;
                            }
                            else
                            {
                                test.X++;
                            }
                            sc = true;
                            break;
                    }

                    locationCheck();

                    if (listcount == 6 || listcount == 0)
                    {
                        d = true;
                    }
                }
            }
           
            if(Form1.difficulty == 1)
            {
                // Randomly chouses a direction
                switch (Form1.randGen.Next(1, 7))
                {
                    case 1:
                        c.loc.X++;
                        sc = false;
                        break;
                    case 2:
                        c.loc.X--;
                        sc = false;
                        break;
                    case 3:
                        c.loc.Y++;
                        sc = true;
                        break;
                    case 4:
                        c.loc.Y--;
                        sc = true;
                        break;
                    case 5:
                        c.loc.Y++;
                        if (c.shift)
                        {
                            c.loc.X++;
                        }
                        else
                        {
                            c.loc.X--;
                        }
                        sc = true;
                        break;
                    case 6:
                        c.loc.Y--;
                        if (c.shift)
                        {
                            c.loc.X--;
                        }
                        else
                        {
                            c.loc.X++;
                        }
                        sc = true;
                        break;
                }
            }

            /// Use the result
            if(Form1.difficulty == 3 || Form1.difficulty == 2)
            {
                c.loc = test;
            }

            if (sc) // Changes the shift quality
            {
                if (c.shift)
                {
                    c.shift = false;
                }
                else
                {
                    c.shift = true;
                }
            }

            void locationCheck() // Checks if potential mouse move will intersect with a trap
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (test == list[i].loc)
                    {
                        ic = 2;
                        listcount++;
                    }
                }
            }
        }
    }
}