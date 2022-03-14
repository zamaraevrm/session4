using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session4
{
    class AppMV
    {
        private string connString = @"Data Source=DBSRV\SQL2021;Initial Catalog=Zamaraev_Roman;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        AppMV()
        {
            using (SqlConnection sql = new(connString))
            {
                sql.Open();
                SqlCommand command = new("select * from materials_s_import$", sql)
            }
        }

    }
}
