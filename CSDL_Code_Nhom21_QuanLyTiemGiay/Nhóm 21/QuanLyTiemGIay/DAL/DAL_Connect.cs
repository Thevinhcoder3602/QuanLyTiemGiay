using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Connect
    {
      
        public SqlConnection conn = new SqlConnection("Data Source=DESKTOP-8DJRU8K\\CSDLSERVER;Initial Catalog=QLTiemGiay;Integrated Security=True");
        
    }
}
