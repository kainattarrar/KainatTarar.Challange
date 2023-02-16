using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Model.Shared
{
    public static class MyExceptionHandler
    {
        public static string GetAllExceptionMessages(this Exception exception)
        {
            var messages = exception.FromHierarchy(ex => ex.InnerException).Select(ex => exception.Message);
            return String.Join(Environment.NewLine, messages);
        }
    }
}
