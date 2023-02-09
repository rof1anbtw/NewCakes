using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace cakes
{
    internal class Program
    {
        static void Main()
        {
            Menu mainMenu = new Menu();
            
            Menu Form = new Menu();
            Form.Title = "Форма торта";
            Form.AddItem(0, "Квадрат - 400", 400);
            Form.AddItem(1, "Круг - 500", 500);
            Form.AddItem(2, "Тругольник - 700", 700);
            Form.PlayMenu = mainMenu;

            Menu Size = new Menu();
            Size.Title = "Размер ";
            Size.AddItem(0, "Большой+ - 2300", 2300);
            Size.AddItem(1, "Большой - 1800", 1800);
            Size.AddItem(2, "Средний - 1400", 1400);
            Size.AddItem(3, "Маленький - 900", 900);

            Size.PlayMenu = mainMenu;

            Menu Taste = new Menu();
            Taste.Title = "Вкус коржей";    
            Taste.AddItem(0, "Шоколадный - 300", 300);
            Taste.AddItem(1, "Ванильный - 350", 350);
            Taste.AddItem(2, "Клубничный - 500", 500);
            Taste.AddItem(3, "Лесные ягоды - 400", 400);
            Taste.prices = new int[] { 300, 350, 500, 400 };
            Taste.PlayMenu = mainMenu;

            Menu Stuff = new Menu();
            Stuff.Title = "Начинка тортика";
            Stuff.AddItem(0, "Шоколадная - 250", 250);
            Stuff.AddItem(1, "Ванильная - 300", 300);
            Stuff.AddItem(2, "Клубничная - 400", 400);
            Stuff.AddItem(3, "Кремовая - 500", 500);
            Stuff.prices = new int[] { 250, 300, 400, 500 };


            Stuff.PlayMenu = mainMenu;


            Menu numberoftiers = new Menu();
            numberoftiers.Title = "Количество ярусов";
            numberoftiers.AddItem(0, "Один ярус - 500", 500);
            numberoftiers.AddItem(1, "Два яруса - 800", 800);
            numberoftiers.AddItem(2, "Три яруса - 1200", 1200);

            numberoftiers.PlayMenu = mainMenu;

            Menu Dop = new Menu();
            Dop.Title = "Декор";
            Dop.AddItem(0, "Ягоды - 500", 500);
            Dop.AddItem(1, "Мастика - 300", 300);
            Dop.AddItem(2, "Мармелад - 400", 400);
            Dop.AddItem(3, "Без оформления", 0);

            Dop.PlayMenu = mainMenu;

            mainMenu.Title = "  Конструктор тортов";
            mainMenu.AddItem2(0, "Форма торта", 0, Form.ShowMenu);
            mainMenu.AddItem2(1, "Размер торта", 0, Size.ShowMenu);
            mainMenu.AddItem2(2, "Вкус коржей", 0, Taste.ShowMenu);
            mainMenu.AddItem2(3, "Начинка торта", 0, Stuff.ShowMenu);
            mainMenu.AddItem2(4, "Количество ярусов", 0, numberoftiers.ShowMenu);
            mainMenu.AddItem2(5, "Доп. оформление", 0, Dop.ShowMenu);
            mainMenu.AddItem2(6, "Конец оформления заказа", 0, Exit);

            mainMenu.ShowMenu();


            static void Exit()
            {
                Console.WriteLine("Ваш заказ оформлен");

                string path = "C:\\Users\\Я\\Desktop\\zakaz\\history.txt";
                string text = "Описание заказа";
                foreach (string item in Menu.Order) { Console.WriteLine(item); };
                string price = "Цена: " + Menu.Price;
                if (File.Exists(path))
                {
                    File.AppendAllText(path, text);
                    File.AppendAllText(path, price);
                }
                else
                {
                    File.Create(path);
                }
                Environment.Exit(0);
            }
        }
    }
}