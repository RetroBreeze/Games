using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class gameParameters
{

    public static int questNumber;
    public static string questName;
    public static int requiredScore = 0;
    public static float maxTimeAllowed = 60;

    public static bool endlessGame = false;

    public static bool arrowAllowed = true;
    public static bool livesAllowed = true;

    public static int difficulty = 0;
    public static int playsTilAd = 3;

    public static int adsRemoved;

    public static string currentCharacter;
    public static string tempCharacter;

    public static List<string> dialog = new List<string>();

    // Use this for initialization
    static void Start()
    {
        difficulty = 0;
        if (PlayerPrefs.HasKey("adsRemoved"))
        {
            adsRemoved = PlayerPrefs.GetInt("adsRemoved");
        }
        else
        {
            adsRemoved = 0;
        }

        if (PlayerPrefs.HasKey("currentCharacter"))
        {
            currentCharacter = PlayerPrefs.GetString("currentCharacter");
        }
        else
        {
            currentCharacter = "Finnikin";
            PlayerPrefs.SetString("currentCharacter", currentCharacter);
        }

        if (PlayerPrefs.HasKey("playsTilAd"))
        {
            playsTilAd = PlayerPrefs.GetInt("playsTilAd");
        }
        else
        {
            playsTilAd = 3;
            PlayerPrefs.SetInt("playsTilAd", playsTilAd);
        }
        Debug.Log("Plays til ad:" + playsTilAd);
        dialog.Clear();

        setDialog();        
    }

    public static void setParamsforShortGame()
    {
        endlessGame = false;
        requiredScore = 0; //change to High Score when implemented
        maxTimeAllowed = 30;
    }

    public static void setParamsforLongGame()
    {
        endlessGame = false;
        requiredScore = 0; //change to High Score when implemented
        maxTimeAllowed = 60;
    }

    public static void setParamsforEndlessGame()
    {
        endlessGame = true;
        requiredScore = 0; //change to High Score when implemented
        maxTimeAllowed = 0;
    }

    public static void setDialog()
    {

        switch (currentCharacter)
        {
            case "Bann":
            //Fail dialogue
            dialog.Add("Just relax and try again.");
            dialog.Add("Just take it easy, there's no rush.");
            dialog.Add("You never lose as long as you're having fun.");

            //Average dialogue
            dialog.Add("Wow! You're good.");
            dialog.Add("See? You can do it!");
            dialog.Add("Wasn't that fun?");

            //Good dialogue
            dialog.Add("Wow, you're really good at this!");
            dialog.Add("Good job!");
            dialog.Add("You did so well!");

            //Great dialogue
            dialog.Add("I'm having so much fun!");
            dialog.Add("You really are the best!");
            dialog.Add("I knew you were special!");
            break;

            case "Bella":
			
			//Fail dialogue
            dialog.Add("");
            dialog.Add("");
            dialog.Add("");

			//Average dialogue
            dialog.Add("");
            dialog.Add("");
            dialog.Add("");

			//Good dialogue
            dialog.Add("");
            dialog.Add("");
            dialog.Add("");

			//Great dialogue
            dialog.Add("");
            dialog.Add("");
            dialog.Add("");
            break;

            case "Blane":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

            case "Damien":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

            case "Finnikin":
			
			//Fail dialogue
			dialog.Add("Testbad1");
			dialog.Add("TB2");
			dialog.Add("TB3");

			//Average dialogue
			dialog.Add("TA1");
			dialog.Add("TA2");
			dialog.Add("TA3");

			//Good dialogue
			dialog.Add("TG1");
			dialog.Add("TG2");
			dialog.Add("TG3");

			//Great dialogue
			dialog.Add("TGR1");
			dialog.Add("TGR2");
			dialog.Add("TGR3");
			break;

            case "Gwyn":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;


            case "Hector":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;


            case "Katsa ":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;


            case "Mather":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

            case "Pifoo":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;


            case "Rylan":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

            case "Sothe":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;


            case "Wesker":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

            case "Yuki":
			
			//Fail dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Average dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Good dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");

			//Great dialogue
			dialog.Add("");
			dialog.Add("");
			dialog.Add("");
			break;

        }

    }

}