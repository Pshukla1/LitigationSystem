using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
public class CommonFunction
{
	public CommonFunction()
	{
		//
		// TODO: Add constructor logic here
		//

        
	}

    #region For Compare  till date to from date create by vishal 05-11-2012

    public string ComparedateValidation(string strfromdate, string strtilldate)
    {
        DateTime dt1 = Convert.ToDateTime(strfromdate);
        string strdt1 = DateTime.Parse(dt1.ToString()).ToString("dd-MM-yyyy");
        DateTime dt2 = Convert.ToDateTime(strtilldate);
        string strdt2 = DateTime.Parse(dt2.ToString()).ToString("dd-MM-yyyy");
        TimeSpan diff = dt2.Subtract(dt1);
        string strrelationship = ""; ;
        if (diff.ToString().Contains("-"))
        {
            strrelationship = "Date must be greater than from Date !";

        }
        return strrelationship;
    }
    #endregion

    public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, 1);
    }
    public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
    {
        DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
        return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
    }
    #region For validation date format dd-MMM-yyyy create by vishal 05-11-2012

    public bool fnValidateDateFormat(string strDate)
    {
        Boolean Bflag = true;
        Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

        Match mtStartDt = Regex.Match(strDate, regexDt.ToString());

        if (!mtStartDt.Success)
        {
            Bflag = false;

        }
        return Bflag;
    }

    #endregion

}