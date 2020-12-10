using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HeroCurrency : MonoBehaviour
{
    public string file;

    public int currency; //DevTool

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(getPath())){
        	CreateCurrency();
            LoadCurrency();
        }
        else
        {
            LoadCurrency();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Load the currency
    void LoadCurrency()
    {
        ReadFileAtLocation();

        string[] lines = file.Split("/n"[0]);
        for (var i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(","[0]);

            int.TryParse(parts[0], out currency);
        }
    }

    //Save the currency
    public void SaveCurrency()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine(currency);
        writer.Flush();
        writer.Close();
    }

    //Creates new currency.csv file
    void CreateCurrency()
    {
        string filePath = getPath();
        
        StreamWriter writer = new StreamWriter(filePath);
        
        writer.WriteLine("0");
        writer.Flush();
        writer.Close();
    }

    //Returns path of csv file.
    private string getPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SilentRealms/Saves/" + "Currency.csv";
    }

    //Reads file
    public void ReadFileAtLocation()
    {
        file = "";

        if (File.Exists(getPath()))
        {
            FileStream fileStream = new FileStream(getPath(), FileMode.Open, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fileStream);
            file = read.ReadToEnd();
        }
        else
        {
            SaveCurrency();
        }

    }
}
