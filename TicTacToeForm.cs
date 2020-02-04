using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToev1._0
{

   /*
    * Isaiah Lacey
    * 1-21-20
    * Tic Tac Toe
    * 
    */

   public partial class TicTacToeForm : Form
   {

      int turnCounter;
    


      public TicTacToeForm()
      {
         InitializeComponent();
      }
      
      private void ButtonClicked(object sender, EventArgs e)
      {
         //Cast object 
         PictureBox xOrOButton = (PictureBox)sender;

         //Decide which player's (X or O) turn it is. 
         if (turnCounter == 0)
         {
            xOrOButton.Image = Resource1.x2;
            
            turnCounter++;
         }
         else
         {
            xOrOButton.Image = Resource1.o4;
            turnCounter--;
         }

         //Disable button upon getting clicked so no change can occur
         xOrOButton.Enabled = false;

         

      }

      private void btnReset_Click(object sender, EventArgs e)
      {
         //restting the turn to begginning 
         turnCounter = 0;

       

         //clearing the X's and O's
         grid20.Image = null;
         grid21.Image = null;
         grid22.Image = null;
         grid10.Image = null;
         grid11.Image = null;
         grid12.Image = null;
         grid00.Image = null;
         grid01.Image = null;
         grid02.Image = null;

         //Re enabling the picture boxes 
         grid20.Enabled = true;
         grid21.Enabled = true;
         grid22.Enabled = true;
         grid10.Enabled = true;
         grid11.Enabled = true;
         grid12.Enabled = true;
         grid00.Enabled = true;
         grid01.Enabled = true;
         grid02.Enabled = true;


      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         //Close the program on the click of the exit button
         this.Close();
      }

   }
}
