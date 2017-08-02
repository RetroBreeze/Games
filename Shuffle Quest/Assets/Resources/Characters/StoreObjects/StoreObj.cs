using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreObj : MonoBehaviour
{

    public GameObject IAPManager;
    purchasePrompt pp;

    bool isPurchased;

    public string characterName = "Character Name Here";
    public int cost = 50;
    public string description;

    private void Awake()
    {
        pp = IAPManager.GetComponent<purchasePrompt>();
    }

    public void OnClick()
    {

        if (!isPurchased)
        {
            pp.populate(description);
        }

    }

}

