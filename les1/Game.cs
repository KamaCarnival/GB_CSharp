using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;
namespace les0
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        public static BufferedGraphics Buffer;
        public static Timer timer;
        static Image background = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\images\galaxy.gif"));

        static Random r = new Random();

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        
        static Game()
        {
        }
        public static BaseObject[] _objs;


        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            timer = new Timer { Interval = 40 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }


        /// <summary>
        /// инициализация объектов
        /// </summary>
		public static void Load()
        {
            _objs = new BaseObject[40];
            _bullet = new Bullet(new Point(200, 200), new Point(5, 5), new Size(20, 20), 0);
            _asteroids = new Asteroid[15];
    
            //звёзды
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(r.Next(10, Height-10), r.Next(10, Width-10)), new Point(3,10), new Size(20, 20), i);
            //астероиды
            for (int i = 0; i < _asteroids.Length; i++)
                _asteroids[i] = new Asteroid(new Point(r.Next(10, Height - 10), r.Next(10, Width - 10)), new Point(5, 20), new Size(50, 50), i);

        }
        /// <summary>
        /// Таймер отрисовки на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
		{
			Draw();
			Update();
		}

        /// <summary>
        /// отрисовка на форме
        /// </summary>
		public static void Draw()
		{
			Buffer.Graphics.Clear(Color.Transparent);
            //Buffer.Graphics.DrawImage(background, 0, 0);
            Buffer.Graphics.DrawImage(background, new Rectangle(0, 0, Width, Height));

            foreach (BaseObject obj in _objs)
				obj.ObjDraw();
            foreach (BaseObject astr in _asteroids)
                astr.ObjDraw();
            _bullet.ObjDraw();
            Buffer.Render();
		}

        /// <summary>
        /// Обновление объектов
        /// </summary>
		public static void Update()
		{
			foreach (BaseObject obj in _objs)
				obj.ObjUpdate();
            foreach (BaseObject astr in _asteroids)
            {
                astr.ObjUpdate();
                if (astr.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); }
            }
            _bullet.ObjUpdate();
		}
	}
}
