using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine
{
    public partial class Form1 : Form
    {
        Button randomButton;
        Button randomButton2;
        Button randomButton3;
        Button randomButton4;
        Button randomButton5;
        Button randomButton6;
        int brojac = 0;
        public Form1()
        {
            InitializeComponent();
            Random randomGenerator = new Random();
            randomButton = this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();
            randomButton2= this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();
            randomButton3 = this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();
            randomButton4 = this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();
            randomButton5 = this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();
            randomButton6 = this.Controls.OfType<Button>().OrderBy(x => randomGenerator.Next()).FirstOrDefault();


            // Dodijeljivanje slučajne vrijednosti svojstvu Tag za slučajno odabrani gumb
            if (randomButton != null)
            {
                randomButton.Tag = randomGenerator.Next(1, 101); // slučajni broj između 1 i 100
                randomButton2.Tag = randomGenerator.Next(1, 101);
                randomButton3.Tag = randomGenerator.Next(1, 101);
                randomButton4.Tag = randomGenerator.Next(1, 101);
                randomButton5.Tag = randomGenerator.Next(1, 101);
                randomButton6.Tag = randomGenerator.Next(1, 101);
            }
        }

        private void button91_Click(object sender, EventArgs e)
        {
           

        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender == randomButton || sender == randomButton2 || sender == randomButton3 || sender == randomButton4 || sender == randomButton5
                || sender == randomButton6)
            {
                randomButton.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton.BackgroundImageLayout = ImageLayout.Stretch;
                randomButton2.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton2.BackgroundImageLayout = ImageLayout.Stretch;
                randomButton3.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton3.BackgroundImageLayout = ImageLayout.Stretch;
                randomButton4.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton4.BackgroundImageLayout = ImageLayout.Stretch;
                randomButton5.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton5.BackgroundImageLayout = ImageLayout.Stretch;
                randomButton6.BackgroundImage = Image.FromFile("\\Mine\\minesl.png");
                randomButton6.BackgroundImageLayout = ImageLayout.Stretch;
                DialogResult box=MessageBox.Show("Igra zavrsena!\r Zelite li igrati ponovo?","Igra je gotova!",MessageBoxButtons.YesNo);
                if(box==DialogResult.Yes)
                {
                    Application.Restart();

                }
            }
            else
            {
                (sender as Button).BackColor = Color.Gray;
                (sender as Button).Enabled = false;
                Random rnd = new Random();
                Random rnd2= new Random();
                int brojPonavljanja = rnd.Next(1, 4);
                for (int i = 0; i < brojPonavljanja; i++)
                {
                    Button dugmic=new Button();
                    //dugmic = this.Controls.OfType<Button>().OrderBy(x => rnd2.Next()).FirstOrDefault();
                    do
                    {
                        dugmic = this.Controls.OfType<Button>().OrderBy(x => rnd2.Next()).FirstOrDefault();
                    }while (!(int.Parse(dugmic.Tag.ToString()) > int.Parse((sender as Button).Tag.ToString()) - 2
                        && int.Parse(dugmic.Tag.ToString()) < int.Parse((sender as Button).Tag.ToString()) + 2 &&
                        int.Parse(dugmic.Tag.ToString())!= int.Parse(randomButton.Tag.ToString()) &&
                        int.Parse(dugmic.Tag.ToString()) != int.Parse(randomButton2.Tag.ToString())&& 
                        int.Parse(dugmic.Tag.ToString()) != int.Parse(randomButton3.Tag.ToString())&& 
                        int.Parse(dugmic.Tag.ToString()) != int.Parse(randomButton4.Tag.ToString())&&
                        int.Parse(dugmic.Tag.ToString()) != int.Parse(randomButton5.Tag.ToString()) &&
                        int.Parse(dugmic.Tag.ToString()) != int.Parse(randomButton6.Tag.ToString())) );
                    dugmic.BackColor = Color.Gray;
                    dugmic.Enabled = false;
                }

                brojac++;
                this.Text = $"Broj pokusaja --> {brojac.ToString()}";
            }
                
        }

       

        private void button9_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int brojac = 0;
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Tag = brojac; brojac++;
                }
            }

        }
    }
}
