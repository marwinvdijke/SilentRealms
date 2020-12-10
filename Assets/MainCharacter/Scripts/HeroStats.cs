using System;
using System.IO;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    public string file;

    HeroHealth heroHealth;
    HeroStamina heroStamina;



    public float attackMultiplier; //DevTool
    float attackSpeed;
    public float armor; //DevTool
    public int maxHealth; //DevTool
    float currentHealth;
    float HealthRegen;

    int CurrentStamina;
    public int maxStamina; //DevTool
    float staminaRegen;
    float staminaCD;

    int floathealth;

    public float movementSpeed; //DevTool

    // Start is called before the first frame update
    void Start()
    {
    	heroHealth = gameObject.GetComponent<HeroHealth>();
        heroStamina = gameObject.GetComponent<HeroStamina>();
        if (!File.Exists(getPath())){
        	CreateStats();
        } else {
        	LoadStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("q")){
        //     SaveStats();
        // }
        // if (Input.GetKeyDown("e"))
        // {
        //     LoadStats();
        // }
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
            int.TryParse(parts[2], out maxHealth);
            int.TryParse(parts[3], out maxStamina);
            float.TryParse(parts[4], out movementSpeed);
            heroHealth.SetHealth(maxHealth);
            heroStamina.SetStamina(maxStamina);
           


        }
    }

    //Save the stats
    public void SaveStats()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine(attackMultiplier + "," + armor + "," + maxHealth + "," + maxStamina + "," + movementSpeed);
        writer.Flush();
        writer.Close();
    }

        void CreateStats()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("1" + "," + "1" + "," + "1" + "," + "1" + "," + "1");
        writer.Flush();
        writer.Close();
        
        LoadStats();
    }

    //Returns path of csv file.
    private string getPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SilentRealms/Saves/" + "Stats.csv";
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
