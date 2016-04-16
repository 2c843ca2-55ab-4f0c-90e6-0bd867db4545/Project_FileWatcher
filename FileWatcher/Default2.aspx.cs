using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string filename = "ListProduct";
        
        if (Application["FileDet"] != null)
        {
            Hashtable dt = (Hashtable)Application["FileDet"];
            if (dt.ContainsKey(filename+".xml"))
            {
                Response.Write(File.ReadAllText("E:\\Temp\\ListProduct.xml"));
                Response.End();
            }
        }
    }
}