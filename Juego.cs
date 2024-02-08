using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corte2s
{
    public partial class Juego : Form

    {
        SoundPlayer musica_fondo;
        SoundPlayer muerte;
        SoundPlayer victoria;
        //SoundPlayer disparo1;
        int vidas = 3;
        int puntaje = 0;
        int tiempo = 0;
        Boolean visible = true;
        Boolean enable = true;


        public Juego()
        {
            InitializeComponent();

            musica_fondo = new SoundPlayer(@"C:\Users\R5\Documents\Visual Studio 2022\sonidos\lluvia.wav");
            muerte = new SoundPlayer(@"C:\Users\R5\Documents\Visual Studio 2022\sonidos\muerte.wav");
            victoria = new SoundPlayer(@"C:\Users\R5\Documents\Visual Studio 2022\sonidos\ganar.wav");



        }

        private void Juego_Load_1(object sender, EventArgs e)
        {
            musica_fondo.Play();

        }

        private void Juego_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiShot1;
            }
            if (e.KeyChar == 'z')
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiFront;
                Deivyth.Location = new Point(19, 356);
            }
            if (e.KeyChar == 'x')
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiFront;
                Deivyth.Location = new Point(802, 356);
            }
        }
       
        public void moverGotas()
        {
            gotaA1.Top += 7;
            gotaA2.Top += 5;

            gotaB1.Top += 7;
            gotaB2.Top += 6;
            gotaB3.Top += 5;


            gotaC1.Top += 5;

        }

        public void moverGotasDificil()
        {
            gotaA1.Top += 8;
            gotaA2.Top += 7;
            gotaA3.Top += 12;


            gotaB1.Top += 7;
            gotaB2.Top += 6;
            gotaB3.Top += 5;


            gotaC1.Top += 10;
            gotaC2.Top += 9;
            gotaC3.Top += 8;

        }
        public void retornoArriba(PictureBox gota)
        {
            if (gota.Location.Y > 515)
            {
                gota.Location = new Point(gota.Location.X, 76);
            }
        }

        public void tocar()
        {
            if (Deivyth.Bounds.IntersectsWith(gotaA1.Bounds) || Deivyth.Bounds.IntersectsWith(gotaB1.Bounds) || Deivyth.Bounds.IntersectsWith(gotaC1.Bounds) || Deivyth.Bounds.IntersectsWith(gotaA2.Bounds) 
                || Deivyth.Bounds.IntersectsWith(gotaB2.Bounds) || Deivyth.Bounds.IntersectsWith(gotaB3.Bounds) || Deivyth.Bounds.IntersectsWith(gotaC2.Bounds) || Deivyth.Bounds.IntersectsWith(gotaC3.Bounds)
                || Deivyth.Bounds.IntersectsWith(gotaA3.Bounds))
            {
                musica_fondo.Stop();
                timer1.Stop();
                timer3.Stop();
                Deivyth.Image = Corte2s.Properties.Resources.esqueleto;
                muerte.Play();
                quitarVidas();

                DialogResult respuesta = MessageBox.Show("¿Desea continuar ? ", "Reinicio de Juego", MessageBoxButtons.YesNo);


                if (respuesta == DialogResult.Yes)
                {
                    Deivyth.Image = Corte2s.Properties.Resources.deiFront;
                    Deivyth.Location = new System.Drawing.Point(25, 331);
                    timer1.Start();
                    timer3.Start();
                    muerte.Stop();
                    musica_fondo.Play();

                }
                else if (respuesta == DialogResult.No)
                {
                    Close();
                }

            }

            if (Deivyth.Bounds.IntersectsWith(paraguas.Bounds))
            {
                puntaje += 5;
                lbl_puntaje.Text = puntaje.ToString();

                paraguas.Location = new Point(0, 0);
                paraguas.Visible = false;

                timer2.Start();

                if(puntaje == 20) 
                {
                    timer1.Stop();
                    
                    paraguas.Location = new Point(0, 0);

                    musica_fondo.Stop();
                    muerte.Stop();
                    victoria.Play();
                   

                    MessageBox.Show("pasaste al siguiente nivel");
                    timer3.Start();
                    victoria.Stop();
                    musica_fondo.Play();
                }

                if (puntaje == 35)
                {
                    timer1.Stop();
                    timer3.Stop();

                    paraguas.Location = new Point(0, 0);

                    musica_fondo.Stop();
                    muerte.Stop();
                    victoria.Play();

                    MessageBox.Show("Ganaste");
                    
                    Close();
                }

                //Random aleatorio = new Random(); // para sacar un numero random
                //moneda.Location = new Point(aleatorio.Next(700), aleatorio.Next(316)+250);
            }
            
        }

        private void Juego_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiRight;
                Deivyth.Left += 10;
            }
            if (e.KeyCode == Keys.Left)
            {
                Deivyth.Left -= 10;
                Deivyth.Image = Corte2s.Properties.Resources.deiLeft;
            }
            if (e.KeyCode == Keys.Up)
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiBack;
                Deivyth.Top -= 10;

            }
            if (e.KeyCode == Keys.Down)
            {
                Deivyth.Image = Corte2s.Properties.Resources.deiFront;
                Deivyth.Top += 10;
            }
        }
        public void quitarVidas()
        {
            switch (vidas)
            {
                case 1:
                    corazon1.Image = Corte2s.Properties.Resources.corazin;
                    Deivyth.Image = Corte2s.Properties.Resources.esqueletoDead1;
                    timer3.Stop();
                    MessageBox.Show("Perdiste");
                    Close();

                    break;
                case 2:
                    corazon2.Image = Corte2s.Properties.Resources.corazin;
                    break;
                case 3:
                    corazon3.Image = Corte2s.Properties.Resources.corazin;
                    break;
            }


            vidas--;


        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            moverGotas();
            tocar();

            retornoArriba(gotaA1);
            retornoArriba(gotaA2);

            retornoArriba(gotaB1);
            retornoArriba(gotaB2);
            retornoArriba(gotaB3);

            retornoArriba(gotaC1);

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            tiempo++;
            if (tiempo == 3)
            {
                Random aleatorio = new Random(); // para sacar un numero random
                paraguas.Location = new Point(aleatorio.Next(800), aleatorio.Next(100) + 250);
                
                tiempo = 0;
                timer2.Stop();
                paraguas.Visible = true;

            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            

            
            moverGotasDificil();
            tocar();

            retornoArriba(gotaA1);
            retornoArriba(gotaA2);
            gotaA3.Visible=true;
            retornoArriba(gotaA3);

            retornoArriba(gotaB1);
            retornoArriba(gotaB2);
            retornoArriba(gotaB3);

            retornoArriba(gotaC1);
            gotaC2.Visible = true;
            gotaC3.Visible = true;
            retornoArriba(gotaC2);
            retornoArriba(gotaC3);


        }
    }
}
