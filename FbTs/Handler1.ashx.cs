using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FbTs
{
	/// <summary>
	/// Summary description for Handler1
	/// </summary>
	public class Handler1 : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			context.Response.Write("Hello World");
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public static int Unittest()
		{
			//SqlConnection con = new SqlConnection(@"Data Source=pue-n7737\sqlexpress2008;Initial Catalog=FBTS;Integrated Security=True" );
			SqlConnection con = new SqlConnection(@"Data Source=pue-n7737\sqlexpress2008;Initial Catalog=FBTS; User ID=fbts; Password=fbts" );
			//SqlConnection con = new SqlConnection(@"server=.\sqlexpress2008; AttachDbFilename=D:\DOTNET4_2013\SOL1\FBTS\APP_DATA\FB_TS.MDF; User ID=fbts; Password=fbts");
			
			con.Open();
			con.Close();
			return 0;
		}
	}
}