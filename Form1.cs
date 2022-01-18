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
        Rectangle player1 = new Rectangle(150, 300, 10, 60);
        Rectangle player2 = new Rectangle(350, 300, 10, 60);
        
        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 50;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        List<Rectangle> asteroids = new List<Rectangle>();
        Random randGen = new Random();
        int randValue = 0;

        SolidBrush blackBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
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

            
            //score points
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
            }
            else if (player2Score == 3)
            {
                engine.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blackBrush, player1);
            e.Graphics.FillRectangle(blackBrush, player2);

        }
    }
}
