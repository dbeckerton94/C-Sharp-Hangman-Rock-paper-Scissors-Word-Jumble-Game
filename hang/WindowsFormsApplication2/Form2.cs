using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
          //Declare Values
          InitializeComponent();
          label5.Text = "60";// Timer Label Set to 60 Seconds
          timer1.Start();    // Timer Start
          word = phrase();   // String Declare 
          int scores = 0;    // INT score Declare
          scores = 40 + (int.Parse(label5.Text)); //Score Calculation to Label 
          label8.Text = (scores).ToString();      //Score Printed on label8
          var mixup = new StringBuilder(word);   //Jumble Word Selected
          int length = mixup.Length;             //Working out Length
          var random = new Random();             //Randomise Variable
           
         //Jumble Calcualtion
         for (int i = length - 1; i > 0; i--) 
            {
              int m = random.Next(i); 
              char temp = mixup[m];
              mixup[m] = mixup[i];
              mixup[i] = temp;
            }
        //label to Produce Mixed Up word
           label3.Text += mixup + " ";
           label4.Text += length + " ";
           }
          Random r = new Random(); //Random Selection
          string word = "";       // String is Empty

        private string phrase()
        {
          String[] myString = File.ReadAllLines("myfilename.txt"); //Locates File Location
          return myString[r.Next(myString.Length)];  //Returns String and Length
        }
        //Submit Answer Button
        private void button2_Click(object sender, EventArgs e)
        {
          char letter = textBox1.Text.ToLower().ToCharArray()[0]; //Convert Text to Lower Case
          //IF statement to Check Characters
            if (!char.IsLetter(letter)) //Select only Letters
            {
                // MessageBox Error
                MessageBox.Show("Please submit only letters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Submit Answer Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text)) //If any characters are Inputted
            {
                MessageBox.Show("Please Input an Answer!"); //MessageBox Show
            }
            else
            {
                char letter = textBox1.Text.ToLower().ToCharArray()[0]; //Convert Characters to Lower
                if (!char.IsLetter(letter))
                {
                    MessageBox.Show("Please submit only letters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                {
                    if (textBox1.Text == word) //If textbox equals the correct word
                    {
                        int score; // Score Increases
                        timer1.Stop();
                        score = 100 + (int.Parse(label5.Text)) ; //Score Calculation
                        MessageBox.Show("Your score is " + score); // MessageBox to show Score
                        this.Hide(); 
                        Form3 sistema = new Form3(); // Return to MainForm
                        sistema.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //Else Incorrect Statement , Show MessageBox and Correct Word
                        MessageBox.Show("You Have Submitted the Incorrect Answer?, the word was: " + word); 
                        Application.Restart(); // Application Restart
                    }
                 }
              }
            }

           private void timer1_Tick(object sender, EventArgs e) // Each Timer Tick
           {
            label5.Text = (int.Parse(label5.Text) - 1).ToString(); //Lower Value
            int scores;                               // Declare Score Value
            scores = 100 + (int.Parse(label5.Text)); // Score Calculation
            label8.Text = (scores).ToString();       // Label8 to Scores
            progressBar1.Value++;                    // Increase ProgressBar Value
            scores++;                                // Increase Score Value

            if (progressBar1.Value == 60) // When Progress Bar value hits 60
            {
                timer1.Stop(); //Stop Timer
                string MessageBoxTitle = "Game Setting"; // Display MessageBox with YES/NO option
                string MessageBoxContent = "Sorry you ran out of time, Do you want to try again?, the word was:  " + word;

                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form2 sistema = new Form2(); //Restarts Form on Form2
                    sistema.ShowDialog();
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();          // Closes Application

                }
              }
           }
        //Back Button to MainMenu
          private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();                //Stops Timer
            this.Hide();
            Form3 sistema = new Form3(); //Opens Form3
            sistema.ShowDialog();
            this.Close();
        }
      }
    }
    



      

        
    
 


        
    

      


       

       


        



       
    

