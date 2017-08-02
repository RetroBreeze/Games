using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdownScript : MonoBehaviour {

    Text t;

    public Color32 red;
    public Color32 yellow;
    public Color32 blue;

    public GameObject countdownPanel;

    Animator anim;
    gameManager gm;
    public countdownPanel cp;
    

	// Use this for initialization
	void Awake () {
        t = GetComponent<Text>();
        anim = GetComponent<Animator>();

        GameObject g = GameObject.FindWithTag("gameManager");
        if (g != null)
        {
            gm = g.GetComponent<gameManager>();
        }
	}

    void OnEnable()
    {
       startCountdown1();
    }

    public void startCountdown1()
    {
        StartCoroutine(countdown1());
    }

    IEnumerator countdown1()
    {
       t.text = "3";
       t.fontSize = 150;
       t.color = red;
       anim.Play("countdown1");
       yield return new WaitForSeconds(0.5f);
       startCountdown2();
    }

    public void startCountdown2()
    {
        StartCoroutine(countdown2());
    }

    IEnumerator countdown2()
    {
        t.text = "2";
        t.fontSize = 150;
        t.color = yellow;
        anim.Play("countdown2");
        yield return new WaitForSeconds(0.5f);
        startCountdown3();
    }

    public void startCountdown3()
    {
        StartCoroutine(countdown3());
    }

    IEnumerator countdown3()
    {
        t.text = "1";
        t.fontSize = 150;
        t.color = blue;
        anim.Play("countdown3");
        yield return new WaitForSeconds(0.5f);
        startCountdown4();
    }

    public void startCountdown4()
    {
        StartCoroutine(countdown4());
    }

    IEnumerator countdown4 ()
    {
        t.text = "GO!";
        t.fontSize = 80;
        t.color = blue;
        anim.Play("go");
        yield return new WaitForSeconds(0.5f);        
        cp.panelOut();
        gm.startTimer();        
    }
}
