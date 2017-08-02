using UnityEngine;
using UnityEditor;
using SIS;
using System.Collections;

public class dbScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void add()
    {
        DBManager.IncreaseFunds("coins", 1000);
    }

    [MenuItem("Custom/Erase Database")]
    public void eraseDatabase()
    {
        DBManager.ClearAll();
        PlayerPrefs.DeleteAll();
    }

    public void purchase()
    {
        DBManager.SetToPurchased("removeAds");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
