using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace les0
{
    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size, int ind) : base(pos, dir, size, ind)
        {
        }

        static Image[] AsteroidsImg = {
                                Image.FromFile(Application.StartupPath + @"\images\asteroid1_small.png"),
                                Image.FromFile(Application.StartupPath + @"\images\asteroid2_small.png"),
                                Image.FromFile(Application.StartupPath + @"\images\asteroid3_small.png")
                                };



        public override void ObjDraw()
        {
            //AsteroidsImg[(Ind % 3)] = RotateImage(AsteroidsImg[(Ind % 3)], -3);
            //AsteroidsImg[(Ind % 3)].RotateFlip(RotateFlipType.Rotate90FlipNone);
            Game.Buffer.Graphics.DrawImage(AsteroidsImg[(Ind % 3)], Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        

        public override void ObjUpdate()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }


}

}
