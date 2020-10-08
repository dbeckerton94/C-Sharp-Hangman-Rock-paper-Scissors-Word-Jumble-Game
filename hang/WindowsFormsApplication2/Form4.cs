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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label12.Text = "60"; // Label for timer, Set to 60 Seconds
            timer1.Tick += new EventHandler(timer1_Tick); // Timer Tick Call Method
            timer1.Interval = (1000) * (1);              // Timer 1 Second Per Tick
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer
         }
        
         //Time Tick Method
        private void timer1_Tick(object sender, EventArgs e)
        {
        label12.Text = (int.Parse(label12.Text) - 1).ToString(); // Takes One for Each Tick Link to 60 Seconds
        progressBar1.Value++; //Adds Value to Progress Bar

        //IF Statement for progress bar reaching value of 60
        if (progressBar1.Value == 60)
        {
          timer1.Stop();// Stops Timer
          string MessageBoxTitle = "Game Setting";// Displays Message Box with two user options YES/NO
          string MessageBoxContent = "You Have no time left Sorry! Do want to try again?";
          DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
       
        // IF Yes, it will restart Game
        if (dialogResult == DialogResult.Yes)
         {
           Form2 sistema = new Form2();
           sistema.ShowDialog();
           this.Close();
           }
        // IF No it will Close Game
            else if (dialogResult == DialogResult.No)
             {
              Application.Exit();
               }}}
        
        // On Form Load
        public void Form4_Load(object sender, EventArgs e)
        {
            // All Picture Boxs are Invisible 
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
         }
        // Declaring Integer Values
        int Score = 0;
        int Draw = 0;
        int Lost = 0;
        int Total = 0;
        
        // When "WET" Button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
         // PictureBox5 Changes to TRUE
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        //Selects a Random Number
            Random random = new Random();
        // Creates Range Length of Random value (1-3)
            int randomNumber = random.Next(1, 4);

        //If number is One (WIN)
            if (randomNumber == 1)
            {
                pictureBox5.Visible = true; // Becomes Visible
                Score++; // Score Value Increases
                Total++; // Total Value Increases
                label4.Text = (Score).ToString(); // Score Prints to Label4
                label9.Text = (Total).ToString(); // Total Prints to Label9
            }
        //If number is Two (DRAW)
            else if (randomNumber == 2)
            {
                pictureBox3.Visible = true; // Becomes Visible 
                Draw++; // Draw Value Increases
                label6.Text = (Draw).ToString(); // Draw Prints to Label6
            }
        //If number is Three (LOSE)
            else if (randomNumber == 3)
            {
                pictureBox1.Visible = true; // Becomes Visible
                Lost++; // Lost value Increases
                Total--; // Total Value Decreases
                label5.Text = (Lost).ToString();  // Lost Prints to Label5
                label9.Text = (Total).ToString(); // Total Prints to Label9
            }
        }

        // When DRY Button is Pressed
        private void button1_Click(object sender, EventArgs e)
        {
            //PictureBox2 Becomes Visible
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            //Selects a Random Number
            Random random = new Random();
            // Creates Range Length of Random value (1-3)
            int randomNumber = random.Next(1, 4);

            //IF number is One
            if (randomNumber == 1)
            {
                pictureBox5.Visible = true; // Becomes Visible
                Lost++; // Value Increases
                Total--; // Value Decreases
                label5.Text = (Lost).ToString(); //Lost Printed to label5
                label9.Text = (Total).ToString(); //Total Printed to label9
            }

        //IF number is Two
            else if (randomNumber == 2)
            {
                pictureBox3.Visible = true; // Becomes Visible
                Score++; //Value Increases
                Total++; //Value Increases
                label4.Text = (Score).ToString(); //Score Printed to label4
                label9.Text = (Total).ToString(); //Total printed to label9
            }

        //IF number is Three
            else if (randomNumber == 3)
            {
                pictureBox1.Visible = true; //Becomes Visible
                Draw++; //Value Increases 
                label6.Text = (Draw).ToString(); //Draw Printed to label6
            }
        }
        

        // When SOFT Button is Pressed
        private void button3_Click(object sender, EventArgs e)
        {
        //PictureBox5 Becomes Visible
            pictureBox6.Visible = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            
            //Creates Random Number
            Random random = new Random();
            //Random Number between 1-3
            int randomNumber = random.Next(1, 4);

        //IF number is One
         if (randomNumber == 1)
           {
            pictureBox5.Visible = true; //Becomes Visible
            Draw++; //Value increases
            label6.Text = (Draw).ToString(); //Draw printed on label6
           }
        //IF number is Two
            else if (randomNumber == 2)
            {
              pictureBox3.Visible = true; //Becomes Visible
              Lost++; //Value Increases
              Total--; //Value Decreases
              label5.Text = (Lost).ToString(); // Lost printed to label5
              label9.Text = (Total).ToString(); // Total printed to label9
            }
        //IF number is Three
            else if (randomNumber == 3)
            {
              pictureBox1.Visible = true; //Becomes Visible 
              Score++; //Value Increases
              Total++; //Value Increases
              label4.Text = (Score).ToString(); // Score Printed to label4
              label9.Text = (Total).ToString(); // Total printed to label9
            }
}

        //Back Button, Stops Timer, Transports user to Form3
        private void button5_Click(object sender, EventArgs e)
        {
          timer1.Stop();
          this.Hide();
          Form3 sistema = new Form3();
          sistema.ShowDialog();
          this.Close();
        }
        //Game Rules Button that displays MessageBox
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Tutorial \n Soft Tyre Beats Dry  \n Wet Tyre Beats Soft \n Dry Tyre Beats Wet");
        }
     }
  }
