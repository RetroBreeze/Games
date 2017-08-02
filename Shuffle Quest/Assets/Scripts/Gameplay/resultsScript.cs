using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SIS;

public class resultsScript : MonoBehaviour {

    public Text yourScoreText;
    public Text scoreText;
    public Text speechText;
    
    public GameObject st;
    public GameObject buttons;

    Animator anim;
    Animator anim2;

    public RectTransform rp;
    public RectTransform[] contents;

    public GameObject countdown;

    public fadeManager fm;
    public gameManager gm;
    public characterManager cm;

    string badText;
    string normalText;
    string goodText;
    string greatText;

    void Awake()
    {
        anim = GetComponent<Animator>();
        anim2 = buttons.GetComponent<Animator>();
        GameObject f = GameObject.FindWithTag("fadeManager");
        if (f != null)
        {
            fm = f.GetComponent<fadeManager>();
        }

        GameObject g = GameObject.FindWithTag("gameManager");
        if (g != null)
        {
            gm = g.GetComponent<gameManager>();
        }
        GameObject c = GameObject.FindWithTag("character");
        if(c != null)
        {
            cm = c.GetComponent<characterManager>();
        }
    }

    void OnDisable()
    {
        rp.anchoredPosition = new Vector2(rp.anchoredPosition.x, -25);
        resetPos();
    }

	void OnEnable () {
        StartCoroutine(step1());
	}

    void resetPos()
    {
        foreach (RectTransform r in contents)
        {
            r.anchoredPosition = new Vector2(r.anchoredPosition.x, -852);
        }
    }

    IEnumerator step1()
    {
        //StartCoroutine(scoreT);
        gameParameters.playsTilAd--;
        PlayerPrefs.SetInt("playsTilAd", gameParameters.playsTilAd);
        anim.Play("newResults");
        StartCoroutine(scoreT());
        yield return new WaitForSeconds(0.3f);

        anim2.Play("in");
    }
    
    IEnumerator scoreT()
    {
        for (float t = 0; t < 5f; t += 0.1f)
        {
            yield return new WaitForSeconds(0.01f);
            int i = Random.Range(0, 100);
            scoreText.text = i.ToString();
        }
        setScore();
    }

    void setScore()
    {
        int s = gm.score; //change this to score when implemented.
        scoreText.text = s.ToString();
        //Debug.Log(gm.score);
       // Debug.Log(gameParameters.dialog[0].ToString());

        if (s >= 51)
        {
            int i = Random.Range(9, 11);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());
            cm.playHappy();
        }
        if (s <= 50)
        {
            int i = Random.Range(6, 8);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());

            //cm.playFail();
            cm.playHappy();
        }
        if (s <= 40)
        {
            int i = Random.Range(6, 8);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());
            cm.playHappy();
        }
        if (s <= 30)
        {
            int i = Random.Range(3, 5);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());
            cm.playIdle();
        }
        if (s <= 20)
        {
            int i = Random.Range(3, 5);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());
            cm.playIdle();
        }
        if (s <= 10)
        {
            int i = Random.Range(0, 2);
            speechText.text = gameParameters.dialog[i].ToString();
            Debug.Log(gameParameters.dialog[i].ToString());

            cm.playFail();
        }

    }

    public void resultsOutMenu()
    {
        StartCoroutine(resOut());

        
    }

    IEnumerator resOut()
    {
        // anim.Play("resultsPanelOut");
        //anim2.Play("out");
        //yield return new WaitForSeconds(0.6f);
        //buttons.SetActive(false);
        //gameObject.SetActive(false);
        cm.playHappy();
        gm.resetScore();
        fm.faderIn();
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("mainMenu");
    }

    public void resultsOutRetry()
    {
        StartCoroutine(retry());
    }

    IEnumerator retry()
    {
        cm.playIdle();
        anim.Play("newResultsOut");
        anim2.Play("out");
       

       // gm.gameIn();
        
        gm.resetScore();

                yield return new WaitForSeconds(0.5f);
                buttons.SetActive(false);
                gameObject.SetActive(false);
                Debug.Log("Plays til ad:" + gameParameters.playsTilAd);
                //gameParameters.playsTilAd--;
                PlayerPrefs.SetInt("playsTilAd", gameParameters.playsTilAd);
                gm.startSess();
                yield return new WaitForSeconds(0.5f);
                countdown.SetActive(true);
                // gm.shuffleDeck();      
    }

    public void resBackButton()
    {
        StartCoroutine(backToMenu());
    }

    IEnumerator backToMenu()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.5f);
        
    }

}
