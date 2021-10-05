using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_fHost
{
   public class Data
    {
       
       public string Url { get; set; }
       public string user { get; set; }
       public string password { get; set; }
        

        public Data(string url1, string name1, string password1)
        {
            Url = url1;
            user = name1;
            password = password1;
        }
    }

    
}
