using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class MathOperationPerf
{
    static private TimeSpan _cacheDuration = new TimeSpan(0, 0, 5, 0);
    static private DateTime _refreshCacheAfter = DateTime.MinValue;
    static private DataView _cache = null;

    static public DataView Fetch()
    {
        DateTime now = DateTime.Now;
        if (now > _refreshCacheAfter)
        {
            _refreshCacheAfter = now + _cacheDuration;

            DataTable dt = new DataTable();

            DataColumn col = new DataColumn("Operation", Type.GetType("System.String"));
            dt.Columns.Add(col);
            col = new DataColumn("Reps", Type.GetType("System.Int32"));
            dt.Columns.Add(col);
            col = new DataColumn("Duration", Type.GetType("System.Int32"));
            dt.Columns.Add(col);
            col = new DataColumn("Average", Type.GetType("System.Double"));
            dt.Columns.Add(col);

            int tempInt = 0;
            long tempLong = 0;
            double tempDouble = 0.0;
            string[] operations = { "Abs", "Acos", "Asin", "Atan", "Atan2", "BigMul", "Ceiling", "Cos", "Cosh", "DivRem", "Exp", "Floor", "IEEERemainder", "Log", "Log10", "Max", "Min", "Pow", "Round", "Sign", "Sin", "Sinh", "Sqrt", "Tan", "Tanh", "Truncate" };
            foreach (string operation in operations)
            {
                DataRow row = dt.NewRow();
                row["Operation"] = operation;
                int reps = 0;
                DateTime start = DateTime.Now;
                DateTime goUntil = start.AddMilliseconds(30);
                while (DateTime.Now < goUntil)
                {
                    switch (operation)
                    {
                        case "Abs":
                            tempInt = Math.Abs(1);
                            break;
                        case "Acos":
                            tempDouble = Math.Acos(0.5);
                            break;
                        case "Asin":
                            double d = Math.Asin(0.5);
                            break;
                        case "Atan":
                            tempDouble = Math.Atan(0.5);
                            break;
                        case "Atan2":
                            tempDouble = Math.Atan2(10.5, 100.5);
                            break;
                        case "BigMul":
                            tempLong = Math.BigMul(123, 456);
                            break;
                        case "Ceiling":
                            tempDouble = Math.Ceiling(1.5);
                            break;
                        case "Cos":
                            tempDouble = Math.Cos(1.5);
                            break;
                        case "Cosh":
                            tempDouble = Math.Cosh(1.5);
                            break;
                        case "DivRem":
                            tempLong = Math.DivRem(5, 2, out tempLong);
                            break;
                        case "Exp":
                            tempDouble = Math.Exp(1.5);
                            break;
                        case "Floor":
                            tempDouble = Math.Floor(1.5);
                            break;
                        case "IEEERemainder":
                            tempDouble = Math.IEEERemainder(10.0, 3.0);
                            break;
                        case "Log":
                            tempDouble = Math.Log(1.5);
                            break;
                        case "Log10":
                            tempDouble = Math.Log10(1.5);
                            break;
                        case "Max":
                            tempDouble = Math.Max(1.5, 2.5);
                            break;
                        case "Min":
                            tempDouble = Math.Min(1.5, 2.5);
                            break;
                        case "Pow":
                            tempDouble = Math.Pow(1.5, 2.5);
                            break;
                        case "Round":
                            tempDouble = Math.Round(2.4);
                            break;
                        case "Sign":
                            tempInt = Math.Sign(1);
                            break;
                        case "Sin":
                            tempDouble = Math.Sin(1.5);
                            break;
                        case "Sinh":
                            tempDouble = Math.Sinh(1.5);
                            break;
                        case "Sqrt":
                            tempDouble = Math.Sqrt(1.5);
                            break;
                        case "Tan":
                            tempDouble = Math.Tan(1.5);
                            break;
                        case "Tanh":
                            tempDouble = Math.Tanh(1.5);
                            break;
                        case "Truncate":
                            tempDouble = Math.Truncate(1.5);
                            break;
                    }
                    reps++;
                }
                TimeSpan duration = new TimeSpan(DateTime.Now.Ticks - start.Ticks);
                row["Reps"] = reps;
                row["Duration"] = duration.TotalMilliseconds; // milliseconds
                row["Average"] = (duration.TotalMilliseconds * 1000) / reps; // microseconds
                dt.Rows.Add(row);
            }

            dt.DefaultView.Sort = "Operation ASC";
            _cache = dt.DefaultView;
        }

        return _cache;
    }
}

