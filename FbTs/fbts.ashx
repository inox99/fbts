<%@ WebHandler Language="C#" Class="fbts" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class fbts : IHttpHandler
{
	void getJsSpiele(HttpResponse hRes)
	{
		hRes.ContentType = "text/plain";
	}
	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "text/plain";
		try
		{
			string cmd = context.Request.Params["cmd"];
			if (string.Compare(cmd, "requkey", true) == 0)
			{
				string pin = context.Request.Params["pin"];
				context.Response.Write("asdfg");
			}
			if (string.Compare(cmd, "unittest", true) == 0)
			{
				Unittest();
			}
		}
		catch (Exception)
		{

			throw;
		}
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
		SqlConnection con = new SqlConnection(@"Data Source=pue-n7737\sqlexpress2008;Initial Catalog=FBTS; User ID=fbts; Password=fbts");
		//SqlConnection con = new SqlConnection(@"server=.\sqlexpress2008; AttachDbFilename=D:\DOTNET4_2013\SOL1\FBTS\APP_DATA\FB_TS.MDF; User ID=fbts; Password=fbts");

		con.Open();
		con.Close();
		return 0;
	}
}
