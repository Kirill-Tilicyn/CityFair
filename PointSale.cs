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

        public bool AddSeller(Seller seller)
        {
            _sellers.Add(seller);
            return true;
        }
    }
}