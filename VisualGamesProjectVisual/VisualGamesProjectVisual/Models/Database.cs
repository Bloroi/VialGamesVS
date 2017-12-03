using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VialGamesVisual.Models
{
	public class Database
	{
		public static readonly string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDVialGames;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //VICTOR//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbProjectTI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        //ALEX//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDVialGames;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        public static SqlConnection GetConnection()
		{
			return new SqlConnection(Database.CONNECTION_STRING);
		}
	}
}