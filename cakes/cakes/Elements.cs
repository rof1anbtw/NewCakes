using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakes
{
    internal class Elements
    {
        public int EL;
        public string Discription;
        public int Price;
        public Action Action;
        public Elements(int el, string discription, int price, Action action)
        {
            EL = el;
            Discription = discription;
            Price = price;
            Action = action;

        }
        public Elements(int el, string discription, int price)
        {
            EL = el;
            Discription = discription;
            Price = price;

        }
    }
}
