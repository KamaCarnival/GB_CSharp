using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace les0
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Timer timer;
        static Random r = new Random();
       // static Image background = Image.FromFile(Application.StartupPath + @"\images\galaxy.gif");
        public static SplashObj[] _objs;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static SplashScreen()
        {
        }
        

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
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        /// <summary>
        /// инициализация объектов
        /// </summary>
        public static void Load()
        {
            _objs = new SplashObj[50];

            for (int i = 0; i < _objs.Length; i++)
            {
                var rndSize = r.Next(10, 30);
                _objs[i] = new SplashObj(new Point(r.Next(100, Height - 10), r.Next(10, Width - 10)), new Point(r.Next(5,40), r.Next(5, 40)), new Size(rndSize, rndSize), i);
            }
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
           Buffer.Graphics.Clear(Color.Black);
            foreach (SplashObj obj in _objs)
                obj.ObjDraw();
            Buffer.Render();
        }

        /// <summary>
        /// Обновление объектов
        /// </summary>
        public static void Update()
        {
            foreach (SplashObj obj in _objs)
                obj.ObjUpdate();
        }
    }
}

