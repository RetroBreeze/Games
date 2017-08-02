using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

    public GameObject menuMainPanel;
    public GameObject menuButtonPanel;

    public GameObject creditsPanel;
    public GameObject creditsBack;

    public GameObject characterPos;
    characterManager anim;

    string character;

  //  gameManager gm;
    fadeManager fm;

   
    // Buttons //

	void Awake ()
    {
        GameObject f = GameObject.FindWithTag("fadeManager");
        if(f != null)
        {
            fm = f.GetComponent<fadeManager>();
        }
        
	}

    void Start()
    {
        StartCoroutine(start2());
        //gameParameters.currentCharacter = "Bann";
        //character = gameParameters.currentCharacter;
        if (gameParameters.currentCharacter != null)
        {
            
        }
        if (PlayerPrefs.HasKey("currentCharacter"))
        {
            gameParameters.currentCharacter = PlayerPrefs.GetString("currentCharacter");
        }
        if (!PlayerPrefs.HasKey("currentCharacter"))
        {
            gameParameters.currentCharacter = "Finnikin";
            PlayerPrefs.SetString("currentCharacter", gameParameters.currentCharacter);
        }
        string str = ("Characters/" + PlayerPrefs.GetString("currentCharacter") + "/theme");
        Debug.Log(str);
        GameObject bg = Instantiate(Resources.Load(str), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        GameObject chara = GameObject.FindWithTag("character");
        anim = chara.GetComponent<characterManager>();
        chara.transform.parent = characterPos.transform;
        anim.playHappy();
        StartCoroutine(start2());
       // chara.transform.position = new Vector2(0, 0);
        
        //chara.SetActive(false);
    }
    
    IEnumerator start2()
    {
        yield return new WaitForSeconds(1.2f);
        anim.playIdle();
        
    }

    public void startShortGame ()
    {
        StartCoroutine(toShort());
    }

    IEnumerator toShort()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("gameloop");
        //Application.LoadLevel("gameloop");    
    }

    public void backToMenu()
    {
     //   gm.resetScore();
        menuIn();
    }

    public void goToStore()
    {
        StartCoroutine(toStore());
    }

    IEnumerator toStore()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("store");
        //Application.LoadLevel("store");
        //  yield return new WaitForSeconds(0.3f);
        //fm.faderOut();
    }

    public void goToCollection ()
    {
        StartCoroutine(toCollection());
    }

    IEnumerator toCollection()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("collection");
        //Application.LoadLevel("collection");
      //  yield return new WaitForSeconds(0.3f);
        //fm.faderOut();
    }

    public void goToCredits()
    {
        StartCoroutine(toCredits());
    }

    IEnumerator toCredits()
    {
        menuOut();
        yield return new WaitForSeconds(0.5f);
        creditsIn();
    }

    public void creditsBackButton()
    {
        StartCoroutine(credToMenu());
    }

    IEnumerator credToMenu()
    {
        creditsOut();
        yield return new WaitForSeconds(0.5f);
        menuIn();
    }

    public void rateButton()
    {
        Application.OpenURL("CHANGETHIS");
    }

    public void websiteButton()
    {
        Application.OpenURL("http://www.playkiseki.com");
    }

    public void mainTwitter()
    {
        Application.OpenURL("https://twitter.com/PlayKiseki");
    }

    public void yuuTwitter()
    {
        Application.OpenURL("https://twitter.com/YuuPKSK");
    }

    public void shinTwitter()
    {
        Application.OpenURL("https://twitter.com/ShinPKSK");
    }

    public void sagasuLink()
    {
        Application.OpenURL("https://itunes.apple.com/us/app/sagasu/id980134493?mt=8");
    }

    // Object animations //

   

    public void menuIn()
    {
        StartCoroutine(menIn());
    }

    IEnumerator menIn()
    {
        menuMainPanel.SetActive(true);
        menuButtonPanel.SetActive(true);
        Animator anim = menuMainPanel.GetComponent<Animator>();
        anim.Play("in");

        
        Animator anim2 = menuButtonPanel.GetComponent<Animator>();
        anim2.Play("in");

        yield return new WaitForSeconds(0.8f);
    }

    public void menuOut()
    {
        StartCoroutine(menOut());
    }

    IEnumerator menOut()
    {
        
        Animator anim = menuMainPanel.GetComponent<Animator>();
        Animator anim2 = menuButtonPanel.GetComponent<Animator>();
        anim.Play("out");

        
        anim2.Play("out");

        yield return new WaitForSeconds(0.8f);

        menuButtonPanel.SetActive(false);
        menuMainPanel.SetActive(false);
    }

    public void creditsIn()
    {
        StartCoroutine(credsIn());
    }

    IEnumerator credsIn()
    {
        creditsPanel.SetActive(true);
        creditsBack.SetActive(true);
        Animator anim = creditsPanel.GetComponent<Animator>();
        Animator anim2 = creditsBack.GetComponent<Animator>();
        anim.Play("in");
        anim2.Play("in");
        yield break;
    }

    public void creditsOut()
    {
        StartCoroutine(credsOut());
    }

    IEnumerator credsOut()
    {
        Animator anim = creditsPanel.GetComponent<Animator>();
        Animator anim2 = creditsBack.GetComponent<Animator>();
        anim.Play("out");
        anim2.Play("out");
        yield return new WaitForSeconds(0.6f);
        creditsPanel.SetActive(false);
        creditsBack.SetActive(false);
    }

  /*  public void gameIn()
    {
        StartCoroutine(gaIn());
    }

    IEnumerator gaIn()
    {
        gamePanel.SetActive(true);
        gameButtonPanel.SetActive(true);
        //gameP.anchoredPosition.y = new Vector2(0,0);
        Animator anim = gamePanel.GetComponent<Animator>();
        Animator anim2 = gameButtonPanel.GetComponent<Animator>();
        anim.Play("in");
        anim2.Play("in");
        yield return new WaitForSeconds(0.8f);
    }

    public void gameOut()
    {
        StartCoroutine(gaOut());
    }

    IEnumerator gaOut()
    {
        Animator anim = gamePanel.GetComponent<Animator>();
        Animator anim2 = gameButtonPanel.GetComponent<Animator>();
        anim.Play("out");
        anim2.Play("out");
        yield return new WaitForSeconds(0.8f);
        gameP.anchoredPosition = new Vector2(gameP.anchoredPosition.x, 0);
        gamePanel.SetActive(false);
        gameButtonPanel.SetActive(false);
       
       
        resultsIn();
    }

    public void resultsIn()
    {
        
        resultsPanel.SetActive(true);
        resultsButtonPanel.SetActive(true);
    }

   */ 
}
