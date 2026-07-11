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

        public bool AddPointSale(string namePointSale)
        {
            if (string.IsNullOrEmpty(namePointSale))
            {
                return false;
            }

            _points.Add(new PointSale(namePointSale));
            return true;
        }

        public bool AddSellerToPointSale(Seller registeringSeller, string namePointSale)
        {
            if (registeringSeller == null)
            {
                return false;
            }

            PointSale activePointSale = null;

            foreach (PointSale pointSale in _points)
            {
                if (pointSale.GetName() == namePointSale)
                {
                    activePointSale = pointSale;
                }
            }

            if (activePointSale == null)
            {
                return false;
            }

            foreach (Seller seller in activePointSale.GetSellers())
            {
                if (seller == registeringSeller)
                {
                    return false;
                }
            }

            activePointSale.AddSeller(registeringSeller);
            return true;
        }
    }
}