using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class purchasePrompt : MonoBehaviour {

    public Text fullName;
    public Text price;
    int globalPrice = 1000;
    public Text textBox;

    public void populate(string description)
    {
        fullName.text = description;
        price.text = globalPrice.ToString();
        textBox.text = "Would you like to purchase " + fullName + "?";
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
