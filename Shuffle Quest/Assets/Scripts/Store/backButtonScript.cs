using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backButtonScript : MonoBehaviour {

    fadeManager fm;
	// Use this for initialization
	void Start () {
        GameObject f = GameObject.FindWithTag("fadeManager");
        if(f != null)
        {
            fm = f.GetComponent<fadeManager>();
        }
	}

    public void back()
    {
        StartCoroutine(faderOut());
       
    }

    IEnumerator faderOut()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("mainMenu");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
