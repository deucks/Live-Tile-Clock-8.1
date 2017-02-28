using Live_Clock_Tile.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live_Clock_Tile
{
    public class PayFace
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Img { get; set; }
        public string Buycode { get; set; }
        public string Wide { get; set; }

    }

    class PayList : List<PayFace>
    {
        string wide = AppResources.WideTile.ToString();

        public PayList()
        {
            Add(new PayFace { Name = "Buy All", Price = "$1.99", Img = "http://i.imgur.com/MmXFXty.png", Buycode = "buyAll", Wide="with all future clocks"});
            Add(new PayFace { Name = "Domo", Price = "$0.99", Img = "http://i.imgur.com/fLqbmPX.png", Buycode = "domoClock1", Wide = wide });
            Add(new PayFace { Name = "Zaag", Price = "Rate to unlock", Img = "http://i.imgur.com/sALpc9X.png", Buycode = "11", Wide = wide });
            Add(new PayFace { Name = "Poki", Price = "$0.99", Img = "http://i.imgur.com/V7xBH2k.png", Buycode = "pokiClock1", Wide = wide });
            Add(new PayFace { Name = "Minion", Price = "$0.99", Img = "http://i.imgur.com/bUkHdyU.png", Buycode = "minionClock1", Wide = "" });
            Add(new PayFace { Name = "Digital", Price = "$0.99", Img = "http://i.imgur.com/5urF6K7.png", Buycode = "digitalClock1", Wide = wide });
            Add(new PayFace { Name = "Fade", Price = "$0.99", Img = "http://i.imgur.com/DOZsXM2.png", Buycode = "fadeClock1", Wide = wide });
            Add(new PayFace { Name = "Circles", Price = "$0.99", Img = "http://i.imgur.com/8mSb6GQ.png", Buycode = "circlesClock1", Wide = "" });
            Add(new PayFace { Name = "Breeze", Price = "$0.99", Img = "http://i.imgur.com/JkndgOi.png", Buycode = "breezeClock1", Wide = "" });
            Add(new PayFace { Name = "Grin", Price = "$0.99", Img = "http://i.imgur.com/U0Bdl78.png", Buycode = "grinClock1", Wide = "" });
            Add(new PayFace { Name = "Sunshine", Price = "$0.99", Img = "http://i.imgur.com/LASywVI.png", Buycode = "sunshineClock1", Wide = wide });
            Add(new PayFace { Name = "CMD", Price = "$0.99", Img = "http://i.imgur.com/FKap7sE.png", Buycode = "cmdClock1", Wide = wide });
            Add(new PayFace { Name = "Crypt", Price = "$0.99", Img = "http://i.imgur.com/wGyJ3XO.png", Buycode = "cryptClock1", Wide = "" });
        }
    }
}
