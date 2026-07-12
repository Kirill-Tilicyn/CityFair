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

        public string GetName()
        {
            return _name;
        }

        public List<PointSale> GetPoints()
        {
            return _points;
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

        public bool AddSellerToPointSale(Seller registeringSeller, PointSale namePointSale)
        {
            if (registeringSeller == null || namePointSale == null)
            {
                return false;
            }

            bool hasSellerAdded = namePointSale.AddSeller(registeringSeller);
            return hasSellerAdded;
        }
    }
}