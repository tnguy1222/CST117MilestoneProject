using System;
using System.Collections;
using System.Collections.Generic;
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

    //Add button functiob
    public void OnButton1Clicked(object sender, EventArgs e)
    {
        string stringProduct;

        string productIDArray = entry1.Text;
        string productName = entry2.Text;
        string productPrice = entry3.Text;
        string productQuantity = entry5.Text;
        string[] productArray = { productIDArray, productName, productPrice , productQuantity};
        stringProduct = Convert.ToString(productArray);

        System.IO.File.AppendAllLines(@"/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt", productArray);

        string output = System.IO.File.ReadAllText("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        textview1.Buffer.Text = output;
    }

    //Remove button function
    private void OnButton2Clicked(object sender, EventArgs e)
    {

        string input;
        input = entry1.Text;
        string[] lines = File.ReadAllLines("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        string clearLines = " ";
        for (int i = 0; i < lines.Length; i++)
        {
            if(lines[i].Contains(input))
            {

                lines[i] = " ";
                lines[i + 1] = " ";
                lines[i + 2] = " ";
                lines[i + 3] = " ";

            }

        }
        System.IO.File.WriteAllText(@"/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt", clearLines);
        System.IO.File.AppendAllLines(@"/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt", lines);

        string output = System.IO.File.ReadAllText("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        textview1.Buffer.Text = output;
    }
    //Search button function
    public void OnButton3Clicked(object sender, EventArgs e)
    {
        string input;
        string output1;
        string output2;
        string output3;
        string output4;


        input = entry1.Text;

        string[] lines = File.ReadAllLines("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
   
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(input))
            {
                output1 = Convert.ToString(lines[i]);
                output2 = Convert.ToString(lines[i + 1]);
                output3 = Convert.ToString(lines[i + 2]);
                output4 = Convert.ToString(lines[i + 3]);

                entry1.Text = input;
                entry2.Text = output2;
                entry3.Text = output3;
                entry5.Text = output4;

                textview1.Buffer.Text = "Product is found in the system";
            }
        }
    }
    //Display all button function
    public void OnButton4Clicked(object sender, EventArgs e)
    {
        string output = System.IO.File.ReadAllText("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        textview1.Buffer.Text = output;
    }

    //Update function button
    public void OnButton7Clicked(object sender, EventArgs e)
    {
        string input;
        input = entry1.Text;
        string clearLines = " ";
        string newProductName = entry2.Text;
        string newProductPrice = entry3.Text;
        string newProductQuantity = entry5.Text;

        string[] lines = File.ReadAllLines("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(input))
            {
                lines[i] = input;
                lines[i + 1] = newProductName;
                lines[i + 2] = newProductPrice;
                lines[i + 3] = newProductQuantity;
            }
        }
        System.IO.File.WriteAllText(@"/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt", clearLines);
        System.IO.File.AppendAllLines(@"/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt", lines);

        string output = System.IO.File.ReadAllText("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        textview1.Buffer.Text = output;

    }

    public void OnButton8Clicked(object sender, EventArgs e)
    {
        int totalInventory = 0;
        int product=0;
        int price = 0;
        int quantity = 0;
        int quantitysum = 0;

        string[] lines = File.ReadAllLines("/Users/nguyenphanjim/Projects/InventorySystem/Inventory.txt");
        for (int i = 2; i < lines.Length; i+=4 )
        {
            price = Convert.ToInt32(lines[i]);
            for (int j = 3; j < lines.Length; j+=4)
            {
                quantity = Convert.ToInt32(lines[j]);
                product = quantity * price;

            }

            totalInventory = totalInventory + product;
            quantitysum += quantity;
        }

        textview1.Buffer.Text = "The inventory has " + quantitysum + " worth " + totalInventory + " dollars $";

    }
    //Clear Box
    public void OnButton5Clicked(object sender, EventArgs e)
    {
        entry1.Text = " ";
        entry2.Text = " ";
        entry3.Text = " ";
        textview1.Buffer.Text = " ";
        entry5.Text = " ";

    }
    //Quit
    public void OnButton6Clicked(object sender, EventArgs e)
    {
        Application.Quit();
    }


}
