using System;
using System.Drawing;

namespace les0

{
	class SplashObj
	{
		protected Point Pos;
		protected Point Dir;
		protected Size Size;
        protected int Ind;
        public Random rnd = new Random();
        public SplashObj(Point pos, Point dir, Size size, int ind)
		{
			Pos = pos;
			Dir = dir;
			Size = size;
            Ind = ind;
		}
        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
		public virtual void ObjDraw()
		{
			SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

        /// <summary>
        /// Метод обновления направления движения объектов
        /// </summary>
		public virtual void ObjUpdate()
		{
			Pos.X = Pos.X + Dir.X;
			Pos.Y = Pos.Y + Dir.Y;
			if (Pos.X < 0) Dir.X = -Dir.X;
			if (Pos.X > SplashScreen.Width) Dir.X = -Dir.X;
			if (Pos.Y < 0) Dir.Y = -Dir.Y;
			if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
		}
	}
}
