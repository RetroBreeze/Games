using UnityEngine;
using System.Collections;

public class characterManager : MonoBehaviour {

    Animator anim;
    public bool offScreen;
    
	void Awake ()
    {
        anim = GetComponent<Animator>();
	}

    public void playEntry()
    {
        anim.Play("entry");
        offScreen = false;
    }

    public void playExit()
    {
        anim.Play("exit");
        offScreen = true;
    }

    public void playIdle()
    {
        anim.SetBool("idle", true);
        anim.SetBool("timer", false);
        anim.SetBool("happy", false);
        anim.SetBool("fail", false);
    }

    public void playTime()
    {
        anim.SetBool("timer", true);
        anim.SetBool("idle", false);
        anim.SetBool("happy", false);
        anim.SetBool("fail", false);
    }

    public void playHappy()
    {
        anim.SetBool("happy", true);
        anim.SetBool("idle", false);
        anim.SetBool("timer", false);
        anim.SetBool("fail", false);
    }

    public void playFail()
    {
        anim.SetBool("fail", true);
        anim.SetBool("idle", false);
        anim.SetBool("timer", false);
        anim.SetBool("happy", false);

    }

	void Update ()
    {
	
	}
}
