using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace MouseTrap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // sets general variables for MainGame
        public static int hexX = 70, hexY = 53, difficulty = 1, win = 3; // 'win' is three to open the menu on start
        public static PointF[] hexPoints = new PointF[6];
        public static Random randGen = new Random();
        public static List<int> times = new List<int>();

        //Statistic variables
        public static Stopwatch gameWatch = new Stopwatch();
        public static Stopwatch openWatch = new Stopwatch();
        public static int winsM, winsP, totalTime, averageTime;

        //Graphics
        public static SolidBrush textPen = new SolidBrush(Color.Black);
        public static SolidBrush menuText = new SolidBrush(Color.FromArgb(0, 100, 0));
        public static Font textFont = new Font("Times New Romans", 12);
        public static Font menuFont = new Font("Times New Romans", 25);
        public static Pen hexPen = new Pen(Color.Black);
        public static Pen borderPen = new Pen(Color.Red, 5);
        public static Pen playerLocPen = new Pen(Color.Green, 5);


        public void Form1_Load(object sender, EventArgs e)
        {
            // Loads main game
            MainGame mg = new MainGame();
            this.Controls.Add(mg);
        }
    }
}
