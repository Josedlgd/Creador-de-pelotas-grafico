using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DibujarPelotas
{
    public partial class Form1 : Form
    {
        List<Pelota> lp;
        Random random = new Random();
        int i = 0;
        public int dir;

        public Form1()
        {
            InitializeComponent();
            lp = new List<Pelota>();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            dir = random.Next(1, 8);
            Pelota p = new Pelota(e.X, e.Y, i, dir);
            i++;
            lp.Add(p);

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pluma = new Pen(Color.Coral);
            Font font = new Font("Arial", 10);
            SolidBrush brush = new SolidBrush(Color.Aquamarine);

            foreach (Pelota p in lp)
            {
                g.DrawEllipse(pluma, p.x, p.y, 20, 20);
                g.DrawString(p.id.ToString(), font, brush, p.x + 3, p.y + 2);
            }
        }

       /* private bool EstanChocando(Pelota pelota2, Pelota pelota1)
        {
            if ((pelota1.x > pelota2.x && pelota1.x < pelota2.x + 20) &&
                (pelota1.y > pelota2.y && pelota1.y < pelota2.y + 20 || pelota1.y + 20 > pelota2.y && pelota1.y + 20 < pelota2.y + 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       */
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Pelota p1  in lp)
            {
                

                switch (p1.direccion)
                {
                    case 1: //->
                        if (p1.x + 20 < this.Width - 20)
                        {
                            p1.x += 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion); 
                        }
                        break;

                    case 2:// <-
                        if (p1.x > 0)
                        {
                            p1.x -= 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        break;

                    case 3: //up
                        if (p1.y + 30 < this.Height - 20)
                        {
                            p1.y += 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        break;

                    case 4: // don
                        if (p1.y > 0)
                        {
                            p1.y -= 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        break;
                    case 5: // -> + up
                        if ((p1.x + 20 < this.Width - 20) && (p1.y + 30 < this.Height - 30))
                        {
                            p1.x += 10;
                            p1.y += 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        break;
                       
                    case 6: //<- +don
                        if ((p1.x > 0) && (p1.y > 0))
                        {
                            p1.x -= 10;
                            p1.y -= 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        
                        break;
                    case 7: // -> + don
                        if ((p1.x + 20 < this.Width - 20) && (p1.y + 30 > 30))
                        {
                            p1.x += 10;
                            p1.y -= 10;
                        }
                        else
                        {
                            p1.direccion = cambioDireccion(p1.direccion); 
                        }
                        break;
                    case 8://<- + up
                        if ((p1.x > 0) && (p1.y + 30 < this.Height - 30))
                        {
                            p1.x -= 10;
                            p1.y += 10;
                        }
                        else
                        {

                            p1.direccion = cambioDireccion(p1.direccion);
                        }
                        break;
                }
                foreach (Pelota p2 in lp)
                {
                    if ((p1.x > p2.x && p1.x < p2.x + 20) &&
                    (p1.y > p2.y && p1.y < p2.y + 20 || p1.y + 20 > p2.y && p1.y + 20 < p2.y + 20))
                    {
                        p1.direccion = cambioDireccion(p1.direccion);
                        p2.direccion = cambioDireccion(p1.direccion);
                    }
                }

            }
            Invalidate();
        }

        public int cambioDireccion(int dir)
        {
            int r = dir;
            int aux;

            switch (dir)
            {
                case 1:
                    aux = random.Next(1, 8);

                    if (aux == 2 || aux == 6 || aux == 8)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 2:
                    aux = random.Next(1, 8);

                    if (aux == 1 || aux == 5 || aux == 7)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 3:
                    aux = random.Next(1, 8);

                    if (aux == 4 || aux == 5 || aux == 8)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 4:
                    aux = random.Next(1, 8);

                    if (aux == 3 || aux == 6 || aux == 7)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 5:
                    aux = random.Next(1, 8);

                    if (aux == 2 || aux == 3 || aux == 6)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 6:
                    aux = random.Next(1, 8);

                    if (aux == 1 || aux == 4 || aux == 5)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 7:
                    aux = random.Next(1, 8);

                    if (aux == 2 || aux == 4 || aux == 8)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
                case 8:
                    aux = random.Next(1, 8);

                    if (aux == 1 || aux == 3 || aux == 7)
                    {
                        r = aux;
                    }
                    else
                    {
                        r = cambioDireccion(dir);
                    }
                    break;
            }

            return r;
        }

        
    }
}
