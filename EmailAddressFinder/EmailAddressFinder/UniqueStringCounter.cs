using System.Collections.Generic;


namespace EmailAddressFinder
{
    class UniqueStringCounter
    {
        private Dictionary<string, int> _list;


        public UniqueStringCounter()
        {
            _list = new Dictionary<string, int>();
        }


        public void addString(string str)
        {
            if (_list.ContainsKey(str))
            {
                _list[str]++;
            }
            else
            {
                _list.Add(str, 1);
            }
        }

        public Dictionary<string, int> getList()
        {
            return _list;
        }



    }
}
