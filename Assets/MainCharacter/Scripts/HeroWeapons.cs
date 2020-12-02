using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HeroWeapons : MonoBehaviour
{
    public string file;

    public int WeaponID;
    public string name;

    public float attackDamage;
    public float attackSpeed;
    public float weight;
    public float staminaModifier;

    // Start is called before the first frame update
    void Start()
    {
        // if (!File.Exists(getPath())){
        // 	Create();
        // } else {
        // 	LoadWeapon();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            LoadWeapon(1);
        }
    }

    //Load the stats
    void LoadWeapon(int id)
    {
        ReadFileAtLocation();

        string[] lines = file.Split('\n');

        for (var i = 0; i < lines.Length; i++){

        	string[] line = lines[i].Split(',');
        	var idd = int.Parse(line[0]);
        	if(id == idd) {
        	int.TryParse(line[0], out WeaponID);
            name = line[1];
            float.TryParse(line[2], out attackDamage);
            float.TryParse(line[3], out attackSpeed);
            float.TryParse(line[4], out weight);
            float.TryParse(line[5], out staminaModifier);
        }}
    }

        void Create()
    {
        string filePath = getPath();

        StreamWriter writer = new StreamWriter(filePath);

        writer.Flush();
        writer.Close();
    }

    //Returns path of csv file.
    private string getPath()
    {
        return Application.dataPath + "/CSV/weapons.csv";
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
    }
}
