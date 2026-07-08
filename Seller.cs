using System;

namespace CityFair
{
    public class Seller
    {
        private string _name;

        public Seller(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _name = "Иван Иванов";
            }
            else
            {
                _name = name;
            }
        }
    }
}