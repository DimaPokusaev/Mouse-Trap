using System.Drawing;

namespace MouseTrap
{
    class Hexagon
    {
        public Point loc = new Point();
        public bool shift;

        public Hexagon(Point _loc, bool _shift)
        {
            loc = _loc;
            shift = _shift;
        }
    }
}
