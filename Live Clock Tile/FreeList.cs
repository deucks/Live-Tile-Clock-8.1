using Live_Clock_Tile.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Live_Clock_Tile
{
    public class FreeFace
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Img { get; set; }
        public string Wide { get; set; }

    }

    class FreeList : List<FreeFace>
    {
        string free = AppResources.Free.ToString();
        string wide = AppResources.WideTile.ToString();

        public FreeList()
        {
            Add(new FreeFace { Name = "Modern", Price = free, Img = "http://i.imgur.com/X1HoBNf.png", Wide = wide });
            Add(new FreeFace { Name = "Modern 2", Price = free, Img = "http://i.imgur.com/kyypDEI.png", Wide = wide });
            Add(new FreeFace { Name = "Idea", Price = free, Img = "http://i.imgur.com/1nboN8Y.png", Wide = wide });
            Add(new FreeFace { Name = "Glow", Price = free, Img = "http://i.imgur.com/8bKDIwH.png", Wide = wide });
            Add(new FreeFace { Name = "Simple", Price = free, Img = "http://i.imgur.com/RjIZHR4.png", Wide = wide });
            //Add(new FreeFace { Name = "Flip", Price = free, Img = "http://i.imgur.com/F5xbGqk.png", Wide = "with wide tile" });
            Add(new FreeFace { Name = "Stars", Price = free, Img = "http://i.imgur.com/GHYTid4.png", Wide = "" });
            Add(new FreeFace { Name = "Cortana", Price = free, Img = "http://i.imgur.com/xrpWui2.png", Wide = "" });
            Add(new FreeFace { Name = "Bold", Price = free, Img = "http://i.imgur.com/7GdYfpf.png", Wide = "" });
            Add(new FreeFace { Name = "Fly", Price = free, Img = "http://i.imgur.com/phCP6Ch.png", Wide = "" });
            Add(new FreeFace { Name = "Hands", Price = free, Img = "http://i.imgur.com/wRqUyrE.png", Wide = "" });
            Add(new FreeFace { Name = "Spot", Price = free, Img = "http://i.imgur.com/jTAVxY4.png", Wide = "" });
            Add(new FreeFace { Name = "Analog", Price = free, Img = "http://i.imgur.com/VYlqGps.png", Wide = wide });
            Add(new FreeFace { Name = "Decimal", Price = free, Img = "http://i.imgur.com/mMcMja8.png", Wide = wide });
            

        }
    }
}
