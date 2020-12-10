using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class HeroLoot : MonoBehaviour
{
    public List<string> LootTable = new List<string>();
    public int RandomNumber;
    public int ItemAmount;
    public string RolledItem;
    public string file;
    System.Random rng = new System.Random();
    void Start()
    {
        AddLoot();
    }
    public void AddLoot()
    {
        ReadFileAtLocation(); //Lees .csv uit om bestaande items om te zetten naar mogelijke drops
        string[] items = file.Split(","[0]);
        foreach (string item in items)
        {
            LootTable.Add(item); //add elk item id als een apart item in de loottable list.
        }       
    }
    public void GetLoot()
    {
        ItemAmount = LootTable.Count - 1; //pak aantal items in loottable en doe dit -1 om rekening the houden dat een list bij 0 begint.
        RandomNumber = rng.Next(0, ItemAmount); //Randomizer om item te kiezen uit LootTable.
        RolledItem = LootTable[RandomNumber]; //lees itemID uit van geslecteerde item uit de LootTable.
    }
    public void GiveLoot()
    {
        //hier komt code zodra inventory af is gebruik RolledItem als id voor het item dat gegeven moet worden.
    }
    private string getPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SilentRealms/Saves/" + "Loot.csv"; //pak locatie van de het bestand waar de loot in staat.
    }
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
            //straks nieuwe file maken in het geval dat file niet bestaat
        }

    }
}
