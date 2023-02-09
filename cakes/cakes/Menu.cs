using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes
{
    public class Menu
    {
        public Menu PlayMenu;
        public string Title , Arrow;
        private int position;
        private bool Exit;
        public int Cena;


        public int AllPrice { get; private set; } = 0;

        private List<Elements> ItemList;
        public int[] prices = new int[] { };

        

        public static int Price = 0;
        public static List<string> Order = new List<string> { };
        public Menu()
        {
            string arrow = "->";
            ItemList = new List<Elements>();
            position = 0;

            Arrow = arrow;
        }
        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(Title);

            for (int i = 0; i < ItemList.Count; i++)
            {
                if (i == position)
                {
                    Console.Write(Arrow + " ");
                    Console.WriteLine(ItemList[i].Discription);

                }
                else
                {
                    Console.Write(new string(' ', (Arrow.Length + 0)));
                    Console.WriteLine(ItemList[i].Discription);
                }
            }
            Console.WriteLine("Цена:" + Menu.Price);
            Console.WriteLine("Заказ: ");
            foreach (string item in Menu.Order)
            {
                Console.WriteLine(item);
            }
        }
        public void ShowMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Draw();
            Exit = false;
            while (!Exit)
            {
                MenuUpdate();

            }
        }

        public void HideMenu()
        {

            Exit = true;
        }

        public void MenuUpdate()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        ItemList[position].Action();
                        Menu.Price += ItemList[position].Price;
                        Menu.Order.Add(ItemList[position].Discription);
                        Console.CursorVisible = false;
                        Console.Clear();
                        Draw();
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        if (PlayMenu != null)
                        {
                            HideMenu();
                        }
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        position--;
                        if (position < 0)
                        {
                            position++;
                            Console.Clear();
                            Draw();

                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {

                        if (position < (ItemList.Count - 1))
                        {
                            position++;
                            Console.Clear();
                            Draw();

                        }
                        break;
                    }
            }
        }

        public bool AddItem(int el, string discription, int price)
        {
            if (!ItemList.Any(item => item.EL == el))
            {

                ItemList.Add(new Elements(el, discription, price ));

                HideMenu();
            }
            return false;
        }

        public bool AddItem2(int el, string discription, int price, Action action)
        {
            if (!ItemList.Any(item => item.EL == el))
            {

                ItemList.Add(new Elements(el, discription, price, action));

                ShowMenu();
            }
            return false;
        }
    }
}
