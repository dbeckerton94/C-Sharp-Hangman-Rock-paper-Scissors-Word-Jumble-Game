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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            MakeLabels();           //Initialise Labels
            label5.Text = "60";     //Label equals 60 for Timer
            timer1.Start();         //Timer Start
            label5.Text = (int.Parse(label5.Text) - 1).ToString(); //Take Value Timer from Label
        }
        string word = "";                       // String is Empty
        List<Label> labels = new List<Label>(); // Make Labels
        int wrong = 0;                          // Wrong equals Zero
        
        //Stickman BuildUp
        enum Driver
        {
            StickOne,    //StickUP
            StickTwo,    //StickLeft
            StickThree,  //StickDown
            Helmet,      //Head
            Torso,       //Body
            Rarm,        // Right Arm
            Larm,        // Left Arm
            Rleg,        // Right Leg
            Lleg,        // Left Leg
            Cross,       // Red Cross
        }
        // Timer Each Tick for Seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = (int.Parse(label5.Text) - 1).ToString(); //lower Values
            int scores; // Declare Scores Value
            scores = 100 + (int.Parse(label5.Text));       // Scores Calculation
            label4.Text = "Score: " + (scores).ToString(); // Label4 equals Score Value
            progressBar1.Value++;                         // Progress Value Increases
            scores++;                                     // Score Value Increases 

            if (progressBar1.Value == 60) // If ProgressBar equals 60
            {
                timer1.Stop(); //Stop timer
                string MessageBoxTitle = "Game Setting"; // Display MessageBox with Word Answer
                string MessageBoxContent = "Sorry you ran out of time, Do you want to try again?, the word was:  " + word;

                // YES or NO options 
                DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) // IF YES Selected
                {
                    Form1 sistema = new Form1(); //Restarted Form1
                    sistema.ShowDialog();
                    this.Close();
                }
                // NO Option
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit(); // Application Exit
                }
              }
            }



            // Print Driver Body
            void PrintDriver(Driver body)
        {
            Graphics s = panel1.CreateGraphics();                         //Print on Panel1
            Pen p = new Pen(Color.Black, 2);                              // P equals Black
            Pen r = new Pen(Color.Red, 4);                                // R equals Red
            if (body == Driver.StickOne)                                  // Corrospond to Driver
                s.DrawLine(p, new Point(180, 226), new Point(180, 6));    // DrawLine Stick One
            else if (body == Driver.StickTwo)                             // DrawLine Stick Two
                s.DrawLine(p, new Point(180, 10), new Point(85, 10));     // Coordinates
            else if (body == Driver.StickThree)                           // DrawLine Stick Three
                s.DrawLine(p, new Point(90, 10), new Point(90, 50));      //Coordinates 

            else if (body == Driver.Helmet)                               //Draw Driver Helmet
                s.DrawEllipse(p, 68, 50, 45, 45);                         //Eclipse Value Head, Circle
            else if (body == Driver.Cross)                                //Red Cross Declare
            {
                s.DrawLine(r, new Point(68, 58), new Point(113, 81));    // Coordinates Cross
                s.DrawLine(r, new Point(68, 80), new Point(113, 58));    // Coordinates Cross
            }

            else if (body == Driver.Torso)                              //Draw Torso
                s.DrawLine(p, new Point(89, 95), new Point(89, 160));   //Torso Coordinates
            else if (body == Driver.Larm)                               //Draw Left Arm
                s.DrawLine(p, new Point(89, 105), new Point(50, 150));  //Left Coordinates
            else if (body == Driver.Rarm)                               //Draw Right Arm
                s.DrawLine(p, new Point(89, 105), new Point(130, 150)); //Right Arm Coordinates 
            else if (body == Driver.Lleg)                               //Left Leg Draw
                s.DrawLine(p, new Point(89, 155), new Point(70, 210));  //Coordiantes Left Leg
            else if (body == Driver.Rleg)                               //Draw Right Leg
                s.DrawLine(p, new Point(89, 155), new Point(110, 210)); //Right Leg Coordinates
             }
          void MakeLabels() //Make Labels
           {
            word = phrase();                        //Word equals Phrase
            char[] chars = word.ToCharArray();     //convert String to each characters
            int gap = 150 / chars.Length;          //Gap between each Letter
            for (int x = 0; x < chars.Length; x++) // Declaring Length
            {
                labels.Add(new Label());                               //Make Labels
                labels[x].Location = new Point((x * gap) + 10, 80);    //Location of Labels
                labels[x].Text = "__";                                 //Underscore for each letter
                labels[x].Parent = groupBox2;                          //Inside GroupBox
                labels[x].BringToFront();                              //Bring to Front of Form
                labels[x].CreateControl();                             //ControlForm
             }
                label1.Text = "word length: " + (chars.Length).ToString();  // Word Length
             }
                Random r = new Random(); //Create Random
                private string phrase() //String Phrase 
            
            {
            String[] WordSelect = File.ReadAllLines("myfilename.txt");     //File Location For myString
            return WordSelect[r.Next(WordSelect.Length)];
            
  }
            //Button to Answer Word
            private void button1_Click(object sender, EventArgs e)
            {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))          //If Contains Characters
            {
                MessageBox.Show("TextBox is empty");                    //Messagebox
            }
            else
            {
             char letter = textBox1.Text.ToLower().ToCharArray()[0];   // Convert To Lower
               if (!char.IsLetter(letter))                             // If Contains Letters
                {
                 // Print Message Box
                 MessageBox.Show("Please submit only letters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
                }
                if (word.Contains(letter)) //If Contains Correct Letter
                {
                    char[] letters = word.ToCharArray();       //String to Characters
                    for (int x = 0; x < letters.Length; x++)  //Length of Word
                    {
                        if (letters[x] == letter)                //if letter is in letter choice
                            labels[x].Text = letter.ToString();  //Letter to string
                    }
                     foreach (Label w in labels)       // For each Character
                      if (w.Text == "_") return;       // For each Character print "_"
                       MessageBox.Show("You Have guessed Correctly", "Winner"); //Print MessageBox
                }
                else
                {
                    label2.Text += " " + letter.ToString() + "/"; //If Letter Wrong Write Letter and /
                    PrintDriver((Driver)wrong);                   //Print Driver as Letter Wrong
                    wrong++;                                      // Wrong Value Increase
                }
                   if (wrong == 10) //If wrong 10 times
                {
                    //MessageBox Show Correct Answer
                    timer1.Stop();
                    string MessageBoxTitle = "Game Setting"; 
                    string MessageBoxContent = "Sorry you didnt make it, Do you want to try again?, the word was:" + word;
                    //MessageBox YES/NO Option
                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                    //If YES SELCECTED
                    if (dialogResult == DialogResult.Yes)
                    {
                        Application.Restart(); // Application restart
                    }
                    //If NO SELECTED
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Hide();
                        Form3 sistema = new Form3(); // Return to Form3
                        sistema.ShowDialog();
                        this.Close();
                    }
                }
            }
        }
        // Button to Select Correct Answer
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == word) // IF word is Correct
            {
              MessageBox.Show("You Have Won"); //MessageBox You Win
              timer1.Stop();
                this.Hide();
              Form3 sistema = new Form3();    //Return to MainForm
              sistema.ShowDialog();
              this.Close(); 
            }
            //Else Incorrect Answer
            else
            {
             //MessageBox Show Correct Word
             MessageBox.Show("You Have Submitted the Incorrect Answer?, the word was: " + word);
             Application.Restart(); // Application Restart
            }
        }

        //Back Button to Form3
        private void button3_Click(object sender, EventArgs e)
         {
           timer1.Stop(); //Stops Timer
           this.Hide();   // Hides Form1
           Form3 sistema = new Form3(); //Takes you to Form3
           sistema.ShowDialog();
           this.Close();
        }

        
        }

    }




    


