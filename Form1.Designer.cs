
namespace SpaceRace
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.engine = new System.Windows.Forms.Timer(this.components);
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.playAgain = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // engine
            // 
            this.engine.Tick += new System.EventHandler(this.engine_Tick);
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("8-bit Operator+", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.p1ScoreLabel.Location = new System.Drawing.Point(225, 374);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(62, 67);
            this.p1ScoreLabel.TabIndex = 0;
            this.p1ScoreLabel.Text = "0";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("8-bit Operator+", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.p2ScoreLabel.Location = new System.Drawing.Point(502, 374);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(62, 67);
            this.p2ScoreLabel.TabIndex = 1;
            this.p2ScoreLabel.Text = "0";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLabel
            // 
            this.winLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("8-bit Operator+", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.winLabel.Location = new System.Drawing.Point(12, 136);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(776, 156);
            this.winLabel.TabIndex = 2;
            this.winLabel.Text = "Space Race";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playAgain
            // 
            this.playAgain.AutoSize = true;
            this.playAgain.BackColor = System.Drawing.Color.Red;
            this.playAgain.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.playAgain.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playAgain.Font = new System.Drawing.Font("8-bit Operator+", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgain.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.playAgain.Location = new System.Drawing.Point(12, 394);
            this.playAgain.Name = "playAgain";
            this.playAgain.Size = new System.Drawing.Size(168, 47);
            this.playAgain.TabIndex = 3;
            this.playAgain.Text = " Play Again";
            this.playAgain.UseVisualStyleBackColor = false;
            this.playAgain.Visible = false;
            this.playAgain.Click += new System.EventHandler(this.playAgain_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Red;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Font = new System.Drawing.Font("8-bit Operator+", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.startButton.Location = new System.Drawing.Point(312, 242);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(168, 47);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.playAgain);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.winLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Race";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer engine;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button playAgain;
        private System.Windows.Forms.Button startButton;
    }
}

