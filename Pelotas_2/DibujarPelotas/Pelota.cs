using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibujarPelotas
{
    class Pelota
    {
        public int
            x=0,
            y=0,
            id=0,
            direccion=0;

        public Pelota()
        { }

        public Pelota(int x, int y, int id, int direccion)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.direccion = direccion;
        }
    }
}
