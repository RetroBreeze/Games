using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using SIS;
using UnityEngine.Analytics;

public class gameManager : MonoBehaviour
{

    public GameObject choicePanel;
    public GameObject gamePanelObj;
    public GameObject gameButtonPanel;
   

    public GameObject magicButton;

    public RectTransform gameP;

    public GameObject resultsPanel;
    public GameObject resultsButtonPanel;

    public bool gameplayActive = false;
    public List<int> deck = new List<int>();
    public List<GameObject> deckObjs = new List<GameObject>();

    public GameObject attackCard;
    public GameObject defendCard;
    public GameObject magicCard;
    Vector3 cardPos = new Vector3(0f, 0.04f, -1f);
    Vector3 cardPosBack = new Vector3(0, 1.54f, 0.5f);
    float newCardY = 0.3f;
    float newCardZ = 0.3f;

    public int shieldInRow;
    public int magicInRow;
    public int swordInRow;

    public bool scoreRecorded;

    public static int maxInRow = 5;

    public resultsScript rs;

    public Transform gamePanel;

    Animator card0Anim;

    bool playAd = true;

    //for testing
    public Text listView;

    //time bar
    public Image timebar;
    bool timerActive = false;
    public Color red;
    public float countdown;
    public float timePassed;

    public float timeFinished;

    public float moveSpeed;

    public Button attackB;

    float moveCards = 0;

    //score
    public int score;
    public Text scoreText;

    fadeManager fm;
    characterManager cm;
    GameObject character;

    public GameObject countdownPanel;

    public AudioClip tap;
    public AudioClip fail;
    AudioSource au;

    public bool failed;

    public GameObject sceneManager;

    void Awake()
    {
        au = GetComponent<AudioSource>();
        GameObject g = GameObject.FindWithTag("fadeManager");
        if (g != null)
        {
            fm = g.GetComponent<fadeManager>();
        }
        GameObject bg = Instantiate(Resources.Load("Characters/" + gameParameters.currentCharacter + "/theme"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        character = GameObject.FindWithTag("character");

        if (character != null)
        {
                cm = character.GetComponent<characterManager>();
        }
    }

    void Start()
    {
        character.SetActive(false);
        resultsPanel.SetActive(false);
        choicePanel.SetActive(true);
        gameplayActive = false;
        timerActive = false;
        score = 0;
        scoreText.text = score.ToString();
        gameParameters.setDialog();
        //countdownPanel.SetActive(true);
       // StartCoroutine(smallWait());
    }

    IEnumerator smallWait()
    {
        yield return new WaitForSeconds(0.4f);
        startSess();
    }

    public void startShortGame()
    {
        gameParameters.setParamsforShortGame();
        startSess();

    }        

    public void startSess()
    {
        StartCoroutine(startSession());
    }

    IEnumerator startSession()
    {
        gameParameters.setDialog();
        if (choicePanel != null)
        {
            Animator anim = choicePanel.GetComponent<Animator>();
            anim.Play("out");
            yield return new WaitForSeconds(0.3f);
        }
        Debug.Log("Pulling from globalParams: " + gameParameters.maxTimeAllowed);
        //gameParameters.setParamsforShortGame();
        shuffleDeck();
        timebar.fillAmount = 1;
        gameIn();
        startGame();
        countdownPanel.SetActive(true);
        //yield return new WaitForSeconds(0.7f);
    }

    public void startLongGame()
    {
        gameParameters.setParamsforLongGame();
       // countdown = 60;
        StartCoroutine(startSession());
    }

    public void startEndlessGame()
    {
        gameParameters.setParamsforEndlessGame();
        //gameParameters.endlessGame = true;
        StartCoroutine(startSession());
    }



    //start game
    public void startGame()
    {
        //   Debug.Log("Starting timer");
        timePassed = 0;
        countdown = gameParameters.maxTimeAllowed;
        
        
    }

    //timer
    public void startTimer()
    {
        if (!gameParameters.endlessGame)
        {
            timerActive = true;
        }
            
        gameplayActive = true;
    }
    
    void stopTimer()
    {
        //  Debug.Log("Stopping timer");
        timerActive = false;

    }

    void timeOver()
    {
       
        StartCoroutine(timesUp());
    }

    IEnumerator timesUp()
    {
            //score = 0;
            //scoreText.text = score.ToString();
            cm.playIdle();
            stopTimer();
            gameplayActive = false;
            gameOut();
            timebar.fillAmount = 1;
            yield return new WaitForSeconds(0.75f);
            //cm.playIdle();
            clearDeck();
    }

    public void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    void Update()
    {

        switch (gameParameters.difficulty)
        {
            case 0:
                if (magicButton.activeInHierarchy == true)
                {
                    magicButton.SetActive(false);
                }
                maxInRow = 5;
                break;
            case 1:
                if (magicButton.activeInHierarchy == false)
                {
                    magicButton.SetActive(true);
                }

                maxInRow = 2;
                break;
            case 2:
                if (magicButton.activeInHierarchy == false)
                {
                    magicButton.SetActive(true);
                }
                maxInRow = 1;
                break;
        }

        if (timebar.fillAmount <= 0.3f && gameplayActive)
        {
            timebar.color = red;
            cm.playTime();
        }

        if (timebar.fillAmount > 0.25f)
        {
            timebar.color = Color.white;
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            tapButton(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            tapButton(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            tapButton(2);
        }

    }

    void FixedUpdate()
    {
        if (timerActive == true)
        {
            // float timer = countdown;
            //countdown -= Time.deltaTime;
            timePassed += 1.0f * Time.deltaTime;
            timebar.fillAmount -= 1.0f / countdown * Time.deltaTime;
        }

        if (timebar.fillAmount <= 0)
        {
            timeOver();
        }
    }

    void checkClearance()
    {
        timeFinished = timePassed;
        timerActive = false;
        gameplayActive = false;
       
        gameOut();
    }
    

    void clearDeck()
    {
        deck.Clear();
        listView.text = "";
        // Debug.Log("Deck cleared.");
        foreach (GameObject g in deckObjs)
        {
            Destroy(g);
        }
        deckObjs.Clear();
        cardPos = new Vector3(0f, 0.04f, -1f);
    }

    void shuffleDeck()
    {
        deck.Clear();
        //   Debug.Log("Shuffling deck.");
        listView.text = "";
        for (int i = 0; i < 6; i++)
        {
            if (gameParameters.difficulty == 0)
            {
                int r = Random.Range(0, 2);
                // deck.Add(r);
                listView.text += r + " ";

                switch (r)
                {
                    case 0:
                        GameObject Dcard = Instantiate(defendCard, cardPos, Quaternion.identity) as GameObject;
                        deck.Add(0);
                        Dcard.transform.parent = gamePanel;
                        deckObjs.Add(Dcard);
                        break;

                    case 1:
                        GameObject Acard = Instantiate(attackCard, cardPos, Quaternion.identity) as GameObject;
                        deck.Add(2);
                        Acard.transform.parent = gamePanel;
                        deckObjs.Add(Acard);
                        break;
                }
            }

            if (gameParameters.difficulty > 0)
            {
                int r = Random.Range(0, 3);
                //deck.Add(r);
                listView.text += r + " ";

                switch (r)
                {
                    case 0:
                        GameObject Dcard = Instantiate(defendCard, cardPos, Quaternion.identity) as GameObject;
                        deck.Add(0);
                        Dcard.transform.parent = gamePanel;
                        deckObjs.Add(Dcard);
                        break;

                    case 1:
                        GameObject Mcard = Instantiate(magicCard, cardPos, Quaternion.identity) as GameObject;
                        deck.Add(1);
                        Mcard.transform.parent = gamePanel;
                        deckObjs.Add(Mcard);
                        break;

                    case 2:
                        GameObject Acard = Instantiate(attackCard, cardPos, Quaternion.identity) as GameObject;
                        deck.Add(2);
                        Acard.transform.parent = gamePanel;
                        deckObjs.Add(Acard);
                        break;
                }
            }


            cardPos.y += newCardY;
            cardPos.z += newCardZ;

        }

        cardPos = new Vector3(0f, 0.34f, -0.7f);

    }

    void repDeck()
    {
        foreach (GameObject g in deckObjs)
        {
            cardMovement cardMove = g.GetComponent<cardMovement>();
            if (cardMove != null)
            {
                cardMove.move();
            }
        }
    }

    void addToDeck()
    {
        //    repositionDeck();
        if (gameParameters.difficulty == 0)
        {
            int r = Random.Range(0, 2);
            // deck.Add(r);
            listView.text += r + " ";
            switch (r)
            {

                case 0:
                    if (shieldInRow <= maxInRow)
                    {
                        GameObject Dcard = Instantiate(defendCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(0);
                        Dcard.transform.parent = gamePanel;
                        deckObjs.Add(Dcard);
                        shieldInRow++;
                        swordInRow = 0;
                        //break;
                    }
                    else
                    {
                        GameObject Acard = Instantiate(attackCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(2);
                        Acard.transform.parent = gamePanel;
                        deckObjs.Add(Acard);
                        swordInRow++;
                        shieldInRow = 0;
                        //break;
                    }
                    break;

                case 1:
                    if (swordInRow <= maxInRow)
                    {
                        GameObject Acard = Instantiate(attackCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(2);
                        Acard.transform.parent = gamePanel;
                        deckObjs.Add(Acard);
                        swordInRow++;
                        shieldInRow = 0;
                    }
                    else
                    {
                        GameObject Dcard = Instantiate(defendCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(0);
                        Dcard.transform.parent = gamePanel;
                        deckObjs.Add(Dcard);
                        shieldInRow++;
                        swordInRow = 0;
                    }
                    break;
            }
        }

        if (gameParameters.difficulty > 0)
        {
            int r = Random.Range(0, 3);
            // deck.Add(r);
            listView.text += r + " ";
            switch (r)
            {
                case 0:
                    if (shieldInRow <= maxInRow)
                    {
                        GameObject Dcard = Instantiate(defendCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(0);
                        Dcard.transform.parent = gamePanel;
                        deckObjs.Add(Dcard);
                        shieldInRow++;
                        swordInRow = 0;
                        magicInRow = 0;
                    }
                    else
                    {
                        int rand = Random.Range(0, 1);
                        switch (rand)
                        {
                            case 0:
                                GameObject Mcard = Instantiate(magicCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(1);
                                Mcard.transform.parent = gamePanel;
                                shieldInRow = 0;
                                swordInRow = 0;
                                magicInRow++;
                                deckObjs.Add(Mcard);
                                break;


                            case 1:
                                GameObject Acard = Instantiate(attackCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(2);
                                Acard.transform.parent = gamePanel;
                                shieldInRow = 0;
                                magicInRow = 0;
                                swordInRow++;
                                deckObjs.Add(Acard);
                                break;
                        }
                    }

                    break;

                case 1:
                    if (magicInRow <= maxInRow)
                    {
                        GameObject MAcard = Instantiate(magicCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(1);
                        MAcard.transform.parent = gamePanel;
                        deckObjs.Add(MAcard);
                        magicInRow++;
                        swordInRow = 0;
                        shieldInRow = 0;
                    }
                    else
                    {
                        int rand = Random.Range(0, 1);
                        switch (rand)
                        {
                            case 0:
                                GameObject DEcard = Instantiate(defendCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(0);
                                DEcard.transform.parent = gamePanel;
                                shieldInRow++;
                                swordInRow = 0;
                                magicInRow = 0;
                                deckObjs.Add(DEcard);
                                break;


                            case 1:
                                GameObject Acard = Instantiate(attackCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(2);
                                Acard.transform.parent = gamePanel;
                                shieldInRow = 0;
                                magicInRow = 0;
                                swordInRow++;
                                deckObjs.Add(Acard);
                                break;
                        }
                    }
                    break;

                case 2:
                    if (swordInRow <= maxInRow)
                    {
                        GameObject ATcard = Instantiate(attackCard, cardPosBack, Quaternion.identity) as GameObject;
                        deck.Add(2);
                        ATcard.transform.parent = gamePanel;
                        swordInRow++;
                        shieldInRow = 0;
                        magicInRow = 0;
                        deckObjs.Add(ATcard);

                    }
                    else
                    {
                        int rand = Random.Range(0, 1);
                        switch (rand)
                        {
                            case 0:
                                GameObject DEcard = Instantiate(defendCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(0);
                                DEcard.transform.parent = gamePanel;
                                shieldInRow++;
                                swordInRow = 0;
                                magicInRow = 0;
                                deckObjs.Add(DEcard);
                                break;

                            case 1:
                                GameObject MAcard = Instantiate(magicCard, cardPosBack, Quaternion.identity) as GameObject;
                                deck.Add(1);
                                MAcard.transform.parent = gamePanel;
                                deckObjs.Add(MAcard);
                                magicInRow++;
                                swordInRow = 0;
                                shieldInRow = 0;
                                break;
                        }

                    }
                    break;
            }
        }
    }

    public void tapButton(int i)
    {
        if ((gameplayActive) && (deck.Count != 0))
        {
            {
                if (i == deck[0])
                {
                    tapSuccess();
                }
                else
                {
                    tapFailure();
                }
            }
        }
    }

    public void tapSuccess()
    {
        //       Debug.Log("Tap success!");
        
        cardMovement cardMove = deckObjs[0].GetComponent<cardMovement>();
        cardMove.destroyCard();
        au.PlayOneShot(tap);
        deck.RemoveAt(0);
        //  Destroy(deckObjs[0]);
        deckObjs.RemoveAt(0);
        score++;
        if (score == gameParameters.requiredScore)
        {
            checkClearance();
        }
        scoreText.text = score.ToString();

        repDeck();
        moveCards += 0.2f;
        addToDeck();
    }

    public void tapFailure()
    {
      //  cm.playFail();
        StartCoroutine(tapFail());
        failed = true;
        
    }

    IEnumerator tapFail()
    {
        //      Debug.Log("Tap Failure. Game Over!");
        cm.playFail();
        gameplayActive = false;
        stopTimer();
        cardMovement cardMove = deckObjs[0].GetComponent<cardMovement>();
        cardMove.cardWobble();
        au.PlayOneShot(fail, 0.3f);
        yield return new WaitForSeconds(0.5f);
        
        gameOut();
        GameObject g = GameObject.FindWithTag("results");
        yield return new WaitForSeconds(0.75f);
        clearDeck();
        cm.playIdle();
        
    }

    //Powerups

    public void arrowPowerUp()
    {
        StartCoroutine(arrow());
    }

    IEnumerator arrow()
    {
        int i = 6;
        while (i > 0)
        {
            arrowSuccess();
            i--;
            yield return new WaitForSeconds(0.035f);

            addToDeckHigher();
            repDeck();

        }
    }

    public void arrowSuccess()
    {
        //  Debug.Log("Tap success!");

        cardMovement cardMove = deckObjs[0].GetComponent<cardMovement>();
        cardMove.arrowCard();
        deck.RemoveAt(0);
        //  Destroy(deckObjs[0]);
        deckObjs.RemoveAt(0);
        score += 2;
        scoreText.text = score.ToString();
        moveCards += 0.2f;
        //addToDeck();
    }

    void addToDeckHigher()
    {
        //    repositionDeck();
        int r = Random.Range(0, 3);
        deck.Add(r);
        listView.text += r + " ";
        Vector3 v = new Vector3(0, 1.84f, 0.8f);
        switch (r)
        {
            case 0:
                GameObject Dcard = Instantiate(defendCard, v, Quaternion.identity) as GameObject;
                deckObjs.Add(Dcard);
                break;

            case 1:
                GameObject Mcard = Instantiate(magicCard, v, Quaternion.identity) as GameObject;
                deckObjs.Add(Mcard);
                break;

            case 2:
                GameObject Acard = Instantiate(attackCard, v, Quaternion.identity) as GameObject;
                deckObjs.Add(Acard);
                break;
        }

    }

    public void toStore()
    {
        StartCoroutine(goToStore());
    }

    IEnumerator goToStore()
    {
        fm.faderIn();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("store");

    }

    public void gameIn()
    {
        StartCoroutine(gaIn());
    }

    IEnumerator gaIn()
    {
        gamePanelObj.SetActive(true);
        gameButtonPanel.SetActive(true);
        if (!character.activeSelf)
        {
            character.SetActive(true);
            cm.playEntry();
        }
        
        //if (cm.offScreen)
        //{
         //   cm.playEntry();
        //}

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
        gamePanelObj.SetActive(false);
        gameButtonPanel.SetActive(false);
            resultsIn();
    }


    public void resultsIn()
    {
        resultsPanel.SetActive(true);
        resultsButtonPanel.SetActive(true);
    }

}
