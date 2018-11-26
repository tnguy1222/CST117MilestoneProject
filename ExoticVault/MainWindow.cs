using System;
using System.IO;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    public void OnButton2Clicked(object sender, EventArgs e)
    {
        string[] strName = { "Nissan GTR" };
        string[] strID = { "00001" };

        for (int i = 0; i < strName.Length; i++)
        {
            entry1.Text = strName[i];
        }
        for (int j = 0; j < strID.Length; j++)
        {
            entry2.Text = strID[j];
        }
    }
    public void OnButton1Clicked(object sender, EventArgs e)
    {
        string[] strName = { "Nissan GTR" };
        string[] strID = { "00001" };
        addName(strName);
        //addID(strID);
    }

    void addName(string[] strName)
    {
        string productName = " ";
        string[] name = new string[strName.Length];

        for (int i = 0; i < strName.Length; i++)
        {
            productName = strName[i];
            name[i] = productName;
            System.IO.File.WriteAllLines(@"/Users/nguyenphanjim/Projects/ExoticVault/ExoticVault/ProductName.txt", name);
        }
    }
}
