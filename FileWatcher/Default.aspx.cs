using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.IO;
using System.Collections;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public static Hashtable dt = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = "E:\\Temp\\";
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.EnableRaisingEvents = true;
        watcher.Filter = "*.xml";

    }

    private void OnChanged(object source, FileSystemEventArgs e)
    {
        //FileSystemWatcher et = (FileSystemWatcher)source;
        // Specify what is done when a file is changed, created, or deleted.
        //Console.WriteLine("File: " + e.Name + " " + e.ChangeType);
        string date = File.GetLastWriteTime(e.FullPath).ToString();
        if (!dt.ContainsKey(e.Name))
            dt.Add(e.Name, date);
        else
            dt[e.Name] = date;

        Application["FileDet"] = dt;
    }
}