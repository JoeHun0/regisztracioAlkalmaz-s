using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxHobby.Items.Add("Úszás");
            listBoxHobby.Items.Add("Horgászat");
            listBoxHobby.Items.Add("Futás");

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string nev = textBoxName.Text;
            DateTime time = dateTimePicker.Value;
            string nem = "nem tudja/nem válaszol";
            if (radioButtonFemale.Checked == true) {
                nem = "nő";
            }
            else
            {
                nem = "férfi";
            }
            string hobbi = listBoxHobby.Text;
            try
            {
                // NullReferenceException
                string kivalasztottListBoxElem = listBoxHobby.SelectedItem.ToString();
            }
            catch (NullReferenceException nullRefEx)
            {

                Console.WriteLine( nullRefEx.Message);
            }
            string itemToS;
            try
            {
                string kiFile = @"C:\Users\Diak\Desktop\ki.txt";

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (object item in listBoxHobby.Items)
                {
                    sb.Append(item.ToString());
                    sb.Append(" ");
                }
                itemToS = sb.ToString();
                string[] createText = { nev,nem,hobbi, itemToS };
            File.WriteAllLines(kiFile, createText, Encoding.UTF8);


            string[] readText = File.ReadAllLines(kiFile, Encoding.UTF8);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("Nem található a könyvtár: " + dirEx.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string newHobby = textBoxNewHobby.Text;
            listBoxHobby.Items.Add(newHobby);
            System.Windows.Forms.MessageBox.Show(newHobby);
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            
        
        }

        private void listBoxHobby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNewHobby_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click_1(object sender, EventArgs e)
        {
            string beFile;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                beFile = file.FileName;
            }
        }
    }
}
