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
         picChoice1.Image = null;
         picChoice2.Image = null;
         picChoice3.Image = null;
         picChoice4.Image = null;
         picChoice5.Image = null;
         picChoice6.Image = null;
         picChoice7.Image = null;
         picChoice8.Image = null;
         picChoice9.Image = null;

         //Re enabling the picture boxes 
         picChoice1.Enabled = true;
         picChoice2.Enabled = true;
         picChoice3.Enabled = true;
         picChoice4.Enabled = true;
         picChoice5.Enabled = true;
         picChoice6.Enabled = true;
         picChoice7.Enabled = true;
         picChoice8.Enabled = true;
         picChoice9.Enabled = true;


      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         //Close the program on the click of the exit button
         this.Close();
      }

   }
}
