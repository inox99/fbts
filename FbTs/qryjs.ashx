<%@ WebHandler Language="C#" Class="h1" %>

using System;
using System.Web;

public class h1 : IHttpHandler
{
	void getJsSpiele(HttpResponse hRes)
	{
		hRes.ContentType = "text/plain";
	}
	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "text/plain";
		context.Response.Expires = 0;
		try
		{
			string cmd = context.Request.Params["cmd"];
			if (string.Compare(cmd, "spiele", true) == 0)
			{
			}
		}
		catch (Exception ex)
		{

		}
		//context.Response.Write("Hello World");
	}
	public bool IsReusable
	{
		get
		{
			return false;
		}
	}

}