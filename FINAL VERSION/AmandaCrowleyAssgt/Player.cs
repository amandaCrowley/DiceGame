using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmandaCrowleyAssgt
{
    /*Created by Amanda Crowley
     * Date created: 1st October 2015
     * Player class containing name, win counter and score attributes for each player playing the dice game
     */
    class Player
    {
        #region Private attributes
        public int iMyWinCount = 0;
        private int iMyTotalScore = 0;
        private int iMyRoundScore = 0;
        private string sMyName;
        #endregion

        #region Public properties
        //Name property
        //get returns value sMyName
        //set assigns value to sMyName
        public string sName {
            get { return this.sMyName; }
            set { this.sMyName = value; }
        }

        //Win Counter property
        //get returns value iMyWinCount
        //set assigns value to iMyWinCount
        public int iWinCount
        {
            get { return this.iMyWinCount; }
            set { this.iMyWinCount = value; }
        }

        //Total Score property
        //get returns value iMyTotalScore
        //set assigns value to iMyTotalScore
        public int iTotalScore
        {
            get { return this.iMyTotalScore; }
            set { this.iMyTotalScore = value; }
        }

        //Round Score property
        //get returns value iMyRoundScore
        //set assigns value to iMyRoundScore
        public int iRoundScore
        {
            get { return this.iMyRoundScore; }
            set { this.iMyRoundScore = value; }
        }
        #endregion
    }//end of class
}//end of namespace
