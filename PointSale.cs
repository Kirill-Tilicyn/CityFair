using System;

namespace CityFair
{
    internal class PointSale
    {
        private string _name;

        public PointSale(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _name = "Точка продажи";
            }
            else
            {
                _name = name;
            }
        }
    }
}