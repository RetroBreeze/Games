using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class difficultyButton : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Image star1Img;
    public Image star2Img;
    public Image star3Img;

    public Color blue;
    public Color yellow;
    public Color red;
    public Color gray;
    // Update is called once per frame

    void Update()
    {
        switch (gameParameters.difficulty)
        {
            case 0:
                star1Img.color = blue;
                star2Img.color = gray;
                star3Img.color = gray;
                break;

            case 1:
                star1Img.color = yellow;
                star2Img.color = yellow;
                star3Img.color = gray;
                break;

            case 2:
                star1Img.color = red;
                star2Img.color = red;
                star3Img.color = red;
                break;
        }
    }
    public void changeDifficulty()
    {
        if (gameParameters.difficulty < 2)
        {
            gameParameters.difficulty++;
        }

        else if (gameParameters.difficulty == 2)
        {
            gameParameters.difficulty = 0;
        }

    }
}
