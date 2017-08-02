using UnityEngine;
using System.Collections;

public class fadeManager : MonoBehaviour {

    public GameObject fadeCanvas;
    public GameObject fader;

    Animator anim;

    void awake()
    {
        anim = fader.GetComponent<Animator>();
    }

    void Update()
    {
     /*   if (c.worldCamera == null)
        {
            c.worldCamera = Camera.main;
        }
      */
    }

    public void faderOut()
    {
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        anim = fader.GetComponent<Animator>();
        anim.Play("out");
        yield return new WaitForSeconds(1f);
        fader.SetActive(false);
    }

    public void faderIn()
    {
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        fader.SetActive(true);
        anim = fader.GetComponent<Animator>();
        anim.Play("in");
        yield return new WaitForSeconds(1);
    }
}
