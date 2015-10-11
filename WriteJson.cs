using UnityEngine;
using System.IO;

// We're using the LitJson namespace!
using LitJson;


public class WriteJson : MonoBehaviour {
    // Create a Character instance called player
    public Character player = new Character(0, "Austin The Cowardly Wizard", 1337, false, new int[] { 7, 4, 8, 2, 5, 4 });

    // JsonData will hold the converted-to-json data
    private JsonData playerJson;
    // Use this for initialization
	void Start () {
        // Pass JsonMapper.ToJson method the player object (character instance). This converts the data to JSON format
        playerJson = JsonMapper.ToJson(player);

        // Now write the restulting data to our StreamingAssets folder
        File.WriteAllText(Application.streamingAssetsPath + "/Player.json", playerJson.ToString());
	}
}

// Example class
public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public bool Aggressive { get; set; }
    public int[] Stats { get; set; }

    public Character(int id, string name, int health, bool aggressive, int[] stats)
    {
        this.Id = id;
        this.Name = name;
        this.Health = health;
        this.Aggressive = aggressive;
        this.Stats = stats;
    }
}
