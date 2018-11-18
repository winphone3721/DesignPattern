using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ConsoleApp1.¶¯Ì¬´úÀí
{
    public class ProxyDynamicFactory  : ConsoleApp1. ServerBase
    {
        ServerBase chan;
        public ProxyDynamicFactory(Type type)
        {

            chan = Build(type) as ServerBase;
        }

        public static Object Build(Type type)
        {

            return type.Assembly.CreateInstance(type.ToString());
        }

        public static Object Action<V>(V v, string @method, object[] parameter)
        {

            return v.GetType().GetMethod(@method).Invoke(v, parameter);

        }

       public void Eating()
        {
            chan.Eating();

        }




    }
}