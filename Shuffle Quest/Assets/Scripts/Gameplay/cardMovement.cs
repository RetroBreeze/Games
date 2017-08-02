using UnityEngine;
using System.Collections;

public class cardMovement : MonoBehaviour {

    Vector3 currentPos;
    Vector3 moveTo;

    float moveAmount = 0.3f;

    float moveTime;
    bool moving = false;
    float distanceToMove = 0.3f;

    float timeForLerp = 0.1f;
    bool isLerping;
    float timeStarted;

    int lerpBuffer;

    float percentageComplete;

    Animator anim;
    ParticleSystem part;

    void Awake()
    {        
        anim = GetComponent<Animator>();
        currentPos = transform.position;
        updatePos();
    }

    public void destroyCard()
    {
        StartCoroutine(cardOut());
    }

    public void cardWobble()
    {
        anim.Play("wobble");
    }

    IEnumerator cardOut()
    {

        anim.Play("cardOut");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }

    public void arrowCard()
    {
        StartCoroutine(arrowOut());
    }

    IEnumerator arrowOut()
    {
        anim.Play("arrowOut");
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }

    void updatePos()
    {
        currentPos = transform.position;
        moveTo = currentPos;
        moveTo.y -= moveAmount;
        moveTo.z -= moveAmount;
    }

    public void move()
    {
        if (isLerping)
        {
            lerpBuffer++;
        }
        if (!isLerping)
        {
            startL();
        }
      
    }

    void startL()
    {
        isLerping = true;
        timeStarted = Time.time;
        Debug.Log("Moving");
       
    }

    void FixedUpdate()
    {
        if ((!isLerping) && (lerpBuffer > 0))
            {
                move();
                lerpBuffer--;
            }
        
        if (isLerping)
        {
            float timeSinceStarted = Time.time - timeStarted;
            percentageComplete = timeSinceStarted / timeForLerp;

            transform.position = Vector3.Lerp(currentPos, moveTo, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                updatePos();
                isLerping = false;
            }
        }
    }
}
