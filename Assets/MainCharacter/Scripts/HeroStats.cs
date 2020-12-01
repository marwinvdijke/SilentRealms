using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public string file;

    public float attackMultiplier; //DevTool
    float attackSpeed;
    public float armor; //DevTool
    public float maxHealth; //DevTool
    float currentHealth;
    float HealthRegen;

    float currentStamina;
    public float maxStamina; //DevTool
    float staminaRegen;
    float staminaCD;

    public float movementSpeed; //DevTool

    // Start is called before the first frame update
    void Start()
    {
        LoadStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")){
            SaveStats();
        }
        if (Input.GetKeyDown("e"))
        {
            LoadStats();
        }
    }

    //Load the stats
    void LoadStats()
    {
        ReadFileAtLocation();

        string[] lines = file.Split("/n"[0]);
        for (var i = 0; i < lines.Length; i++)
        {

            string[] parts = lines[i].Split(","[0]);

            float.TryParse(parts[0], out attackMultiplier);
            float.TryParse(parts[1], out armor);
            float.TryParse(parts[2], out maxHealth);
            float.TryParse(parts[3], out maxStamina);
            float.TryParse(parts[4], out movementSpeed);
        }
    }

    //Save the stats
    void SaveStats()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine(attackMultiplier + "," + armor + "," + maxHealth + "," + maxStamina + "," + movementSpeed);
        writer.Flush();
        writer.Close();
    }

    //Returns path of csv file.
    private string getPath()
    {
        return Application.dataPath + "/CSV/stats.csv";
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
        } else
        {
            SaveStats();
        }

    }

}
