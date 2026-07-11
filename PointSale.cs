using System;
using System.Collections.Generic;

namespace CityFair
{
    public class PointSale
    {
        private string _name;
        private Seller _seller;

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

            _seller = null;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSeller()
        {
            if (_seller == null)
            {
                return "За данной торговой точкой не закреплен продавец!";
            }

            return $"Продавец: {_seller.GetName()}";
        }

        public bool AddSeller(Seller registeringSeller)
        {
            if (registeringSeller == null)
            {
                return false;
            }

            if (_seller != null)
            {
                return false;
            }

            _seller = registeringSeller;
            return true;
        }

        public bool DeleteSeller()
        {
            if (_seller == null)
            {
                return false;
            }

            _seller = null;
            return true;
        }
    }
}