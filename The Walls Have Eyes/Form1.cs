using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace The_Walls_Have_Eyes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Rectangle dialogue = new Rectangle(50, 560, 950, 100);
        Rectangle character = new Rectangle(700 - 15, 900 / 2 - 20, 27, 59);
        Rectangle cat = new Rectangle(361, 39, 26, 38);
        Rectangle mouseC = new Rectangle(750, 540, 20, 7);
        Rectangle tortoise = new Rectangle(517, 315, 15, 33);

        ////inventory
        //r1
        Rectangle r1c1 = new Rectangle(300, 40, 100, 100);
        Rectangle r1c2 = new Rectangle(420, 40, 100, 100);
        Rectangle r1c3 = new Rectangle(540, 40, 100, 100);
        Rectangle r1c4 = new Rectangle(660, 40, 100, 100);
        //r2
        Rectangle r2c1 = new Rectangle(300, 160, 100, 100);
        Rectangle r2c2 = new Rectangle(420, 160, 100, 100);
        Rectangle r2c3 = new Rectangle(540, 160, 100, 100);
        Rectangle r2c4 = new Rectangle(660, 160, 100, 100);

        List<string> InventoryList = new List<string>(new string[8]);

        string area = "spawn";
        string facing = "front";

        int mouseM = 0;
        int atk = 2;
        int def = 1;
        int characterHP = 100;
        int viewingInventory = 0;
        int describing = 0;
        
        bool testing = false;
        bool battle = false;
        bool inventory = false;
        bool dialogueVisible = false;
        bool mouseVisible = true;

        //Quest done?
        bool catQuestV = false;


        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool eDown = false;
        bool oneDown = false;
        bool twoDown = false;
        bool threeDown = false;

        Brush blueBrush = new SolidBrush(Color.Blue);
        Brush grassBrush = new SolidBrush(Color.FromArgb(250, 178, 242, 105));
        Brush pathBrush = new SolidBrush(Color.FromArgb(250, 225, 213, 155));
        Brush redBrush = new SolidBrush(Color.FromArgb(250, 232, 35, 68));
        Brush trunkBrush = new SolidBrush(Color.FromArgb(250, 102, 77, 9));
        Brush dirtBrush = new SolidBrush(Color.FromArgb(250, 163, 118, 64));
        Brush leafBrush = new SolidBrush(Color.FromArgb(250, 104, 153, 24));
        Brush whiteBrush = new SolidBrush(Color.FromArgb(250, 250, 246, 245));
        Brush blackBrush = new SolidBrush(Color.Black);
        Brush pondGrassBrush = new SolidBrush(Color.FromArgb(250, 57, 191, 75));
        Brush pondBrush = new SolidBrush(Color.FromArgb(250, 45, 120, 186));
        Brush dialogueBrush = new SolidBrush(Color.PeachPuff);
        Brush dialogueBrush2 = new SolidBrush(Color.Bisque);

        ////character brushes
        Brush shoeBrush = new SolidBrush(Color.FromArgb(250, 45, 45, 48));
        Brush pantsBrush = new SolidBrush(Color.FromArgb(250, 71, 70, 79));
        Brush shirtBrush = new SolidBrush(Color.FromArgb(250, 96, 95, 99));
        Brush hairBrush = new SolidBrush(Color.FromArgb(250, 42, 42, 61));

        Pen blackPen = new Pen(Color.Black, 1);
        Pen redPen = new Pen(Color.FromArgb(250, 232, 35, 68), 25);
        Pen darkRedPen = new Pen(Color.FromArgb(250, 212, 15, 48), 10);
        Pen greenPen = new Pen(Color.FromArgb(250, 64, 94, 16));
        Pen trunkPen = new Pen(Color.FromArgb(250, 92, 67, 0), 3);
        Pen pondPen = new Pen(Color.FromArgb(250, 5, 80, 146), 4);
        Pen highlight = new Pen(Color.Yellow, 1);
        private void Form1_Load(object sender, EventArgs e)
        {
            character.Location = new Point(this.Width/2 - 15, this.Height / 2 - 20);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (area == "spawn")
            {               
                //color blocking
                e.Graphics.FillRectangle(grassBrush, 0, 0, 1400, 900);
                e.Graphics.FillRectangle(pathBrush, this.Width / 2 - 50, 0, 100, 900);
                e.Graphics.FillRectangle(pathBrush, 50, 50, 350, 200);
                //playground detailing
                e.Graphics.FillRectangle(redBrush, 40, 50, 370, 10);
                e.Graphics.FillRectangle(redBrush, 40, 50, 10, 210);
                e.Graphics.FillRectangle(redBrush, 40, 250, 370, 10);
                e.Graphics.FillRectangle(redBrush, 400, 50, 10, 210);
                ////swingset
                /////support beams
                e.Graphics.DrawLine(blackPen, 65, 150, 95, 70);
                e.Graphics.DrawLine(blackPen, 95, 70, 95, 180);
                e.Graphics.DrawLine(blackPen, 165, 150, 195, 70);
                e.Graphics.DrawLine(blackPen, 195, 70, 195, 180);
                e.Graphics.DrawLine(blackPen, 95, 70, 195, 70);
                //seats
                e.Graphics.FillEllipse(redBrush, 109, 138, 23, 8);
                e.Graphics.FillEllipse(redBrush, 149, 138, 23, 8);
                //swings
                e.Graphics.DrawLine(blackPen, 115, 70, 110, 140);
                e.Graphics.DrawLine(blackPen, 135, 70, 130, 140);
                e.Graphics.DrawLine(blackPen, 155, 70, 150, 140);
                e.Graphics.DrawLine(blackPen, 175, 70, 170, 140);
                if (character.Y >= 153)
                {
                    ////slide
                    //ladder
                    e.Graphics.DrawLine(blackPen, 330, 100, 337, 200);
                    e.Graphics.DrawLine(blackPen, 350, 110, 357, 210);
                    //rungs
                    e.Graphics.DrawLine(blackPen, 350, 120, 331, 110);
                    e.Graphics.DrawLine(blackPen, 351, 135, 333, 125);
                    e.Graphics.DrawLine(blackPen, 352, 150, 333, 140);
                    e.Graphics.DrawLine(blackPen, 353, 165, 334, 155);
                    e.Graphics.DrawLine(blackPen, 354, 180, 335, 170);
                    e.Graphics.DrawLine(blackPen, 355, 195, 336, 185);
                    //slide part
                    e.Graphics.DrawBezier(redPen, 339, 107, 310, 160, 270, 180, 230, 200);
                    e.Graphics.DrawBezier(darkRedPen, 345, 111, 316, 164, 276, 184, 235, 206);
                }
                //////Characters
                ////cat
                e.Graphics.FillRectangle(blackBrush, cat);
                //Tortoise
                e.Graphics.FillRectangle(blackBrush, tortoise);


                if (facing == "front")
                {
                    //////drawing character
                    ////Forward
                    ////shoes and pants
                    e.Graphics.DrawLine(blackPen, character.X + 13, character.Y + 47, character.X + 13, character.Y + 48);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 41, 13, 7);
                    //left
                    e.Graphics.FillRectangle(shoeBrush, character.X + 8, character.Y + 56, 5, 3);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 47, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 12, character.Y + 58);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 8, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 12, character.Y + 58, character.X + 12, character.Y + 48);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 12, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 7, character.Y + 42);
                    //right
                    e.Graphics.FillRectangle(shoeBrush, character.X + 14, character.Y + 56, 5, 3);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 14, character.Y + 47, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 18, character.Y + 58);
                    e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 58, character.X + 18, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 14, character.Y + 48);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 56, character.X + 19, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 56, character.X + 19, character.Y + 42);
                    ////shirt
                    e.Graphics.FillRectangle(shirtBrush, character.X + 1, character.Y + 30, 6, 9);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 2, character.Y + 28, 22, 4);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 7, character.Y + 32, 15, 10);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 20, character.Y + 30, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 20, character.Y + 42);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 27, character.X + 17, character.Y + 27);
                    //left
                    e.Graphics.FillRectangle(whiteBrush, character.X + 3, character.Y + 38, 4, 3);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 20, character.Y + 38, 4, 3);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 6, character.Y + 33);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 40, character.X + 2, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 6, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 38, character.X + 2, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 1, character.Y + 30);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 30, character.X + 3, character.Y + 28);
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 28, character.X + 9, character.Y + 28);
                    //right
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 42, character.X + 20, character.Y + 33);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 40, character.X + 24, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 38, character.X + 25, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 40, character.X + 24, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 38, character.X + 25, character.Y + 30);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 30, character.X + 23, character.Y + 28);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 28, character.X + 17, character.Y + 28);
                    //detailing
                    e.Graphics.DrawLine(blackPen, character.X + 15, character.Y + 27, character.X + 15, character.Y + 42);
                    e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 30, 2, 2);
                    e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 34, 2, 2);
                    e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 38, 2, 2);
                    ////head
                    e.Graphics.FillRectangle(whiteBrush, character.X + 8, character.Y + 10, 11, 17);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 5, character.Y + 22, 4, 3);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 2, character.Y + 11, 6, 11);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 1, character.Y + 11, 2, 7);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 19, character.Y + 13, 3, 13);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 22, character.Y + 11, 3, 12);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 25, character.Y + 11, 2, 8);

                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 26, character.X + 18, character.Y + 26);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y, character.X + 17, character.Y);
                    //left
                    e.Graphics.FillRectangle(blackBrush, character.X + 9, character.Y + 14, 2, 3);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 25, character.X + 8, character.Y + 25);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 24, character.X + 5, character.Y + 24);
                    e.Graphics.DrawLine(blackPen, character.X + 5, character.Y + 23, character.X + 4, character.Y + 23);
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 22, character.X + 4, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 21, character.X + 3, character.Y + 21);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 21, character.X + 1, character.Y + 17);
                    e.Graphics.DrawLine(blackPen, character.X, character.Y + 17, character.X, character.Y + 8);
                    e.Graphics.DrawLine(blackPen, character.X, character.Y + 8, character.X + 7, character.Y + 1);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 1, character.X + 9, character.Y + 1);
                    //right
                    e.Graphics.FillRectangle(blackBrush, character.X + 16, character.Y + 14, 2, 3);
                    e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 25, character.X + 21, character.Y + 25);
                    e.Graphics.DrawLine(blackPen, character.X + 21, character.Y + 24, character.X + 22, character.Y + 24);
                    e.Graphics.DrawLine(blackPen, character.X + 22, character.Y + 23, character.X + 23, character.Y + 23);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 22, character.X + 24, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 21, character.X + 25, character.Y + 21);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 21, character.X + 26, character.Y + 17);
                    e.Graphics.DrawLine(blackPen, character.X + 27, character.Y + 17, character.X + 27, character.Y + 8);
                    e.Graphics.DrawLine(blackPen, character.X + 27, character.Y + 8, character.X + 20, character.Y + 1);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 1, character.X + 18, character.Y + 1);
                    ////hair
                    e.Graphics.FillRectangle(hairBrush, character.X + 9, character.Y + 1, 9, 11);
                    e.Graphics.FillRectangle(hairBrush, character.X + 6, character.Y + 2, 3, 10);
                    e.Graphics.FillRectangle(hairBrush, character.X + 1, character.Y + 7, 6, 4);
                    e.Graphics.FillRectangle(hairBrush, character.X + 4, character.Y + 4, 2, 3);
                    e.Graphics.FillRectangle(hairBrush, character.X + 3, character.Y + 6, 2, 2);
                    e.Graphics.FillRectangle(hairBrush, character.X + 18, character.Y + 2, 3, 10);
                    e.Graphics.FillRectangle(hairBrush, character.X + 21, character.Y + 3, 2, 8);
                    e.Graphics.FillRectangle(hairBrush, character.X + 23, character.Y + 5, 2, 6);
                    e.Graphics.FillRectangle(hairBrush, character.X + 25, character.Y + 7, 3, 3);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 10, character.X + 4, character.Y + 10);
                    e.Graphics.DrawLine(blackPen, character.X + 4, character.Y + 11, character.X + 5, character.Y + 11);
                    e.Graphics.DrawLine(blackPen, character.X + 5, character.Y + 12, character.X + 9, character.Y + 12);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 11, character.X + 11, character.Y + 11);
                    e.Graphics.DrawLine(blackPen, character.X + 11, character.Y + 10, character.X + 15, character.Y + 10);
                    e.Graphics.DrawLine(blackPen, character.X + 15, character.Y + 11, character.X + 17, character.Y + 11);
                    e.Graphics.DrawLine(blackPen, character.X + 17, character.Y + 12, character.X + 20, character.Y + 12);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 11, character.X + 22, character.Y + 11);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 10, character.X + 26, character.Y + 10);
                    // details
                }
                if (facing == "back")
                {
                    ////Facing back
                    ////shoes and pants
                    e.Graphics.DrawLine(blackPen, character.X + 13, character.Y + 47, character.X + 13, character.Y + 48);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 41, 13, 7);
                    //left
                    e.Graphics.FillRectangle(shoeBrush, character.X + 8, character.Y + 56, 5, 3);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 47, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 12, character.Y + 58);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 8, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 12, character.Y + 58, character.X + 12, character.Y + 48);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 12, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 7, character.Y + 42);
                    //right
                    e.Graphics.FillRectangle(shoeBrush, character.X + 14, character.Y + 56, 5, 3);
                    e.Graphics.FillRectangle(pantsBrush, character.X + 14, character.Y + 47, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 18, character.Y + 58);
                    e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 58, character.X + 18, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 14, character.Y + 48);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 56, character.X + 19, character.Y + 56);
                    e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 56, character.X + 19, character.Y + 42);
                    ////shirt
                    e.Graphics.FillRectangle(shirtBrush, character.X + 1, character.Y + 30, 6, 9);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 2, character.Y + 28, 22, 4);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 7, character.Y + 32, 15, 10);
                    e.Graphics.FillRectangle(shirtBrush, character.X + 20, character.Y + 30, 6, 9);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 20, character.Y + 42);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 27, character.X + 17, character.Y + 27);
                    //left
                    e.Graphics.FillRectangle(whiteBrush, character.X + 3, character.Y + 38, 4, 3);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 20, character.Y + 38, 4, 3);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 6, character.Y + 33);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 40, character.X + 2, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 6, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 38, character.X + 2, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 1, character.Y + 30);
                    e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 30, character.X + 3, character.Y + 28);
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 28, character.X + 9, character.Y + 28);
                    //right
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 42, character.X + 20, character.Y + 33);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 40, character.X + 24, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 38, character.X + 25, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 40, character.X + 24, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 38, character.X + 25, character.Y + 30);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 30, character.X + 23, character.Y + 28);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 28, character.X + 17, character.Y + 28);
                    //detailing
                    ////head
                    //hair
                    e.Graphics.FillRectangle(hairBrush, character.X + 7, character.Y + 2, 15, 24);
                    e.Graphics.FillRectangle(hairBrush, character.X + 22, character.Y + 7, 5, 13);
                    e.Graphics.FillRectangle(hairBrush, character.X + 1, character.Y + 7, 6, 13);
                    e.Graphics.FillRectangle(hairBrush, character.X + 3, character.Y + 5, 22, 4);
                    e.Graphics.FillRectangle(hairBrush, character.X + 5, character.Y + 3, 18, 2);
                    e.Graphics.FillRectangle(hairBrush, character.X + 8, character.Y + 1, 12, 2);
                    e.Graphics.FillRectangle(hairBrush, character.X + 8, character.Y + 10, 11, 17);
                    e.Graphics.FillRectangle(hairBrush, character.X + 5, character.Y + 22, 4, 3);
                    e.Graphics.FillRectangle(hairBrush, character.X + 2, character.Y + 11, 6, 11);
                    e.Graphics.FillRectangle(hairBrush, character.X + 1, character.Y + 11, 2, 7);
                    e.Graphics.FillRectangle(hairBrush, character.X + 19, character.Y + 13, 3, 13);
                    e.Graphics.FillRectangle(hairBrush, character.X + 22, character.Y + 11, 3, 12);
                    e.Graphics.FillRectangle(hairBrush, character.X + 25, character.Y + 11, 2, 8);

                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 26, character.X + 18, character.Y + 26);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y, character.X + 17, character.Y);
                    //left
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 25, character.X + 8, character.Y + 25);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 24, character.X + 5, character.Y + 24);
                    e.Graphics.DrawLine(blackPen, character.X + 5, character.Y + 23, character.X + 4, character.Y + 23);
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 22, character.X + 4, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 21, character.X + 3, character.Y + 21);
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 21, character.X + 1, character.Y + 17);
                    e.Graphics.DrawLine(blackPen, character.X, character.Y + 17, character.X, character.Y + 8);
                    e.Graphics.DrawLine(blackPen, character.X, character.Y + 8, character.X + 7, character.Y + 1);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 1, character.X + 9, character.Y + 1);
                    //right
                    e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 25, character.X + 21, character.Y + 25);
                    e.Graphics.DrawLine(blackPen, character.X + 21, character.Y + 24, character.X + 22, character.Y + 24);
                    e.Graphics.DrawLine(blackPen, character.X + 22, character.Y + 23, character.X + 23, character.Y + 23);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 22, character.X + 24, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 21, character.X + 25, character.Y + 21);
                    e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 21, character.X + 26, character.Y + 17);
                    e.Graphics.DrawLine(blackPen, character.X + 27, character.Y + 17, character.X + 27, character.Y + 8);
                    e.Graphics.DrawLine(blackPen, character.X + 27, character.Y + 8, character.X + 20, character.Y + 1);
                    e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 1, character.X + 18, character.Y + 1);                    
                }
                if (facing == "right")
                {
                    
                    ////shoe and pants
                    //shoe
                    e.Graphics.FillRectangle(shoeBrush, character.X + 11, character.Y + 57, 7, 2);
                    e.Graphics.DrawLine(blackPen, character.X +  9, character.Y + 57, character.X + 18, character.Y + 57);
                    e.Graphics.DrawLine(blackPen, character.X + 10, character.Y + 58, character.X + 11, character.Y + 58);
                    e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 58, character.X + 18, character.Y + 58);
                    //pants
                    e.Graphics.FillRectangle(pantsBrush, character.X + 10, character.Y + 42, 6, 15);
                    e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 42, character.X + 9, character.Y + 57);
                    e.Graphics.DrawLine(blackPen, character.X + 16, character.Y + 42, character.X + 16, character.Y + 57);
                    ////Shirt
                    //outline
                    e.Graphics.FillRectangle(shirtBrush, character.X + 8, character.Y + 26, 11, 16);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 42, character.X + 17, character.Y + 42);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 42, character.X + 8, character.Y + 26);
                    e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 41, character.X + 18, character.Y + 26);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 26, character.X + 17, character.Y + 26);
                    //sleeve
                    e.Graphics.FillRectangle(whiteBrush, character.X + 11, character.Y + 38, 5, 2);
                    e.Graphics.DrawLine(blackPen, character.X + 10, character.Y + 28, character.X + 10, character.Y + 38);
                    e.Graphics.DrawLine(blackPen, character.X + 15, character.Y + 28, character.X + 15, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 10, character.Y + 38, character.X + 15, character.Y + 38);
                    //hand                    
                    e.Graphics.DrawLine(blackPen, character.X + 11, character.Y + 40, character.X + 15, character.Y + 40);
                    e.Graphics.DrawLine(blackPen, character.X + 11, character.Y + 40, character.X + 11, character.Y + 38);
                    ////head
                    //face
                    e.Graphics.FillRectangle(whiteBrush, character.X + 6, character.Y + 8, 16, 16);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 8, character.Y + 24, 13, 2);
                    e.Graphics.FillRectangle(whiteBrush, character.X + 5, character.Y + 16, 6, 6);
                    //hair color
                    e.Graphics.FillRectangle(hairBrush, character.X + 2, character.Y + 8, 8, 7);
                    e.Graphics.FillRectangle(hairBrush, character.X + 3, character.Y + 5, 22, 3);
                    e.Graphics.FillRectangle(hairBrush, character.X + 7, character.Y + 2, 16, 9);
                    e.Graphics.FillRectangle(hairBrush, character.X + 11, character.Y, 11, 3);
                    e.Graphics.FillRectangle(hairBrush, character.X + 8, character.Y + 11, 11, 3);
                    e.Graphics.FillRectangle(hairBrush, character.X + 22, character.Y + 4, 3, 6);
                    //head outline
                    e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 26, character.X + 22, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 22, character.Y + 22, character.X + 22, character.Y + 21);
                    e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 20, character.X + 23, character.Y + 9);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 26, character.X + 7, character.Y + 26);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 26, character.X + 7, character.Y + 24);
                    e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 24, character.X + 6, character.Y + 22);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 22, character.X + 5, character.Y + 19);
                    e.Graphics.DrawLine(blackPen, character.X + 4, character.Y + 18, character.X + 4, character.Y + 16);
                    e.Graphics.DrawLine(blackPen, character.X + 4, character.Y + 16, character.X + 4, character.Y + 15);
                    //hair
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 15, character.X + 5, character.Y + 15);
                    e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 14, character.X + 8, character.Y + 14);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 13, character.X + 14, character.Y + 13);
                    e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 12, character.X + 18, character.Y + 12);
                    e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 11, character.X + 20, character.Y + 11);
                    e.Graphics.DrawLine(blackPen, character.X + 21, character.Y + 10, character.X + 23, character.Y + 8);
                    //top hair
                    e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 14, character.X + 2, character.Y + 7);
                    e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 6, character.X + 4, character.Y + 6);
                    e.Graphics.DrawLine(blackPen, character.X + 4, character.Y + 7, character.X + 4, character.Y + 5);
                    e.Graphics.DrawLine(blackPen, character.X + 5, character.Y + 5, character.X + 7, character.Y + 3);
                    e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 2, character.X + 9, character.Y + 1);
                    e.Graphics.DrawLine(blackPen, character.X + 11, character.Y, character.X + 21, character.Y);
                    e.Graphics.DrawLine(blackPen, character.X + 22, character.Y, character.X + 24, character.Y + 4);
                    e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 4, character.X + 24, character.Y + 9);
                    ////
                    //detailing
                    e.Graphics.FillRectangle(blackBrush, character.X + 19, character.Y + 15, 2, 3);
                    e.Graphics.FillRectangle(blackBrush, character.X + 17, character.Y + 30, 1, 1);
                    e.Graphics.FillRectangle(blackBrush, character.X + 17, character.Y + 33, 1, 1);
                    e.Graphics.FillRectangle(blackBrush, character.X + 17, character.Y + 36, 1, 1);


                }
                if(character.Y<153)
                {
                    ////slide
                    //ladder
                    e.Graphics.DrawLine(blackPen, 330, 100, 337, 200);
                    e.Graphics.DrawLine(blackPen, 350, 110, 357, 210);
                    //rungs
                    e.Graphics.DrawLine(blackPen, 350, 120, 331, 110);
                    e.Graphics.DrawLine(blackPen, 351, 135, 333, 125);
                    e.Graphics.DrawLine(blackPen, 352, 150, 333, 140);
                    e.Graphics.DrawLine(blackPen, 353, 165, 334, 155);
                    e.Graphics.DrawLine(blackPen, 354, 180, 335, 170);
                    e.Graphics.DrawLine(blackPen, 355, 195, 336, 185);
                    //slide part
                    e.Graphics.DrawBezier(redPen, 339, 107, 310, 160, 270, 180, 230, 200);
                    e.Graphics.DrawBezier(darkRedPen, 345, 111, 316, 164, 276, 184, 235, 206);

                }
                ////mouse
                if (mouseVisible == true)
                {
                    e.Graphics.FillRectangle(blackBrush, mouseC);
                }
                ////Trees
                //Top Right
                //enclosure
                e.Graphics.FillRectangle(dirtBrush, this.Width / 4 * 3 - 50, 160, 100, 70);
                //tree trunk
                e.Graphics.FillRectangle(trunkBrush, this.Width / 4 * 3 - 15, 90, 30, 110);
                //leaves
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 50, 80, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 60, 50, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 40, 30, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 10, 30, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 10, 50, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3, 80, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 25, 50, 50, 80);
                //leaf outlines
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 50, 80, 50, 50, 30, 230);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 60, 50, 50, 50, 120, 200);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 40, 30, 50, 50, 190, 160);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 10, 30, 50, 50, 230, 160);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 10, 50, 50, 50, 280, 180);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3, 80, 50, 50, 340, 170);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 25, 50, 50, 80, 70, 40);
                //eyes
                e.Graphics.FillEllipse(whiteBrush, this.Width / 4 * 3 - 23, 70, 18, 18);
                e.Graphics.FillEllipse(whiteBrush, this.Width / 4 * 3 + 5, 70, 18, 18);
                e.Graphics.DrawEllipse(blackPen, this.Width / 4 * 3 - 23, 70, 18, 18);
                e.Graphics.DrawEllipse(blackPen, this.Width / 4 * 3 + 5, 70, 18, 18);
                e.Graphics.FillEllipse(blackBrush, this.Width / 4 * 3 - 17, 77, 5, 5);
                e.Graphics.FillEllipse(blackBrush, this.Width / 4 * 3 + 11, 77, 5, 5);
                //Bottom Right
                //enclosure
                e.Graphics.FillRectangle(dirtBrush, this.Width / 4 * 3, 560, 100, 70);
                //tree trunk
                e.Graphics.FillRectangle(trunkBrush, this.Width / 4 * 3 + 35, 490, 30, 110);
                e.Graphics.DrawLine(trunkPen, this.Width / 4 * 3 + 35, 490, this.Width / 4 * 3 + 35, 600);
                e.Graphics.DrawLine(trunkPen, this.Width / 4 * 3 + 65, 490, this.Width / 4 * 3 + 65, 600);
                //leaves
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 , 480, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 - 10, 450, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 10, 430, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 40, 430, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 60, 450, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 50, 480, 50, 50);
                e.Graphics.FillEllipse(leafBrush, this.Width / 4 * 3 + 25, 450, 50, 80);
                //leaf outlines
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3, 480, 50, 50, 30, 230);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 - 10, 450, 50, 50, 120, 200);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 10, 430, 50, 50, 190, 160);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 40, 430, 50, 50, 230, 160);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 60, 450, 50, 50, 280, 180);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 50, 480, 50, 50, 340, 170);
                e.Graphics.DrawArc(greenPen, this.Width / 4 * 3 + 25, 450, 50, 80, 70, 40);
                //eyes
                e.Graphics.FillEllipse(whiteBrush, this.Width / 4 * 3 + 27, 470, 18, 18);
                e.Graphics.FillEllipse(whiteBrush, this.Width / 4 * 3 + 55, 470, 18, 18);
                e.Graphics.DrawEllipse(blackPen, this.Width / 4 * 3 + 27, 470, 18, 18);
                e.Graphics.DrawEllipse(blackPen, this.Width / 4 * 3 + 55, 470, 18, 18);
                e.Graphics.FillEllipse(blackBrush, this.Width / 4 * 3 + 38, 477, 5, 5);
                e.Graphics.FillEllipse(blackBrush, this.Width / 4 * 3 + 66, 477, 5, 5);
                if (dialogueVisible == true)
                {                    
                    e.Graphics.FillRectangle(dialogueBrush, dialogue);
                    e.Graphics.DrawRectangle(blackPen, dialogue);
                }
            }
            else if (area == "pond")
            {
                //background
                e.Graphics.FillRectangle(pondGrassBrush, 0, 0, 1400, 900);
                e.Graphics.FillEllipse(pondBrush, this.Width / 2 - 300, this.Height / 2 - 250, 600, 500);
                e.Graphics.DrawEllipse(pondPen, this.Width / 2 - 300, this.Height / 2 - 250, 600, 500);
                e.Graphics.FillEllipse(pondBrush, 200, 400, 300, 250);
                e.Graphics.FillEllipse(pondBrush, 600, 150, 300, 250);
                e.Graphics.DrawArc(pondPen, 200, 400, 300, 250, 36, 210);
                e.Graphics.DrawArc(pondPen, 600, 150, 300, 250, 245, 210);
                //////drawing character
                ////shoes and pants
                e.Graphics.DrawLine(blackPen, character.X + 13, character.Y + 47, character.X + 13, character.Y + 48);
                e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 41, 13, 7);
                //left
                e.Graphics.FillRectangle(shoeBrush, character.X + 8, character.Y + 56, 5, 3);
                e.Graphics.FillRectangle(pantsBrush, character.X + 7, character.Y + 47, 6, 9);
                e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 12, character.Y + 58);
                e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 58, character.X + 8, character.Y + 56);
                e.Graphics.DrawLine(blackPen, character.X + 12, character.Y + 58, character.X + 12, character.Y + 48);
                e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 12, character.Y + 56);
                e.Graphics.DrawLine(blackPen, character.X + 7, character.Y + 56, character.X + 7, character.Y + 42);
                //right
                e.Graphics.FillRectangle(shoeBrush, character.X + 14, character.Y + 56, 5, 3);
                e.Graphics.FillRectangle(pantsBrush, character.X + 14, character.Y + 47, 6, 9);
                e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 18, character.Y + 58);
                e.Graphics.DrawLine(blackPen, character.X + 18, character.Y + 58, character.X + 18, character.Y + 56);
                e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 58, character.X + 14, character.Y + 48);
                e.Graphics.DrawLine(blackPen, character.X + 14, character.Y + 56, character.X + 19, character.Y + 56);
                e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 56, character.X + 19, character.Y + 42);
                ////shirt
                e.Graphics.FillRectangle(shirtBrush, character.X + 1, character.Y + 30, 6, 9);
                e.Graphics.FillRectangle(shirtBrush, character.X + 2, character.Y + 28, 22, 4);
                e.Graphics.FillRectangle(shirtBrush, character.X + 7, character.Y + 32, 15, 10);
                e.Graphics.FillRectangle(shirtBrush, character.X + 20, character.Y + 30, 6, 9);
                e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 20, character.Y + 42);
                e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 27, character.X + 17, character.Y + 27);
                //left
                e.Graphics.FillRectangle(whiteBrush, character.X + 3, character.Y + 38, 4, 3);
                e.Graphics.FillRectangle(whiteBrush, character.X + 20, character.Y + 38, 4, 3);
                e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 42, character.X + 6, character.Y + 33);
                e.Graphics.DrawLine(blackPen, character.X + 6, character.Y + 40, character.X + 2, character.Y + 40);
                e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 6, character.Y + 38);
                e.Graphics.DrawLine(blackPen, character.X + 2, character.Y + 38, character.X + 2, character.Y + 40);
                e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 38, character.X + 1, character.Y + 30);
                e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 30, character.X + 3, character.Y + 28);
                e.Graphics.DrawLine(blackPen, character.X + 3, character.Y + 28, character.X + 9, character.Y + 28);
                //right
                e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 42, character.X + 20, character.Y + 33);
                e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 40, character.X + 24, character.Y + 40);
                e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 38, character.X + 25, character.Y + 38);
                e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 40, character.X + 24, character.Y + 38);
                e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 38, character.X + 25, character.Y + 30);
                e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 30, character.X + 23, character.Y + 28);
                e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 28, character.X + 17, character.Y + 28);
                //detailing
                e.Graphics.DrawLine(blackPen, character.X + 15, character.Y + 27, character.X + 15, character.Y + 42);
                e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 30, 2, 2);
                e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 34, 2, 2);
                e.Graphics.FillRectangle(blackBrush, character.X + 12, character.Y + 38, 2, 2);
                ////head
                e.Graphics.FillRectangle(whiteBrush, character.X + 8, character.Y + 10, 11, 17);
                e.Graphics.FillRectangle(whiteBrush, character.X + 5, character.Y + 22, 4, 3);
                e.Graphics.FillRectangle(whiteBrush, character.X + 2, character.Y + 11, 6, 11);
                e.Graphics.FillRectangle(whiteBrush, character.X + 1, character.Y + 11, 2, 7);
                e.Graphics.FillRectangle(whiteBrush, character.X + 19, character.Y + 13, 3, 13);
                e.Graphics.FillRectangle(whiteBrush, character.X + 22, character.Y + 11, 3, 12);
                e.Graphics.FillRectangle(whiteBrush, character.X + 25, character.Y + 11, 2, 8);
               
                e.Graphics.DrawLine(blackPen, character.X + 8, character.Y + 26, character.X + 18, character.Y + 26);
                e.Graphics.DrawLine(blackPen, character.X + 9, character.Y     , character.X + 17, character.Y     );
                //left
                e.Graphics.FillRectangle(blackBrush, character.X + 9, character.Y + 14, 2, 3);
                e.Graphics.DrawLine(blackPen,  character.X + 6, character.Y + 25, character.X + 8, character.Y + 25);
                e.Graphics.DrawLine(blackPen,  character.X + 6, character.Y + 24, character.X + 5, character.Y + 24);
                e.Graphics.DrawLine(blackPen,  character.X + 5, character.Y + 23, character.X + 4, character.Y + 23);
                e.Graphics.DrawLine(blackPen,  character.X + 3, character.Y + 22, character.X + 4, character.Y + 22);
                e.Graphics.DrawLine(blackPen,  character.X + 2, character.Y + 21, character.X + 3, character.Y + 21);
                e.Graphics.DrawLine(blackPen,  character.X + 2, character.Y + 21, character.X + 1, character.Y + 17);
                e.Graphics.DrawLine(blackPen,  character.X    , character.Y + 17, character.X    , character.Y + 8);
                e.Graphics.DrawLine(blackPen,  character.X    , character.Y +  8, character.X + 7, character.Y + 1);
                e.Graphics.DrawLine(blackPen,  character.X + 7, character.Y +  1, character.X + 9, character.Y + 1);
                //right
                e.Graphics.FillRectangle(blackBrush, character.X + 16, character.Y + 14, 2, 3);
                e.Graphics.DrawLine(blackPen, character.X + 19, character.Y + 25, character.X + 21, character.Y + 25);
                e.Graphics.DrawLine(blackPen, character.X + 21, character.Y + 24, character.X + 22, character.Y + 24);
                e.Graphics.DrawLine(blackPen, character.X + 22, character.Y + 23, character.X + 23, character.Y + 23);
                e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 22, character.X + 24, character.Y + 22);
                e.Graphics.DrawLine(blackPen, character.X + 24, character.Y + 21, character.X + 25, character.Y + 21);
                e.Graphics.DrawLine(blackPen, character.X + 25, character.Y + 21, character.X + 26, character.Y + 17);
                e.Graphics.DrawLine(blackPen, character.X + 27, character.Y + 17, character.X + 27, character.Y + 8);
                e.Graphics.DrawLine(blackPen, character.X + 27, character.Y +  8, character.X + 20, character.Y + 1);
                e.Graphics.DrawLine(blackPen, character.X + 20, character.Y +  1, character.X + 18, character.Y + 1);
                ////hair
                e.Graphics.FillRectangle(hairBrush, character.X + 9, character.Y + 1, 9, 11);
                e.Graphics.FillRectangle(hairBrush, character.X + 6, character.Y + 2, 3, 10);
                e.Graphics.FillRectangle(hairBrush, character.X + 1, character.Y + 7, 6, 4);
                e.Graphics.FillRectangle(hairBrush, character.X + 4, character.Y + 4, 2, 3);
                e.Graphics.FillRectangle(hairBrush, character.X + 3, character.Y + 6, 2, 2);
                e.Graphics.FillRectangle(hairBrush, character.X + 18, character.Y + 2, 3, 10);
                e.Graphics.FillRectangle(hairBrush, character.X + 21, character.Y + 3, 2, 8);
                e.Graphics.FillRectangle(hairBrush, character.X + 23, character.Y + 5, 2, 6);
                e.Graphics.FillRectangle(hairBrush, character.X + 25, character.Y + 7, 3, 3);
                e.Graphics.DrawLine(blackPen, character.X + 1, character.Y + 10, character.X + 4, character.Y + 10);
                e.Graphics.DrawLine(blackPen, character.X + 4, character.Y + 11, character.X + 5, character.Y + 11);
                e.Graphics.DrawLine(blackPen, character.X + 5, character.Y + 12, character.X + 9, character.Y + 12);
                e.Graphics.DrawLine(blackPen, character.X + 9, character.Y + 11, character.X + 11, character.Y + 11);
                e.Graphics.DrawLine(blackPen, character.X + 11, character.Y + 10, character.X + 15, character.Y + 10);
                e.Graphics.DrawLine(blackPen, character.X + 15, character.Y + 11, character.X + 17, character.Y + 11);
                e.Graphics.DrawLine(blackPen, character.X + 17, character.Y + 12, character.X + 20, character.Y + 12);
                e.Graphics.DrawLine(blackPen, character.X + 20, character.Y + 11, character.X + 22, character.Y + 11);
                e.Graphics.DrawLine(blackPen, character.X + 23, character.Y + 10, character.X + 26, character.Y + 10);
                // details

            }
            if(inventory == true)
            {
                //background
                e.Graphics.FillRectangle(dialogueBrush, this.Width/2 - 250, 15, 500, 650);
                e.Graphics.DrawRectangle(blackPen, this.Width/2 - 250, 15, 500, 650);

                ////item display
                //filling
                //r1
                e.Graphics.FillRectangle(dialogueBrush2, r1c1);
                e.Graphics.FillRectangle(dialogueBrush2, r1c2);
                e.Graphics.FillRectangle(dialogueBrush2, r1c3);
                e.Graphics.FillRectangle(dialogueBrush2, r1c4);
                //r2
                e.Graphics.FillRectangle(dialogueBrush2, r2c1);
                e.Graphics.FillRectangle(dialogueBrush2, r2c2);
                e.Graphics.FillRectangle(dialogueBrush2, r2c3);
                e.Graphics.FillRectangle(dialogueBrush2, r2c4);
                //drawing
                e.Graphics.DrawRectangle(blackPen, 300, 40, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 420, 40, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 540, 40, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 660, 40, 100, 100);
                //r2
                e.Graphics.DrawRectangle(blackPen, 300, 160, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 420, 160, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 540, 160, 100, 100);
                e.Graphics.DrawRectangle(blackPen, 660, 160, 100, 100);

                //stats
                Font font = new Font("MV Boli", 14);
                e.Graphics.DrawString($"ATK.........{atk}                      DEF..........{def}", font, blackBrush, 310, 280);

                //descriptions
                e.Graphics.FillRectangle(dialogueBrush2, 300, 320, 460, 250);
                

            }
            //grid
            if (testing == true)
            {
                e.Graphics.DrawLine(blackPen, this.Width / 2, 0, this.Width / 2, 900);
                e.Graphics.DrawLine(blackPen, this.Width / 4, 0, this.Width / 4, 900);
                e.Graphics.DrawLine(blackPen, this.Width / 4 * 3, 0, this.Width / 4 * 3, 900);
                e.Graphics.DrawLine(blackPen, 0, this.Height / 2, 1400, this.Height / 2);
                e.Graphics.DrawLine(blackPen, 0, this.Height / 4, 1400, this.Height / 4);
                e.Graphics.DrawLine(blackPen, 0, this.Height / 4 * 3, 1400, this.Height / 4 * 3);
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;

                case Keys.E:
                    eDown = false;
                    break;

                case Keys.D1:
                    oneDown = false;
                    break;
                case Keys.D2:
                    twoDown = false;
                    break;
                case Keys.D3:
                    threeDown = false;
                    break;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;

                case Keys.E:
                    eDown = true;
                    break;

                case Keys.D1:
                    oneDown = true;
                    break;
                case Keys.D2:
                    twoDown = true;
                    break;
                case Keys.D3:
                    threeDown = true;
                    break;

            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            if (inventory == false)
            {
                //moving the character
                debugLabel.Text = $"{character.X}, {character.Y}";
                if (wDown == true)
                {
                    character.Y -= 5;
                    facing = "back";
                }
                else if (sDown == true)
                {
                    character.Y += 5;
                    facing = "front";
                }
                if (aDown == true)
                {
                    character.X -= 5;
                    facing = "left";
                }
                else if (dDown == true)
                {
                    character.X += 5;
                    facing = "right";
                }
                //inventory
                if (oneDown == true && battle == false)
                {
                    inventory = true;
                    oneDown = false;    
                }
                else
                {

                }
                if (area == "spawn")
                {
                    ////Interactions
                    if (eDown == true)
                    {
                        if (character.X < 171 && character.X > 100 && character.Y > 100 && character.Y < 150)
                        {
                            debugLabel.Text = "swing";
                            swingA();
                        }
                        else if (character.X < 380 && character.X > 330 && character.Y > -12 && character.Y < 75)
                        {
                            debugLabel.Text = "cat";
                            catQuest();
                        }
                        else if (character.IntersectsWith(mouseC))
                        {
                            debugLabel.Text = "mouse caught";
                            InventoryList.Insert(1, "mouse");
                            mouseVisible = false;
                        }
                        label1.Text = $"{InventoryList[1]}";
                    }
                    ////Characters
                    //Mouse
                    if (mouseM <= 25)
                    {
                        mouseC.X += 6;
                        mouseM++;
                    }
                    else if (mouseM <= 45)
                    {                       
                        mouseC.Y += 5;
                        mouseM++;
                    }
                    else if (mouseM <= 71)
                    {
                        mouseC.X -= 6;
                        mouseM++;
                    }
                    else if (mouseM <= 91)
                    {
                        mouseC.Y -= 5;
                        mouseM++;
                    }
                    else
                    {
                        mouseM = 0;
                    }

                    //Area Change
                    if (character.Y >= 660)
                    {
                        area = "pond";
                        character.Y = 0;
                    }
                }
                else if (area == "pond")
                {
                    if (character.Y <= -1)
                    {
                        area = "spawn";
                        character.Y = 659;
                    }
                }
            }
            else
            {
                
                switch (viewingInventory)
                {
                    case 1:
                        try
                        {
                            if (InventoryList[1] == null)
                            {

                            }
                            else
                            {
                                inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[1]}";
                            }
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 2:
                        if (InventoryList[2] == "")
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        else
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[2]}";
                        }
                        
                        break;
                    case 3:
                        try
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[3]}";
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 4:
                        try
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[4]}";
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 5:
                        try
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[5]}";
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 6:
                        try 
                        { 
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[6]}";
                        }
                        catch 
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 7:
                        try
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[7]}";
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;
                    case 8:
                        try
                        {
                            inventoryLabel.Text = $"PLACEHOLDER TEXT{InventoryList[8]}";
                        }
                        catch
                        {
                            inventoryLabel.Text = "This space is empty";
                        }
                        break;                        
                }
                debugLabel.Text = $"{viewingInventory}";
                if (oneDown == true)
                {
                    inventoryLabel.Text = "...";
                    inventory = false;
                    oneDown = false;
                }
            }
        
            Refresh();
        }

        
        ////Spawn area interactions
        //true interactions
        public void swingA()
        {
            facing = "front";
            gameEngine.Stop();
            for (int i = 0; i < 60; i++)
            {
                if (character.X < 147)
                {
                    character.X++;
                }
                else if (character.X > 147)
                {
                    character.X--;
                }
                else
                {
                    character.X = 147;
                }
                if (character.Y < 96)
                {
                    character.Y++;
                }
                else if (character.Y > 96)
                {
                    character.Y--;
                }
                else
                {
                    character.Y = 96;
                }
                Refresh();
            }
            gameEngine.Start();
        }
        public void catQuest ()
        {
            gameEngine.Stop();
            facing = "back";
            eDown = false;
            
            for (int i = 0; i < 60;i++)
            {
                if (character.X < 360)
                {
                    character.X++;
                }
                else if (character.X > 360)
                {
                    character.X--;
                }
                else
                {
                    character.X = 360;
                }
                if (character.Y < 53)
                {
                    character.Y++;
                }
                else if (character.Y > 53)
                {
                    character.Y--;
                }
                else
                {
                    character.Y = 53;
                }
                Refresh();
            }
            if (mouseVisible == true)
            {
                dialogueLabel.Text = "Hey! My ... friend over there is running too fast for me. We're meant to be playing tag, but I just can't keep up! Do you think you could catch them for me?";
                dialogueVisible = true;
                dialogueLabel.Visible = true;
                Refresh();
                Thread.Sleep(1500);
                dialogueLabel.Text = "Yeah, that little gray mouse over there.";
                Thread.Sleep(1000);
                Refresh();

                dialogueLabel.Visible = false;
                dialogueVisible = false;
                gameEngine.Start();
                Thread.Sleep(750);
                Refresh();
            }
            else if (mouseVisible == false && catQuestV == false)
            {
                dialogueLabel.Text = "Ooh, goody! My friend and I can now have a wonderful time...";
                dialogueVisible = true;
                dialogueLabel.Visible = true;
                Refresh();
                Thread.Sleep(1800);
                dialogueLabel.Text = "Alright, off you go now...";
                Refresh();
                Thread.Sleep(1800);
                dialogueLabel.Text = "...go";
                Refresh();
                Thread.Sleep(1800);
                catQuestV = true;
                dialogueLabel.Visible = false;
                dialogueVisible = false;
                gameEngine.Start();
            }       
            else if (catQuestV == true)
            {
                gameEngine.Stop();
                dialogueLabel.Text = "Thanks again!";
                dialogueVisible = true;
                dialogueLabel.Visible = true;
                Refresh();
                Thread.Sleep(1800);

                dialogueLabel.Visible = false;
                dialogueVisible = false;
                gameEngine.Start();
            }
        }       
        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (inventory == true)
            {
                if (MousePosition.X >= r1c1.X && MousePosition.X <= r1c1.X + 100)
                {
                    if (MousePosition.Y >= r1c1.Y && MousePosition.Y <= r1c1.Y + 100)
                    {
                        viewingInventory = 1;
                    }
                    else
                    {
                        viewingInventory = 5;
                    }
                }
                else if (MousePosition.X >= r1c2.X && MousePosition.X <= r1c2.X + 100)
                {
                    if (MousePosition.Y >= r1c2.Y && MousePosition.Y <= r1c2.Y + 100)
                    {
                        viewingInventory = 2;
                    }
                    else
                    {
                        viewingInventory = 6;
                    }
                }
                else if (MousePosition.X >= r1c3.X && MousePosition.X <= r1c3.X + 100)
                {
                    if (MousePosition.Y >= r1c3.Y && MousePosition.Y <= r1c3.Y + 100)
                    {
                        viewingInventory = 3;
                    }
                    else
                    {
                        viewingInventory = 7;
                    }
                }
                else if (MousePosition.X >= r1c4.X && MousePosition.X <= r1c4.X + 100)
                {
                    if (MousePosition.Y >= r1c4.Y && MousePosition.Y <= r1c4.Y + 100)
                    {
                        viewingInventory = 4;
                    }
                    else
                    {
                        viewingInventory = 8;
                    }
                }
            }        
        }

      
    }
}
