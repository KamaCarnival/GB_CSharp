using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace les0
{
    class Bullet : BaseObject
    {
        Image bulletImg = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\images\bullet.png"));
        public Bullet(Point pos, Point dir, Size size, int ind)
            : base(pos, dir, size, ind)
        {
        }
        public override void ObjDraw()
        {
            //Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(bulletImg, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void ObjUpdate()
        {
            Pos.X = Pos.X + 3;
        }
    }
}
