using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    class MyClass { } 
}

namespace PrivateMethod
{
    class MyClass
    {
        private void Start()
        {
        }
    }
}

namespace PublicMethod
{
    class MyClass
    {
        public void Start()
        {
        }
    }
}

namespace InstantiateObject
{
    class MyClass
    {
        public void Start()
        {
            var obj = new System.Object();
        }
    }
}

namespace InstantiateObjectWithParameters
{
    class MyClass
    {
        public void Start()
        {
            var obj = new System.Object(someVariable);
        }
    }
}

namespace InvokeMethod
{
    class MyClass
    {
        public void Start()
        {
            var obj = new System.Object();
            obj.ToString();
        }
    }
}

namespace ArrayInitialization
{
    class MyClass
    {
        public void Start()
        {
            var array = new int[] { 1, 2, 3 };
        }
    }
}

namespace SetProperty
{
    class MyClass
    {
        public void Start()
        {
            var obj = new System.Net.IPAddress();
            obj.Address = 1234;
        }
    }
}