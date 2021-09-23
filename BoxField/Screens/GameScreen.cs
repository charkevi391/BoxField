using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush[] ColorArray = new SolidBrush[8];

        //create a list to hold a column of boxes   
        List<Box> boxesLeft = new List<Box>();

        int newboxCounter = 0;

        Random randGen = new Random();
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            ColorArray[0] = new SolidBrush(Color.White);
            ColorArray[1] = new SolidBrush(Color.Blue);
            ColorArray[2] = new SolidBrush(Color.Green);
            ColorArray[3] = new SolidBrush(Color.Purple);
            ColorArray[4] = new SolidBrush(Color.Red);
            ColorArray[5] = new SolidBrush(Color.Orange);
            ColorArray[6] = new SolidBrush(Color.Pink);
            ColorArray[7] = new SolidBrush(Color.Black);
            int xval = randGen.Next(10, 100);
            int cval = randGen.Next(0, 8);
            //TODO - set game start value
            Box b = new Box(xval, 0, 20, 10, cval);
            Box b2 = new Box(xval + 200, 0, 20, 10, cval);
            boxesLeft.Add(b);
            boxesLeft.Add(b2);

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }


        private void gameLoop_Tick(object sender, EventArgs e)
        {
            int xval = randGen.Next(10, 100);
            int cval = randGen.Next(0, 8);
            newboxCounter++;
            //TODO - update location of all boxes (drop down screen)
            foreach (Box b in boxesLeft)
            {
                b.y += b.speed;
            }

            foreach (Box b2 in boxesLeft)
            {
                b2.y += b2.speed;
            }

            if (boxesLeft[0].y > 500)
            {
                boxesLeft.RemoveAt(0); //-remove box if it has gone of screen
            }

            Box box = new Box(xval, 0, 20, 10, cval);
            if (newboxCounter == 2) //-add new box if it is time
            { 
                boxesLeft.Add(box);
                boxesLeft.Add(box2);
                newboxCounter = 0;
            }

            Box box2 = new Box(xval + 200, 0, 20, 10, cval);
            if (newboxCounter == 2) //-add new box if it is time
            {

                newboxCounter = 0;
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw boxes to screen
            foreach (Box b in boxesLeft)
            {
                e.Graphics.FillRectangle(ColorArray[b.color], b.x, b.y, b.size, b.size);
            }

            foreach (Box b2 in boxesLeft)
            {
                e.Graphics.FillRectangle(ColorArray[b2.color], b2.x, b2.y, b2.size, b2.size);
            }
        }
    }
}
