using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMVC_SundayBatch.Repository
{
    public interface ILogger
    {
        Boolean Log();
    }
    public class Logger : ILogger
    {
        public Boolean Log()
        {
            //Log your data
            return true;
        }
    }
}
