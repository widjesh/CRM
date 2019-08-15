using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Repository
{
    public class RepositoryBase
    {
        public static IList<string> getProperties(string includeProperties)
        {
            IList<string> list = new List<string>();
            foreach(var st in includeProperties.Split(','))
            {
                list.Add(st);
            }
            return list;
        } 
    }
}
