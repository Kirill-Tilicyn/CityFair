using System;
using System.Collections.Generic;

namespace CityFair
{
    public class Fair
    {
        private string _name;
        private List<PointSale> _points;

        public Fair(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _name = "Зарубежная ярмарка";
            }
            else
            {
                _name = name;
            }

            _points = new List<PointSale>();
        }

        public string GetFair()
        {
            return _name;
        }

        public bool AddPointSale(string namePointSale)
        {
            if (string.IsNullOrEmpty(namePointSale))
            {
                return false;
            }

            _points.Add(new PointSale(namePointSale));
            return true;
        }
    }
}