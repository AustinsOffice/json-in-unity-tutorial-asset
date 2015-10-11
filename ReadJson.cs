using UnityEngine;
using System.IO;

// We're using the LitJson namespace!
using LitJson;

public class ReadJson : MonoBehaviour {
    // String that we load our raw text data into
    private string jsonString;

    // JsonData object that we use to store the data after we convert it to JSON
    private JsonData itemData;

	void Start () {
        /*
         * 1. Read the JSON file in, store it in jsonString
         * 2. We then take that JSON-style string and run it through the JsonMapper.ToObect method
         *    to convert it to a JSON object. (the result can be parsed as a dictionary)
         */
        jsonString = File.ReadAllText(Application.streamingAssetsPath + "/Items.json");
        itemData = JsonMapper.ToObject(jsonString);

        // Example showing how to access certain values from the new JSON object
        Debug.Log(itemData["Weapons"][1]["name"]);

        // Example showing our GetItem method in practice (pass the name value to the array object, we get the correct response)
        Debug.Log(GetItem("light_rifle", "Weapons")["power"]);
	}
	

    // This handles querying the data to find the item we want
    JsonData GetItem(string name, string type)
    {
        // Let's look through each item of the type value that we gave the method
        for (int i = 0; i < itemData[type].Count; i++)
        {
            // If we find one by that name (or slug) then we'll just simply return it
            if (itemData[type][i]["name"].ToString() == name || itemData[type][i]["slug"].ToString() == name)
                return itemData[type][i];
        }

        // If we didn't find anything, simply return it
        return null;
    }
}
