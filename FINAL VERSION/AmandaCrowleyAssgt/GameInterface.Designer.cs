namespace AmandaCrowleyAssgt
{
    partial class frmGameInterface
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
            this.lblP2GamesWon = new System.Windows.Forms.Label();
            this.lblP1GamesWon = new System.Windows.Forms.Label();
            this.lblGamesWon = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.tbxFinalScore = new System.Windows.Forms.TextBox();
            this.lblRoundNum = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.pbxDice = new System.Windows.Forms.PictureBox();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.tbxDiceCount = new System.Windows.Forms.TextBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.lblNumberOfDice = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblComp = new System.Windows.Forms.Label();
            this.lblTotalComp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblP2GamesWon
            // 
            this.lblP2GamesWon.AutoSize = true;
            this.lblP2GamesWon.Location = new System.Drawing.Point(117, 461);
            this.lblP2GamesWon.Name = "lblP2GamesWon";
            this.lblP2GamesWon.Size = new System.Drawing.Size(55, 13);
            this.lblP2GamesWon.TabIndex = 40;
            this.lblP2GamesWon.Text = "Computer:";
            // 
            // lblP1GamesWon
            // 
            this.lblP1GamesWon.AutoSize = true;
            this.lblP1GamesWon.Location = new System.Drawing.Point(13, 461);
            this.lblP1GamesWon.Name = "lblP1GamesWon";
            this.lblP1GamesWon.Size = new System.Drawing.Size(39, 13);
            this.lblP1GamesWon.TabIndex = 39;
            this.lblP1GamesWon.Text = "Player:";
            // 
            // lblGamesWon
            // 
            this.lblGamesWon.AutoSize = true;
            this.lblGamesWon.Location = new System.Drawing.Point(13, 435);
            this.lblGamesWon.Name = "lblGamesWon";
            this.lblGamesWon.Size = new System.Drawing.Size(66, 13);
            this.lblGamesWon.TabIndex = 38;
            this.lblGamesWon.Text = "Games won:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(213, 36);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 15);
            this.lblTotal.TabIndex = 37;
            this.lblTotal.Text = "Total score:";
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecial.Location = new System.Drawing.Point(213, 290);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(0, 16);
            this.lblSpecial.TabIndex = 36;
            // 
            // tbxFinalScore
            // 
            this.tbxFinalScore.Location = new System.Drawing.Point(305, 412);
            this.tbxFinalScore.Name = "tbxFinalScore";
            this.tbxFinalScore.Size = new System.Drawing.Size(89, 20);
            this.tbxFinalScore.TabIndex = 34;
            this.tbxFinalScore.Text = "75";
            this.tbxFinalScore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbxFinalScore_MouseClick);
            // 
            // lblRoundNum
            // 
            this.lblRoundNum.AutoSize = true;
            this.lblRoundNum.Location = new System.Drawing.Point(238, 60);
            this.lblRoundNum.Name = "lblRoundNum";
            this.lblRoundNum.Size = new System.Drawing.Size(42, 13);
            this.lblRoundNum.TabIndex = 33;
            this.lblRoundNum.Text = "Round:";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Location = new System.Drawing.Point(342, 15);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(52, 13);
            this.lblPlayer2.TabIndex = 31;
            this.lblPlayer2.Text = "Computer";
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Location = new System.Drawing.Point(287, 15);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(36, 13);
            this.lblPlayer1.TabIndex = 30;
            this.lblPlayer1.Text = "Player";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Location = new System.Drawing.Point(319, 451);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewGame.Location = new System.Drawing.Point(219, 451);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 28;
            this.btnNewGame.Text = "New game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // pbxDice
            // 
            this.pbxDice.BackColor = System.Drawing.Color.White;
            this.pbxDice.Location = new System.Drawing.Point(14, 158);
            this.pbxDice.Name = "pbxDice";
            this.pbxDice.Size = new System.Drawing.Size(189, 274);
            this.pbxDice.TabIndex = 27;
            this.pbxDice.TabStop = false;
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.Location = new System.Drawing.Point(257, 384);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(137, 13);
            this.lblFinalScore.TabIndex = 26;
            this.lblFinalScore.Text = "Playing to the final score of:";
            // 
            // tbxDiceCount
            // 
            this.tbxDiceCount.Location = new System.Drawing.Point(16, 81);
            this.tbxDiceCount.Name = "tbxDiceCount";
            this.tbxDiceCount.Size = new System.Drawing.Size(100, 20);
            this.tbxDiceCount.TabIndex = 25;
            // 
            // btnRoll
            // 
            this.btnRoll.BackColor = System.Drawing.SystemColors.Control;
            this.btnRoll.Location = new System.Drawing.Point(16, 120);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 24;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = false;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // lblNumberOfDice
            // 
            this.lblNumberOfDice.AutoSize = true;
            this.lblNumberOfDice.Location = new System.Drawing.Point(13, 47);
            this.lblNumberOfDice.Name = "lblNumberOfDice";
            this.lblNumberOfDice.Size = new System.Drawing.Size(0, 13);
            this.lblNumberOfDice.TabIndex = 23;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.Location = new System.Drawing.Point(10, 15);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(104, 24);
            this.lblTurn.TabIndex = 22;
            this.lblTurn.Text = "Welcome!";
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Location = new System.Drawing.Point(290, 60);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(0, 13);
            this.lblP1.TabIndex = 41;
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Location = new System.Drawing.Point(345, 60);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(0, 13);
            this.lblComp.TabIndex = 42;
            // 
            // lblTotalComp
            // 
            this.lblTotalComp.AutoSize = true;
            this.lblTotalComp.Location = new System.Drawing.Point(345, 38);
            this.lblTotalComp.Name = "lblTotalComp";
            this.lblTotalComp.Size = new System.Drawing.Size(0, 13);
            this.lblTotalComp.TabIndex = 43;
            // 
            // frmGameInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(419, 479);
            this.Controls.Add(this.lblTotalComp);
            this.Controls.Add(this.lblComp);
            this.Controls.Add(this.lblP1);
            this.Controls.Add(this.lblP2GamesWon);
            this.Controls.Add(this.lblP1GamesWon);
            this.Controls.Add(this.lblGamesWon);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSpecial);
            this.Controls.Add(this.tbxFinalScore);
            this.Controls.Add(this.lblRoundNum);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblFinalScore);
            this.Controls.Add(this.tbxDiceCount);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.lblNumberOfDice);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.pbxDice);
            this.Name = "frmGameInterface";
            this.Text = "Six of one";
            this.Load += new System.EventHandler(this.frmGameInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblP2GamesWon;
        private System.Windows.Forms.Label lblP1GamesWon;
        private System.Windows.Forms.Label lblGamesWon;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.TextBox tbxFinalScore;
        private System.Windows.Forms.Label lblRoundNum;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.PictureBox pbxDice;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.TextBox tbxDiceCount;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Label lblNumberOfDice;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblTotalComp;
    }
}