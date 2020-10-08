using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        //Button to Hang Man Game, Hides Homepage and in exchange opens Form1
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 sistema = new Form1();
            sistema.ShowDialog();
            this.Close();
        }

        //Button to Word Conundrum Game, Hides Homepage and in exchange opens Form2
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 sistema = new Form2();
            sistema.ShowDialog();
            this.Close();
        }

        //Button to Dry,Wet,Soft Game, Hides Homepage and in exchange opens Form2
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 sistema = new Form4();
            sistema.ShowDialog();
            this.Close();
        }

        //Button to Gracefully Exit Program
        private void button4_Click(object sender, EventArgs e)
        {
            var instance = new Class2();
            instance.ExitGame();
        }


        //Text Box for User to input his/her name which then Prints on Label6
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox1.Text;
        }

        //Text Box for User to input his/her race team which then Prints on label 8
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label8.Text = textBox2.Text;
        }

        //Settings Button to Open Textfile, Giving Access to change words for games
        private void button5_Click(object sender, EventArgs e)
        {
            var instance = new Class1();
            instance.ChangeWords();
        }
        class Class1
        {

            public void ChangeWords()
            {

                System.Diagnostics.Process.Start(@"myfilename.txt");
            }
 }
        class Class2
        {

            public void ExitGame()
            {
                Application.Exit();
             }
        }
    }
}