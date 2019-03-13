using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Me_Demo_CefSharp
{
    public class BoundObject
    {
        public string myProperty { get; set; } = "DNLi";

        public void myMethod(string ShowNickName, string html)
        {
            try
            {
                Console.WriteLine("我来响应前台的的事件");
            }
            catch (Exception ex)
            {

            }
        }

        public string mytest()
        {
            return "123123";
        }
    }
}
