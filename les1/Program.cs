using System;
using System.Windows.Forms;
// Создаем шаблон приложения, где подключаем модули
namespace les0
{
	class Program
	{
		static void Main(string[] args)
		{
			Form form = new GameForm();
			form.Width = 1000;
			form.Height = 700;
            //Game.Init(form);
            SplashScreen.Init(form);
            form.Show();
			//Game.Draw();
			Application.Run(form);
		}
	}
}