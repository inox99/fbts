using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Text;

using Newtonsoft.Json;

/// <summary>
/// Summary description for DbFbTs
/// http://james.newtonking.com/json/help/index.html
/// </summary>
public static class DbFbTs
{
	public static string jsSpiele()
	{
		SqlConnection con = null;
		SqlCommand cmd = null;
		SqlDataReader rdr = null;
		JsonWriter jtw = null;
		StringBuilder sb = new StringBuilder();
		StringWriter sw = new StringWriter(sb);

		try
		{
			con = new SqlConnection(@"Data Source=DDAS0201\SQL_SERVER_PU03;Initial Catalog=FB_TS;Integrated Security=True");
			con.Open();
			cmd = new SqlCommand("SELECT * FROM FB_SPIELE ORDER BY DT", con);
			rdr = cmd.ExecuteReader();
			jtw = new JsonTextWriter(sw);

			jtw.WriteStartArray();
			while (rdr.Read())
			{
				jtw.WriteStartObject();
				int fields = rdr.FieldCount;
				for (int i = 0; i < fields; i++)
				{
					jtw.WritePropertyName(rdr.GetName(i));
					jtw.WriteValue(rdr[i]);
				}
				jtw.WriteEndObject();
			}
			jtw.WriteEndArray();
			sw.Flush();
			return sw.ToString();
		}
		finally
		{
			if (jtw != null) jtw.Close();
			if (sw != null) sw.Dispose();
			if (rdr != null) rdr.Dispose();
			if (cmd != null) cmd.Dispose();
			if (con != null) con.Dispose();
		}
	}
}