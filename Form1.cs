using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


// A. Ansari final summative Jan 2022
// Space Race 2 player game
// fonts, sounds, game concept do not belong to me
namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(250, 330, 10, 30);
        Rectangle player2 = new Rectangle(525, 330, 10, 30);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 50;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        List<Rectangle> asteroids = new List<Rectangle>();
        List<Rectangle> asteroids2 = new List<Rectangle>();
        //List<Rectangle> asteroids3 = new List<Rectangle>();
        //List<Rectangle> asteroids4 = new List<Rectangle>();
        int astroSize = 10;
        List<int> astroSpeed = new List<int>();
        List<int> astroSpeed2 = new List<int>();

        Random randGen = new Random();
        int randValue = 0;

        SolidBrush objectBrush = new SolidBrush(Color.White);

        SoundPlayer movePlayer = new SoundPlayer(Properties.Resources._466556__danieldouch__little_blip);
        SoundPlayer lapPlayer = new SoundPlayer(Properties.Resources._518558__se2001__quick_blip);
        SoundPlayer winPlayer = new SoundPlayer(Properties.Resources._277441__xtrgamr__tones_of_victory);

        public Form1()
        {
            InitializeComponent();
        }

        //lines / borders
        private void Form1_Shown(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen drawPen = new Pen(Color.Red, 10);
            g.Clear(BackColor);
            g.DrawLine(drawPen, 400, 10, 400, 50);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    movePlayer.Play();
                    wDown = true;
                    break;
                case Keys.S:
                    movePlayer.Play();
                    sDown = true;
                    break;
                case Keys.Up:
                    movePlayer.Play();
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    movePlayer.Play();
                    downArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void engine_Tick(object sender, EventArgs e)
        {
            //check for collisions

            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (player1.IntersectsWith(asteroids[i]))
                {
                    player1.Y = this.Height - player1.Height;

                }
            }

            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (player2.IntersectsWith(asteroids[i]))
                {
                    player2.Y = this.Height - player2.Height;
                }
            }
            for (int i = 0; i < asteroids2.Count(); i++)
            {
                if (player1.IntersectsWith(asteroids2[i]))
                {
                    player1.Y = this.Height - player1.Height;

                }
            }

            for (int i = 0; i < asteroids2.Count(); i++)
            {
                if (player2.IntersectsWith(asteroids2[i]))
                {
                    player2.Y = this.Height - player2.Height;
                }
            }
            //score points and return player to bottom
            if (player1.Y < 0)
            {
                lapPlayer.Play();
                player1Score++;
                player1.Y = this.Height - player1.Height;
            }

            if (player2.Y < 0)
            {
                lapPlayer.Play();
                player2Score++;
                player2.Y = this.Height - player2.Height;
            }
            //move player 1 
            if (wDown == true) //&& player1.Y > 0
            {
                
                player1.Y -= playerSpeed;
            }
            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                
                player1.Y += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true) //&& player2.Y > 0)
            {
                
                player2.Y -= playerSpeed;
            }
            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                
                player2.Y += playerSpeed;
            }

            

            p1ScoreLabel.Text = player1Score + "";
            p2ScoreLabel.Text = player2Score + "";

            // check score and stop game if either player is at 3 
            if (player1Score == 3)
            {
                winPlayer.Play();
                engine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                playAgain.Visible = true;
                exitButton.Visible = true;
                
            }
            else if (player2Score == 3)
            {
                winPlayer.Play();
                engine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                playAgain.Visible = true;
                exitButton.Visible = true;

            }

            //asteroids
            ///Generate Asteroid
            randValue = randGen.Next(0, 101);

            if (randValue < 30)
            {
                int y = randGen.Next(30, 300);
                asteroids.Add(new Rectangle(10, y, astroSize, astroSize));
                astroSpeed.Add(randGen.Next(2, 17));

                int y2 = randGen.Next(30, 300);         
                asteroids2.Add(new Rectangle(this.Width - 20, y2, astroSize, astroSize));
                astroSpeed2.Add(randGen.Next(2, 17));

                //asteroids3.Add(new Rectangle(this.Width /2, y2, astroSize, astroSize));
                //asteroids4.Add(new Rectangle(this.Width, y2, astroSize, astroSize));
            }

            // move asteroids
            for (int i = 0; i < asteroids.Count(); i++)
            {
                //find the new postion of x based on speed  
                int x = asteroids[i].X + astroSpeed[i];

                //replace the rectangle in the list with updated one using new y 
                asteroids[i] = new Rectangle(x, asteroids[i].Y, astroSize, astroSize);
            }

            for (int i = 0; i < asteroids2.Count(); i++)
            {
                //find the new postion of x based on speed  
                int x2 = asteroids2[i].X - astroSpeed2[i];

                //replace the rectangle in the list with updated one using new y 
                asteroids2[i] = new Rectangle(x2, asteroids2[i].Y, astroSize, astroSize);
            }

            //remove offscreen objects
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].X > this.Width - 20)
                {
                    asteroids.RemoveAt(i);
                    astroSpeed.RemoveAt(i);
                }
            }
            for (int i = 0; i < asteroids2.Count(); i++)
            {
                if (asteroids2[i].X > this.Width + 20)
                {
                    asteroids2.RemoveAt(i);
                    astroSpeed2.RemoveAt(i);
                }
            }
            //for (int i = 0; i < asteroids.Count(); i++)
            //{
            //    if (asteroids2[i].X > this.Width) // - 50)***
            //    {
            //        asteroids2.RemoveAt(i);
            //    }
            //}
            //for (int i = 0; i < asteroids.Count(); i++)
            //{
            //    if (asteroids3[i].X < 0) // - 50)***
            //    {
            //        asteroids3.RemoveAt(i);
            //    }
            //}
            //for (int i = 0; i < asteroids.Count(); i++)
            //{
            //    if (asteroids4[i].X < this.Width) // - 50)***
            //    {
            //        asteroids4.RemoveAt(i);
            //    }
            //}

            Refresh();
        }
        //private void gameEngine()
        //{
        //    engine.Enabled = true;

        //}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(objectBrush, player1);
            e.Graphics.FillRectangle(objectBrush, player2);

            for (int i = 0; i < asteroids.Count(); i++)
            {
                e.Graphics.FillRectangle(objectBrush, asteroids[i]);
            }

            for (int i = 0; i < asteroids2.Count(); i++)
            {
                e.Graphics.FillRectangle(objectBrush, asteroids2[i]);
            }
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            engine.Enabled = true;
            //engine.Start();
            startButton.Visible = false;
            winLabel.Visible = false;
            this.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void startGame_Click(object sender, EventArgs e)
        //{
        //    startGame.Visible = false;
        //    engine.Enabled = true;

        //}
    }
}
