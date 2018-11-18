using System;
using ConsoleApp1.动态代理;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServerBase serverBase = ProxyFactory.Build(typeof(蝉));
            serverBase.Eating();
            //object[] objects = { new 蝉1() };
            //serverBase = new 螳螂1<蝉1>(new 蝉1());
            //serverBase.Eating();
        }
    }

}