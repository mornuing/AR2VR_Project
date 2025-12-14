using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecryptHell
{
    public abstract class Singleton<T> where T: Singleton<T>, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                    instance.Init();
                }
                return instance;
            }
        }
        public abstract void Init();
    }
}

