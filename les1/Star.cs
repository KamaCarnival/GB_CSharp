using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace les0
{
	class Star : BaseObject
	{
		public Star(Point pos, Point dir, Size size, int ind) : base(pos, dir, size, ind)
		{
		}
        Image starImg = Image.FromFile(Application.StartupPath +@"\images\star_small.png");
		public override void ObjDraw()
		{
		    Game.Buffer.Graphics.DrawImage(starImg , Pos.X, Pos.Y,10, 10);
		}
		public override void ObjUpdate()
		{
			Pos.X = Pos.X - Dir.X;
			if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
		}


	}

}
