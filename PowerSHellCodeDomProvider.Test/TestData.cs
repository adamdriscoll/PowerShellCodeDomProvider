using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Classes

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

namespace MethodWithParameters
{
    class MyClass
    {
        public void Start(int parameter1, string parameter2)
        {
        }
    }
}

#endregion

#region Instantiation

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

#endregion

#region Methods

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

namespace InvokeMethodWithParameters
{
    class MyClass
    {
        public void Start()
        {
            var dateTime = new DateTime();
            dateTime.AddMinutes(1);
        }
    }
}

#endregion

#region Properties

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

namespace GetProperty
{
    class MyClass
    {
        public void Start()
        {
            var obj = new System.Net.IPAddress();
            var address = obj.Address;
        }
    }
}

#endregion

#region Conditions

namespace IfElseStatement
{
    class MyClass
    {
        public void Start()
        {
            if (true)
            {
                var obj = new System.Object();
            }
            else
            {
                var obj2 = new System.Object();
            }
        }
    }
}

#endregion