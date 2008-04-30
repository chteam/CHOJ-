using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class ProcessStats
{
	static public DataView Fetch()
	{
        DateTime now = DateTime.Now;
        DataTable dt = new DataTable();
        
        DataColumn col = new DataColumn("ProcessName", Type.GetType("System.String"));
        dt.Columns.Add(col);
        col = new DataColumn("Id", Type.GetType("System.Int32"));
        dt.Columns.Add(col);
        col = new DataColumn("HandleCount", Type.GetType("System.Int32"));
        dt.Columns.Add(col);
        col = new DataColumn("Threads", Type.GetType("System.Int32"));
        dt.Columns.Add(col);
        col = new DataColumn("RunningTime", Type.GetType("System.Int32"));
        dt.Columns.Add(col);
        col = new DataColumn("ProcessorTime", Type.GetType("System.Int32"));
        dt.Columns.Add(col);
        col = new DataColumn("VirtualMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("PeakVirtualMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("WorkingSet", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("PeakWorkingSet", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("PagedMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("PeakPagedMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("NonpagedSystemMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);
        col = new DataColumn("PagedSystemMemorySize", Type.GetType("System.Int64"));
        dt.Columns.Add(col);

        System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
        for (int i = 0; i < processes.Length; i++)
        {
            try
            {
                DataRow row = dt.NewRow();
                row["ProcessName"] = processes[i].ProcessName;
                row["Id"] = processes[i].Id;
                row["HandleCount"] = processes[i].HandleCount;
                row["Threads"] = processes[i].Threads.Count;
                row["RunningTime"] = (now - processes[i].StartTime).TotalSeconds;
                row["ProcessorTime"] = processes[i].TotalProcessorTime.TotalSeconds;
                row["VirtualMemorySize"] = processes[i].VirtualMemorySize64 / 1000;
                row["PeakVirtualMemorySize"] = processes[i].PeakVirtualMemorySize64 / 1000;
                row["WorkingSet"] = processes[i].WorkingSet64 / 1000;
                row["PeakWorkingSet"] = processes[i].PeakWorkingSet64 / 1000;
                row["PagedMemorySize"] = processes[i].PagedMemorySize64 / 1000;
                row["PeakPagedMemorySize"] = processes[i].PeakPagedMemorySize64 / 1000;
                row["NonpagedSystemMemorySize"] = processes[i].NonpagedSystemMemorySize64 / 1000;
                row["PagedSystemMemorySize"] = processes[i].PagedSystemMemorySize64 / 1000;

                dt.Rows.Add(row);
            }
            catch (Exception ex)
            {
            }
        }

        dt.DefaultView.Sort = "ProcessName ASC";

        return dt.DefaultView;
    }
}
