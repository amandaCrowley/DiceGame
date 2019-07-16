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
    /*Created by Amanda Crowley 
     * 29th Setptember 2015
     * Based on previously demonstrated input box in lecture 6 INFT2012 by Simon
     */
     
    public partial class frmInputBox : Form
    {
        public frmInputBox() //Constructor
        {
            InitializeComponent();
        }
        #region property and event handlers
        //sGetName property
        //returns value of the text entered in the textbox
        public string sGetName
        {
            get { return tbxName.Text; }
        }
        
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Close the form by disposing of it
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }
        #endregion
    }// end of class
}// end of namespace
