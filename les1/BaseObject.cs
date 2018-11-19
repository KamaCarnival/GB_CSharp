using System;
using System.Drawing;

namespace les0

{
	abstract class BaseObject : ICollision
	{
		protected Point Pos;
		protected Point Dir;
		protected Size Size;
        protected int Ind;
        public Random rnd = new Random();
        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)
        
        public Rectangle Rect {  get { return new Rectangle(Pos, Size); } }
        public bool Collision(ICollision o) { return o.Rect.IntersectsWith(this.Rect); }
        protected BaseObject(Point pos, Point dir, Size size, int ind)
		{
			Pos = pos;
			Dir = dir;
			Size = size;
            Ind = ind;
		}
        /// <summary>
        /// Метод отрисовки объектов
        /// </summary>
        public abstract void ObjDraw();
		
        /// <summary>
        /// Метод поворота изображения на заданный угол
        /// </summary>
        /// <param name="img"></param>
        /// <param name="rotationAngle"></param>
        /// <returns></returns>
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Image bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
        /// <summary>
        /// Метод обновления направления движения объектов
        /// </summary>
		public virtual void ObjUpdate()
		{
			Pos.X = Pos.X + Dir.X;
			Pos.Y = Pos.Y + Dir.Y;
			if (Pos.X < 0) Dir.X = -Dir.X;
			if (Pos.X > Game.Width) Dir.X = -Dir.X;
			if (Pos.Y < 0) Dir.Y = -Dir.Y;
			if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
		}
	}
}
