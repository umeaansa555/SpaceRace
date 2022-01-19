﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(150, 300, 10, 30);
        Rectangle player2 = new Rectangle(550, 300, 10, 30);
        
        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 50;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        List<Rectangle> asteroids = new List<Rectangle>();
        List<Rectangle> asteroids2 = new List<Rectangle>();
        int astroSize = 10;
        List<int> astroSpeed = new List<int>();
        Random randGen = new Random();
        int randValue = 0;

        SolidBrush blackBrush = new SolidBrush(Color.Black);
        

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
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
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

            
            //score points and return player to bottom
            if(player1.Y < 0)
            {
                player1Score++;
                player1.Y = this.Height - player1.Height;
            }

            if (player2.Y < 0)
            { 
                player2Score++;
                player2.Y = this.Height - player2.Height;
            }

            p1ScoreLabel.Text = player1Score + "";
            p2ScoreLabel.Text = player2Score + "";

            // check score and stop game if either player is at 3 
            if (player1Score == 3)
            {
                engine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                playAgain.Visible = true;
            }
            else if (player2Score == 3)
            {
                engine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                playAgain.Visible = true;
            }

            //asteroids (in progress)
            ///check to see if a new ball should be created 
            randValue = randGen.Next(0, 101);

            if (randValue < 50)
            {
                int y = randGen.Next(30, 200);
                asteroids.Add(new Rectangle(10, y, astroSize, astroSize));
                asteroids2.Add(new Rectangle(this.Width/2 + 10, y, astroSize, astroSize));
                astroSpeed.Add(randGen.Next(2, 20));
            }

            // move balls 
            for (int i = 0; i < asteroids.Count(); i++)
            {
                //find the new postion of x based on speed  
                int x = asteroids[i].X + astroSpeed[i];
                int x2 = asteroids2[i].X + astroSpeed[i];
                //replace the rectangle in the list with updated one using new y 
                asteroids[i] = new Rectangle(x, asteroids[i].Y, astroSize, astroSize);
                asteroids2[i] = new Rectangle(x2, asteroids2[i].Y, astroSize, astroSize);
            }

            //check if ball is below play area and remove it if it is 
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].X > this.Width/2 - 20 )
                {
                    asteroids.RemoveAt(i);
                }
                if (asteroids2[i].X > this.Width) // - 50)***
                {
                    asteroids2.RemoveAt(i);
                }
            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blackBrush, player1);
            e.Graphics.FillRectangle(blackBrush, player2);

            for (int i = 0; i < asteroids.Count(); i++)
            {
                e.Graphics.FillRectangle(blackBrush, asteroids[i]);
                e.Graphics.FillRectangle(blackBrush, asteroids2[i]);
            }
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        //private void startGame_Click(object sender, EventArgs e)
        //{
        //    startGame.Visible = false;
        //    engine.Enabled = true;

        //}
    }
}
