using UnityEngine;
using System.Collections;

public class countdownPanel : MonoBehaviour {

    Animator anim;
    public RectTransform cr;

    gameManager gm;

    void Awake()
    {
        anim = GetComponent<Animator>();
        GameObject g = GameObject.FindWithTag("questGameManager");
        if (g != null)
        {
            gm = g.GetComponent<gameManager>();
        }
    }

    public void OnEnable()
    {
        
    }

    public void panelOut()
    {
        StartCoroutine(panOut());
    }

    IEnumerator panOut()
    {
        anim = GetComponent<Animator>();
        anim.Play("out");
        yield return new WaitForSeconds(0.3f);
        //gm.startGame();
        yield return new WaitForSeconds(0.5f);
        anim.StopPlayback();
        cr.anchoredPosition = new Vector2(0, 115);
        gameObject.SetActive(false);
    }
}
