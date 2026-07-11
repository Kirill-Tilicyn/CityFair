using System;
using System.Collections.Generic;

namespace CityFair
{
    internal class PointSale
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

        public string GetSellers()
        {
            if (_seller == null)
            {
                return "За данной торговой точкой не закреплен продавец!";
            }

            return _seller.GetName();
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