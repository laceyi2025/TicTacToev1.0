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

      int[,] theBoard = new int[3, 3];


      public TicTacToeForm()
      {
         InitializeComponent();
      }

      //Set x or o based on whose turn it is
      private Bitmap SetImage()
      {
         return (turnCounter == 0) ? Resource1.x2 : Resource1.o4;
      }


      private void ButtonClicked(object sender, EventArgs e)
      {
         //Cast object 
         PictureBox xOrOButton = (PictureBox)sender;

         int row = int.Parse(xOrOButton.Name.Substring(4, 1));
         int column = int.Parse(xOrOButton.Name.Substring(5, 1));

         

         //Decide which player's (X or O) turn it is. 
         if (turnCounter == 0)
         {
            xOrOButton.Image = SetImage();

            theBoard[row, column] = 10;
         }
         else
         {
            xOrOButton.Image = SetImage();

            theBoard[row, column] = 100;

         
         }

         xOrOButton.Enabled = false;
      }

      //reset turn back to player 1 (x)
      private void ResetTurnCounter()
      {
         turnCounter = 0;
      }

      //mass enable or disable the picture box when clicked or when reset
      private void MassPitcureBoxEnableorDisable(bool howToSet)
      {
         foreach (Control controlUsed in Controls)
         {
            if (controlUsed is PictureBox) controlUsed.Enabled = howToSet;
         }
      }

      //clearing images when game reset
      private void MassSetPictureImage()
      {
         foreach (Control controlUsed in Controls)
         {
            if (controlUsed is PictureBox)
            {
               ((PictureBox)controlUsed).Image = null;
            }
         }
      }
      private void btnReset_Click(object sender, EventArgs e)
      {
         ResetTurnCounter();
         MassPitcureBoxEnableorDisable(true);
         MassSetPictureImage();
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         //Close the program on the click of the exit button
         this.Close();
      }

   }
}
