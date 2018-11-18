using System;
namespace ConsoleApp1
{
    public class ProxyFactory:ServerBase
    {   

         public object Invoke(object @object, string @method, object[] parameters)
           {
             Console.WriteLine(
               string.Format("Interceptor does something before invoke [{0}]...", @method));
 
             var retObj = @object.GetType().GetMethod(@method).Invoke(@object, parameters);
 
             Console.WriteLine(
               string.Format("Interceptor does something after invoke [{0}]...", @method));
 
             return retObj;
           }

        ServerBase serverBase;
        Type type;
        public static ServerBase Build(Type type)
        {           
            ProxyFactory proxy =new ProxyFactory();
            try
            {
                 proxy.serverBase = type.Assembly.CreateInstance(type.ToString()) as ServerBase;
            }
            catch (System.Exception)
            {               
                throw;
            }          
            if(proxy.serverBase==null){
                throw new Exception("build 失败！");
            }
            proxy.type=type;
            return proxy;
        }  
        public void Eating()
        {
           
            if(type!=null &&serverBase !=null)
            {
                if(type.Equals(typeof(蝉)))
                {                    
                    serverBase.Eating();
                    ProxyFactory.Build(typeof(螳螂)).Eating();
                }
                else if(type.Equals(typeof(螳螂)))
                {                    
                    serverBase.Eating();
                    ProxyFactory.Build(typeof(黄雀)).Eating();
                }
                else if(type.Equals(typeof(黄雀)))
                {                    
                    serverBase.Eating();                  
                }
            }else{
                 Console.WriteLine("nothing!");
            }
            
        }      
    }
}