using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static object threadSafe = new object();

        public static T Instance
        {
            get { return GetInstance(); }
            set { }
        }

        public static T GetInstance()
        {
            lock (threadSafe)
            {
                if (_instance == null)
                    _instance = new T();
            }
            return _instance;
        }
    }
}
