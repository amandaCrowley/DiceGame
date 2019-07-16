using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmandaCrowleyAssgt
{
    /* Created by Amanda Crowley
     * 10th September 2015
     * Assignment 1 INFT 2012
     * Main form for the dice game called Six of one. 
     * There are two players(1 human, 1 computer), each of whom is trying to reach an agreed total with up to six dice.
     * The players alternate turns, and each player has a round score, which (possibly) builds up turn by turn.
     * When it’s the human player’s turn, the player chooses how many dice to roll, then rolls those dice all at the same time.
     * The computer strategy regarding how many dice it wants to roll is built into the program.
     */

    public partial class frmGameInterface : Form
    {
        //Instance variables
        private Graphics graPaper; //Used for the picture box where the dice are drawn
        private int iTurn; //Indicates whose turn it is, 0=player and 1=computer. Used as an index when referring to player objects
        private int iRoundNumber = 1; //For display on the form, increments with each new round
        Random r = new Random(); //Used to decide which player will roll first, also used when rolling the dice
        private bool bAddRound = true; //Used to determine if the round number needs to be added to the round label (i.e. when both players have rolled)
        private Player[] players; //Declare an array of player objects

        #region Constructor and onload event
        public frmGameInterface() //Constructor
        {
            InitializeComponent();
            graPaper = pbxDice.CreateGraphics();
            players = new Player[2];  //Set the size of the player array to 2 (0 and 1)

            for (int i = 0; i < players.Length; i++)
                players[i] = new Player(); // Initalises each player object in the array 
        }

        /* Method frmGameInterface_Load (Event handler)
        *  Form load event. After all of the controls have been loaded on the form 
        *  An instance of inputbox class is called to collect the human player's name
        *  The player's name attributes are assigned and the appropriate labels are updated with the collected names
        *  The turn label also displays a message for the user to click the new game button to begin the game
        *  The roll button and DiceCount text box are disabled until the user starts the game in the preferred way
        */
        private void frmGameInterface_Load(object sender, EventArgs e)
        {
            frmInputBox frmCollector = new frmInputBox(); // Define an InputBox and instantiate
            frmCollector.ShowDialog(); //Inputbox pops up for user to enter their name

            if (frmCollector.sGetName == "" || frmCollector.sGetName == null)
                players[0].sName = "Player"; //If the player does not enter a name, name is set to the default
            else
                players[0].sName = frmCollector.sGetName; //Access inputbox sGetName to set the name for the player object
            players[1].sName = "Computer";

            lblP1GamesWon.Text = players[0].sName + ":"; //Updates labels with the human player's chosen name
            lblPlayer1.Text = players[0].sName;

            btnRoll.Enabled = false;

            lblTurn.Text = "Welcome " + players[0].sName + "\r\n\r\nPlease click the new \r\ngame button to begin";
            tbxDiceCount.Visible = false;
        }
        #endregion

        #region Starting methods
        /* Method btnRoll_Click (Event handler)
         * When it is the player's turn they will click the roll button
         * Conducts checks on text boxes
         * Calls startRound method to start the round 
         */
        private void btnRoll_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxFinalScore.Text == "") //Checks that a final score has been entered by the user
                    MessageBox.Show("Please enter the final score that you would like to play to", "Please enter final score!");
                else if (tbxDiceCount.Text == "")   //Checks the user has entered how many dice they would like to roll for the round
                    MessageBox.Show("Please enter the number of dice you would like to roll for this round", "Please enter number of dice to roll!");
                else if (Convert.ToInt32(tbxDiceCount.Text) > 6 || Convert.ToInt32(tbxDiceCount.Text) < 1) //Up to 6 dice can be rolled, checks the user enters an amount between 1 and 6
                    MessageBox.Show("Please enter a number between 1 and 6", "Invalid amount");
                else
                {
                    startRound(Convert.ToInt32(tbxDiceCount.Text));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Only enter numbers please", "Invalid input");
            }
        }

        /* Method startRound
         * Initial point where the round is started for both human(once btnRoll has been clicked) and computer players, calls nessecary methods to complete a single round
         * Creates the int array where the random numbers for each dice is stored
         * Calls startDrawing method to draw the dice squares and dots onto the picture box 
         * Calls calcScore method to Calculate the player's score for the round
         * Calls updateDisplay method to update the form's labels
         * Calls winCheck method to check if a player has won the entire game
         * Calls swapPlayer if no-one has won the game
         */
        private void startRound(int iNumberOfDice)
        {
            string sGameWon = "";
            int[] iDiceArray = new int[iNumberOfDice + 1];
            //Array stores the random numbers for each dice rolled - the size is determined by how many dice the user wants to roll
            //Position 0 is not used, makes more sense as dice values go from 1-6
            for (int i = 1; i < iDiceArray.Length; i++)
                iDiceArray[i] = r.Next(1, 7); //Assigns a random number between 1-6 to the next available position in the array

            startDrawing(iDiceArray); //Draw the dice squares and dots onto the picture box

            players[iTurn].iRoundScore = calcScore(iDiceArray, ref sGameWon);  //Calculate player's score for the round, passes the int array which contains all the numbers rolled for that round and ref parameter is updated if the player wins or loses the game
            players[iTurn].iTotalScore += players[iTurn].iRoundScore; //Adds on round score to the current total

            updateDisplay(); //Updates round number and player score labels
            if (winCheck(ref sGameWon) || sGameWon != "")//Once the score is added, calls method to check if player has won the game, if no-one has won the game the turns are swapped
                endGameMessage(sGameWon);
            else
                swapPlayer();
        }
        #endregion

        # region player methods
        /* Method updateDisplay
         * Updates round, score and total score labels if required
         */
        private void updateDisplay()
        {
            if (bAddRound) //Checks if the round number needs to be added to
            {
                lblRoundNum.Text += "\r\n    " + Convert.ToString(iRoundNumber); //Updates label with current round number
                iRoundNumber++;
                bAddRound = false;
            }
            else
                bAddRound = true;

            if (iTurn == 0) //Checks which player's turn it is and therefore which score label needs to be updated
                lblP1.Text += "\r\n    " + Convert.ToString(players[0].iRoundScore); //Player's score for the round
            else
                lblComp.Text += "\r\n    " + Convert.ToString(players[1].iRoundScore); //Computer's score for the round

            lblTotal.Text = "Total score:        " + players[0].iTotalScore;
            lblTotalComp.Text = "    " + players[1].iTotalScore;
        }

        /* Method calcScore
         * Int array passed in as a parameter contains all the random numbers the player has rolled for that round
         * ref sWon parameter updates the sGameWon string in the startRound method if the game is won or lost by the current player
         * Check how many of each number is stored in the array, then calculate the round or total score
         * Updates special text label and player's winCounter attribute if required
         * Returns the round score
         */
        private int calcScore(int[] iRandomRolled, ref string sWon)
        {
            int iRoundScore = 0;
            int iOneCount = 0, iTwoCount = 0, iThreeCount = 0, iFourCount = 0, iFiveCount = 0, iSixCount = 0;

            for (int i = 1; i < iRandomRolled.Length; i++) //Check how many of each number is stored in the array
            {
                if (iRandomRolled[i] == 1)
                    iOneCount++;
                else if (iRandomRolled[i] == 2)
                    iTwoCount++;
                else if (iRandomRolled[i] == 3)
                    iThreeCount++;
                else if (iRandomRolled[i] == 4)
                    iFourCount++;
                else if (iRandomRolled[i] == 5)
                    iFiveCount++;
                else
                    iSixCount++;
            }

            if (iOneCount == 1)  //If a player rolls a single instance of the number one, the score for the round is 0
                lblSpecial.Text = players[iTurn].sName + " rolled a single 1 \r\nNo score for this round";
            else if (iOneCount == 2)  //If a player rolls 2 instances of the number one, the player's total score is reset to 0
            {
                lblSpecial.Text = "Oh no, Snake's eyes!\r\n" + players[iTurn].sName + "'s total score reset!";
                players[iTurn].iTotalScore = 0;
            }
            else if (iOneCount == 3) //If a player rolls 3 instances of the number one, the player loses the game
            {
                lblSpecial.Text = "  Oh darn, Dead drop. \r\n" + players[iTurn].sName + " lost the game!";
                if (iTurn == 0) //If it was the player's turn, update the computer's win counter and label
                {
                    players[1].iWinCount++;
                    lblP2GamesWon.Text = "Computer: " + players[1].iWinCount;
                }
                else //Otherwise it was the computer's turn so update the player's win counter and label
                {
                    players[0].iWinCount++;
                    lblP1GamesWon.Text = players[0].sName + ":" + players[0].iWinCount;
                }
                sWon = "lost";
            }
            else if (iOneCount >= 4) //If a player rolls 4 instances or more of the number one, the player wins the game
            {
                lblSpecial.Text = "      Horray, Boojum!";
                players[iTurn].iWinCount++;

                lblP1GamesWon.Text = players[0].sName + ":" + players[0].iWinCount;
                lblP2GamesWon.Text = "Computer: " + players[1].iWinCount;
                sWon = "won";
            }
            else if (iOneCount == 0 && iTwoCount > 2 || iThreeCount > 2 || iFourCount > 2 || iFiveCount > 2 || iSixCount > 2) //If a player rolls 0 instances of the number one and 3 or more of the same number then the round score is twice the sum of the numbers rolled
            {
                lblSpecial.Text = "    Well done, a Snaffle!";
                iRoundScore = (iOneCount + iTwoCount * 2 + iThreeCount * 3 + iFourCount * 4 + iFiveCount * 5 + iSixCount * 6) * 2;
            }
            else //In any other case score for the round is the sum of the numbers that were rolled
            {
                lblSpecial.Text = "";
                iRoundScore = iOneCount + iTwoCount * 2 + iThreeCount * 3 + iFourCount * 4 + iFiveCount * 5 + iSixCount * 6;
            }
            return iRoundScore;
        }

        /* Method winCheck
         * ref sWon parameter updates the sGameWon string, in the startRound method, if the game is won by the current player
         * Check if player's total score is equal or greater than the goal score for the game
         * If the game has been won then updates appropriate labels and current player's winCounter attribute
         * Returns bWon boolean. Which == true when the game has been won
         */
        private Boolean winCheck(ref string sGameWon)
        {
            bool bWon = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].iTotalScore >= Convert.ToInt32(tbxFinalScore.Text))  //If the player's score is equal to or greater than the game total that player has won
                {
                    lblSpecial.Text = players[i].sName + " has won!";
                    players[i].iWinCount++;

                    lblP1GamesWon.Text = players[0].sName + ":" + players[0].iWinCount; //Updates player win counter label
                    lblP2GamesWon.Text = "Computer: " + players[1].iWinCount; //Updates computer win counter label
                    sGameWon = "won";
                    bWon = true;
                }
            }
            return bWon;
        }

        /* Method swapPlayer
         * Swaps the current player with the inactive player (e.g. human to computer or vice versa)
         * Changes turn label, and iTurn variable(indicates which is the current player)
         * The roll button is enabled or disabled depending on who is the current player
         * StartRound is called and a message box is displayed if it is now the computer's turn
         */
        private void swapPlayer()
        {
            if (iTurn == 0) //If it was the player's turn, swap to computer.
            {
                iTurn = 1;
                lblTurn.Text = players[iTurn].sName + "'s turn"; //This assigment is repeated in both the if and else sections, if put after these selection statements and iTurn == 0 then it will never be implemented as the startround method is called when it is the computer's turn and the program never gets to the statement after the if/else
                MessageBox.Show("Computer's turn, it is rolling " + computerStrategy() + " dice");
                btnRoll.Enabled = false;
                startRound(computerStrategy());
            }
            else//Otherwise, it was the computer's turn so swap back to the player.
            {
                iTurn = 0;
                lblTurn.Text = players[iTurn].sName + "'s turn";
                btnRoll.Enabled = true;
            }
        }

        /* Method computerStrategy
         * A series of checks based on the current total score. 
         * Used to determine how many dice the computer will roll
         * returns iNumOfDice - the number of dice the computer will roll for this round
         */
        private int computerStrategy()
        {
            int iFinalScore = Convert.ToInt32(tbxFinalScore.Text);

            //5 dice are rolled if the score is above 15% but less than 35% of the final score. e.g. above 15 or below 36 if the final score = 100. Reduce the amount of dice rolled to slightly reduce the 
            //chance of rolling a dead drop or snake eyes. The computer's score is not high enough to warrant rolling less dice. Also still has a chance to roll Boojum for an instant win.
            int iNumOfDice = 5;

            //1 dice is rolled when the computer's total score is less than or equal to 10% from the final score. e.g. 90 and above if the final score = 100. Reduce the number of dice so there is no 
            //chance of rolling snake eyes.
            if (iFinalScore - players[1].iTotalScore <= iFinalScore * 0.1)
                iNumOfDice = 1;
            //Once 75% is reached the computer starts to roll 2 dice. No longer a chance of rolling a dead drop. The computer's score is high enough that it is most likely to only take a few turns to reach the agreed total.
            else if(players[1].iTotalScore > iFinalScore * 0.75)
                iNumOfDice = 2;
            //Once 60% is reached then computer starts to roll 3 dice. There is less chance of getting snake eyes or a dead drop. Waited a little bit before dropping below 4 dice because now there is no chance
            //of rolling an instant win (Boojum). However the score is getting more substantial and the chance of rolling a win with points alone much better, which justifies the drop in number of dice rolled.
            else if (players[1].iTotalScore > iFinalScore * 0.6)
                iNumOfDice = 3;

            //Rolls 4 dice when the player's total is greater than 35% of the total but less than 60% e.g. above 35 and below 61 if the final score = 100. Less chance of getting a score reset and starting again. 
            //Also has a chance to roll a Boojum for an instant win.
            else if (players[1].iTotalScore > iFinalScore * 0.35)
                iNumOfDice = 4;

            //6 dice are rolled if computer's total score is between 0 and 15%, better chance of a good score with more dice. Also score is quite low so it doesn't 
            //matter as much if the score is reset. Also has a chance to roll a Boojum for an instant win.
            else if (players[1].iTotalScore <= iFinalScore * 0.15)
                iNumOfDice = 6;

            //If the human player is less than 10% from the total the computer will also roll all 6 dice, unless the computer's score is very close to winning anyway(in which case it will roll a 1).
            //The chance of loss is extremely high and a winning score may be rolled if 6 dice are rolled. Also has a chance to roll a Boojum for an instant win.
            else if (iFinalScore - players[0].iTotalScore <= iFinalScore * 0.1 && players[1].iTotalScore < iFinalScore * 0.9)
                iNumOfDice = 6;

            return iNumOfDice;
        }

        /* Method restartGame
        * Resets all of the form's nessecary labels, variables and controls
        * Randomly chooses who will start the next round first, updates turn label
        * If it is the computer's turn, call startRound method here
        */
        private void restartGame()
        {
            //Resetting labels, player variables and controls
            iRoundNumber = 1;
            bAddRound = true;
            tbxDiceCount.Visible = true;
            tbxFinalScore.ReadOnly = false;
            lblP1.Text = "";
            lblComp.Text = "";
            lblSpecial.Text = "";
            lblTotal.Text = "Total score:";
            lblTotalComp.Text = "";
            lblRoundNum.Text = "Round:";
            lblNumberOfDice.Text = "How many dice do you wish to roll?";
            for (int i = 0; i < players.Length; i++)
            {
                players[i].iTotalScore = 0;
                players[i].iRoundScore = 0;
            }

            //Choosing next player
            iTurn = r.Next(0, 2); //Whoever starts the game first is randomly chosen. 0 = player, 1 = computer
            lblTurn.Text = players[iTurn].sName + "'s turn"; //Updates the turn label to reflect which player's turn it is
            if (iTurn == 1)
            {
                MessageBox.Show("Computer's turn, it is rolling 6 dice");
                btnRoll.Enabled = false;
                startRound(6); //Computer does not press the roll button, so startRound is called here
            }
            else
                btnRoll.Enabled = true;
        }
        #endregion

        #region drawing methods
        /* Method startDrawing
         * Parameter iDiceArray is the array of random values used to represent the six dice values that have been rolled. 
         * The dice squares on the picture box are cleared each time this method is called. This is because the dice need to be cleared after the previous player has rolled.
         * After the board is cleared of dice dots, six empty dice squares are drawn.
         * Then the dice dots are drawn onto the picture box 3 times, clearing the dice and redrawing the squares as needed. This is to give the appearance that the dice are actually rolling
         * before landing on a final dice face.
         */
        private void startDrawing(int[] iDiceArray)
        {
            for (int iPosition = 1; iPosition <= 6; iPosition++)
            {
                drawShape("clearDice", iPosition, 10, 10); //Clears all 6 dice squares
                drawShape("diceSquare", iPosition, 10, 10); //Draws on 6 empty dice sqaures.
            }

            for (int i = 1; i < iDiceArray.Length; i++) 
            //The number of dice faces that are drawn in depend on how many dice the player has chosen to roll(the length of the iDiceArray).
            //e.g. If they have chosen 3 dice to roll then only 3 dice will have dots drawn into them. The remainder will remain empty squares.
            {
                //Draws on random dice faces twice then the third time the dice dots are drawn the random value stored in the iDiceArray is passed to the diceDots method
                //This is the value that will be used to calculate the score for this round so it appears as though the dice have landed on this face
                diceDots(r.Next(1, 7), i); //sends random value and dice position to the diceDots method. DrawShape is called within the diceDots method to draw on the dice dots.
                slowDown(); //Slows the program so the player can see the dice being "rolled"
                drawShape("clearDice", i, 10, 10);//clears the dice squares

                drawShape("diceSquare", i, 10, 10); //Draws on an empty dice square in the specified position
                diceDots(r.Next(1, 7), i);
                slowDown(); 
                drawShape("clearDice", i, 10, 10); 

                drawShape("diceSquare", i, 10, 10); 
                diceDots(iDiceArray[i], i); //The real random value used to calculate the score for this round is passed in
                slowDown();
                
            }
        }

        /* Method drawDiceDots
         * Parameter iDiceValue is the number that the player has rolled
         * The parameter iPos determines which dice square the dice dot is to be drawn into
         * Call drawShape method to draw the appropriate dice dots which make up a dice face
         */
        private void diceDots(int iDiceValue, int iPos)
        {
            const string sShape = "diceDot";
            //The parameter, iDiceValue, passed in (i.e. the number the player has rolled) is used to determine which dice face to draw 
            //drawShape uses iPos as an argument to determine where the dice dots need to be drawn on the form
            //The next two arguments are the co-ordinates for that dice face in the first position(top left) on the picture box and are changed relative to this position if needed in the drawShape method
            
            switch(iDiceValue){
                case 1:
                    drawShape(sShape, iPos, 40, 40);
                    break;
                case 2:
                    drawShape(sShape, iPos, 20, 40);
                    drawShape(sShape, iPos, 60, 40);
                    break;
                case 3:   
                    drawShape(sShape, iPos, 40, 40);
                    drawShape(sShape, iPos, 20, 20);
                    drawShape(sShape, iPos, 60, 60);
                    break;
                case 4:
                    drawShape(sShape, iPos, 20, 20);
                    drawShape(sShape, iPos, 60, 20);
                    drawShape(sShape, iPos, 20, 60);
                    drawShape(sShape, iPos, 60, 60);
                    break;
                case 5:
                    drawShape(sShape, iPos, 20, 20);
                    drawShape(sShape, iPos, 60, 20);
                    drawShape(sShape, iPos, 40, 40);
                    drawShape(sShape, iPos, 20, 60);
                    drawShape(sShape, iPos, 60, 60);
                    break;
                case 6:
                    drawShape(sShape, iPos, 20, 20);
                    drawShape(sShape, iPos, 60, 20);
                    drawShape(sShape, iPos, 20, 40);
                    drawShape(sShape, iPos, 60, 40);
                    drawShape(sShape, iPos, 20, 60);
                    drawShape(sShape, iPos, 60, 60);
                    break;
            }
        }

        /* Method drawShape
         * Draws one of three different shapes onto the picture box as required. The poisitiong requirements for each of the shapes are the same (draw into one of 6 positions)
         * so the same method is used for all three
         * The parameter sDrawShape determines which shape is drawn onto of the picture box
         * iPosition, refers to which position the shape is to be drawn (1-6)
         * The parameters xCoOrd and yCoOrd are the co-ordinates for that shape in the first position(top-left) in the picture box
         * The x and y co-ordinates change relative to which dice square they need to be drawn into
         * The "clearDice" shape fills in the dice square with a white brush effectively clearing that box.
         * "diceDot" draws the individual dots within each dice face. They are drawn into one of the six squares already drawn on the form.
         * The third "diceSquare" draws on the square border used for the dice.
         */
        private void drawShape(string sDrawShape, int iPosition, int xCoOrd, int yCoOrd)
        {
            SolidBrush brshBlack = new SolidBrush(Color.Black); //Used when drawing on the dice dots
            SolidBrush brshWhite = new SolidBrush(Color.White); //Used to fill in the dice squares
            Pen myPen = new Pen(Color.Black); //Used when drawing the dice square onto the picture box

            //Changes co-ordinates from the default position (number 1 - top left) as needed
            if (iPosition > 1 && iPosition != 4) //positions 2,3,5 and 6 have 90 added to their y co-ordinate
                yCoOrd += 90;
            if (iPosition == 3 || iPosition == 6) //positions 3 and 6 have another 90 added to their y co-ordinate
                yCoOrd += 90;
            if (iPosition > 3) //positions 4,5 and 6 have 90 added to their x co-ordinate, as they're in the next column over
                xCoOrd += 90; 

            switch(sDrawShape){
                case "clearDice":
                    graPaper.FillRectangle(brshWhite, xCoOrd, yCoOrd, 90, 90); //Clear the dice square in the specified position
                    break;
                case "diceDot":
                    graPaper.FillEllipse(brshBlack, xCoOrd, yCoOrd, 10, 10); //Draw a dice dot into a dice square, in the specified position
                    break;
                case "diceSquare":
                    graPaper.DrawRectangle(myPen, xCoOrd, yCoOrd, 70, 70); //Draws a square onto the form, these squares are used to represent 6 dice faces
                    break;
            }
        }

        /* Method slowDown
        * Slows down the application 
        * Used so the player can see the dice faces being drawn onto the form
        * Gives the appearance that the dice are being rolled
        */
        private void slowDown()
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(320);
        }
        #endregion

        #region application helper methods
        /* Method endGameMessage
         * Called when a game has been won or lost
         * Parameter sMsg stores the string either "won" or "lost".
         * A dialog is displayed telling the player of the outcome of the game with the option to play again or close the game.
         * If they choose to play again the game interface is reset by calling restartGame, if the no button is clicked the application closes.
         */
        private void endGameMessage(string sMsg)
        {
            DialogResult dialogResult = MessageBox.Show(players[iTurn].sName + " has " + sMsg + " the game! Do you want to play again?", "Game over!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                restartGame();
            else if (dialogResult == DialogResult.No)
                Application.Exit();
        }

        /* tbxFinalScore_MouseClick method (event handler)
         * Ensures the player cannot change the final score midway through the game.
         */
        private void tbxFinalScore_MouseClick(object sender, MouseEventArgs e)
        {
            //The round number has already been incremented so it checks if iRoundNumber greater than 2 rather than 1.
            //The first part of the expression works when the computer has the first turn (and also for every round after 2). So the player may only change the final score text box
            //before they have rolled for the first time.
            //The next part of the expression works for when the player has the first turn, after they have rolled once they can't change the text box. 
            if (iRoundNumber > 2 || (bAddRound && iRoundNumber == 2))
            {
                tbxFinalScore.ReadOnly = true;
                MessageBox.Show("Sorry! You can only change the final score at the beginning of a new game", "Sorry, you can't change that now");
            }
        }

        /* Method btnNewGame_Click (event handler)
         * Calls restartGame method which clears the form, ready for a new game.
         */
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            restartGame();
        }

        /* Method btnExit_Click (event handler)
         * When the player clicks on the exit button the application exits      
         */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }// end of class
}// end of namespace