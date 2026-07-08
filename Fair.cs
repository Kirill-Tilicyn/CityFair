using System;

namespace CityFair
{
    public class Fair
    {
        private string _name;

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
        }
    }
}