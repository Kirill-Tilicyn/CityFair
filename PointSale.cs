using System;
using System.Collections.Generic;

namespace CityFair
{
    internal class PointSale
    {
        private string _name;
        private List<Seller> _sellers;

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

            _sellers = new List<Seller>();
        }

        public string GetName()
        {
            return _name;
        }

        public List<Seller> GetSellers()
        {
            return _sellers;
        }

        public bool AddSeller(Seller registeringSeller)
        {
            if (registeringSeller == null)
            {
                return false;
            }

            foreach (Seller seller in _sellers)
            {
                if (seller == registeringSeller)
                {
                    return false;
                }
            }

            _sellers.Add(registeringSeller);
            return true;
        }

        public bool DeleteSeller(Seller seller)
        {
            if (seller == null)
            {
                return false;
            }

            if (!_sellers.Contains(seller))
            {
                return false;
            }

            int sellerNumber = _sellers.IndexOf(seller);

            _sellers.RemoveAt(sellerNumber);
            return true;
        }
    }
}