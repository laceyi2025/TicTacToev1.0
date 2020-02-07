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
      //Defining the global variables and global array 
      int turnCounter;
      int numberofTurns = 0;
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

      //Add the value of each row to be used in checking for winner 
      private int sumOfPictureBoxRow(int rowAmount)
      {
         int sum = 0;

         for (int column = 0; column < theBoard.GetLength(1); column++)
         {
            sum += theBoard[rowAmount, column];
         }

         return sum;
      }

      //Add the value of each Column to be used in checking for winner
      private int sumOfPictureBoxColumn(int columnAmount)
      {
         int sum = 0;

         for (int row = 0; row < theBoard.GetLength(1); row++)
         {
            sum += theBoard[row, columnAmount];
         }

         return sum;
      }

      //check for winner based on the sums of above procedures and the sum of each diagonal 
      private bool CheckForWinner(int row, int column)
      {
         if (sumOfPictureBoxRow(row) == 30 || sumOfPictureBoxRow(row) == 300)
         {
            return true;
         }
         else if (sumOfPictureBoxColumn(column) == 30 || sumOfPictureBoxColumn(column) == 300)
         {
            return true;
         }
         else if (theBoard[0, 0] + theBoard[1, 1] + theBoard[2, 2] == 30 || theBoard[0, 0] + theBoard[1, 1] + theBoard[2, 2] == 300)
         {
            return true;
         }
         else if (theBoard[0, 2] + theBoard[1, 1] + theBoard[2, 0] == 30 || theBoard[0, 2] + theBoard[1, 1] + theBoard[2, 0] == 300)
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      //set the value of each turn or letter to 10 or 100
      private int SetValue()
      {
         return (turnCounter == 0) ? 10 : 100;
      }

      // set the turn count for each player
      private int NextPlayer()
      {
         return (turnCounter == 0) ? 1 : 0;
      }

      // announce who won based on whose turn it was
      private string AnnounceWinner()
      {
         return (turnCounter == 0) ? "X is the WINNER!!!!!!" : "O is the WINNER!!!!!!";
      }

      //extract row and column of each clicked button and call all procedures made to make the game check for winners and change players if no winner is found
      private void ButtonClicked(object sender, EventArgs e)
      {
         //Cast object 
         PictureBox xOrOButton = (PictureBox)sender;

         int row = int.Parse(xOrOButton.Name.Substring(4, 1));
         int column = int.Parse(xOrOButton.Name.Substring(5, 1));

         xOrOButton.Image = SetImage();
         theBoard[row, column] = SetValue();
         xOrOButton.Enabled = false;

         if (CheckForWinner(row, column))
         {
            MessageBox.Show(AnnounceWinner());
            MassPitcureBoxEnableorDisable(false);
         }
         //Show that there was no winner
         else if (numberofTurns == 8)
         {
            MessageBox.Show("There was a DRAW!!!!!!");
         }
         else
         {
            turnCounter = NextPlayer();
            numberofTurns++;
         }
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

      //reset the array when game is reset
      private void FillWithZeros()
      {
         for (int row = 0; row < theBoard.GetLength(0); row++)
         {
            for (int column = 0; column < theBoard.GetLength(1); column++)
            {
               theBoard[row, column] = 0;
            }
         }
      }

      //upon reset button click reset the whole bpoard with blank picture, enabled buttons, and a reset array
      private void btnReset_Click(object sender, EventArgs e)
      {
         ResetTurnCounter();
         MassPitcureBoxEnableorDisable(true);
         MassSetPictureImage();
         FillWithZeros();
         numberofTurns = 0;
      }

      private void btnExit_Click(object sender, EventArgs e)
      {
         //Close the program on the click of the exit button
         this.Close();
      }

   }
}
