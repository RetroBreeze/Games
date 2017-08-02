using UnityEngine;
using System.Collections;


public class shareScript : MonoBehaviour {

    public GameObject panel;
    Animator anim;

    public GameObject screenShotPanel;

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";

    private const string FACEBOOK_APP_ID = "809821942471477";
    private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

    bool _capture = false;

    void Awake()
    {
        anim = panel.GetComponent<Animator>();
        panel.SetActive(false);
    }

    public void shareButton()
    {
        panel.SetActive(true);
    }

    public void onPostRender()
    {
        if (_capture)
        {
            screenShotPanel.SetActive(true);
            var image = new Texture2D(506, 253, TextureFormat.RGB24, false);
            image.ReadPixels(new Rect(0, 0, 506, 253), 0, 0, false);
            image.Apply();

            _capture = false;
            screenShotPanel.SetActive(false);
        }
    }

    public void shareToTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS +
                            "?text=" + WWW.EscapeURL("I shared this tweet from Shuffle Quest!") +
                            "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

    public void shareToFaceBook()
    {
        string linkParameter = "http://www.playkiseki.com";
        string nameParameter = "I shared this post from Shuffle Quest!";
        string captionParameter = "Shuffle Quest: Coming soon to iOS!";
        string descriptionParameter = "Shuffle Quest: Coming soon to iOS!";
        string pictureParameter = "";
        string redirectParameter = "http://www.facebook.com";

        Application.OpenURL(FACEBOOK_URL +
                             "?app_id=" + FACEBOOK_APP_ID +
                             "&link=" + WWW.EscapeURL(linkParameter) +
                             "&name=" + WWW.EscapeURL(nameParameter) +
                             "&caption=" + WWW.EscapeURL(captionParameter) +
                             "&description=" + WWW.EscapeURL(descriptionParameter) +
                             "&picture=" + WWW.EscapeURL(pictureParameter) +
                             "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
    }

    public void shareQuestToTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS +
                            "?text=" + WWW.EscapeURL("I cleared " + gameParameters.questName + "'s challenge in #ShuffleQuest!") +
                            "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

    public void shareQuestToFaceBook()
    {
        string linkParameter = "http://www.playkiseki.com";
        string nameParameter = "I cleared " + gameParameters.questName + "'s challenge in #ShuffleQuest!";
        string captionParameter = "Shuffle Quest: Coming soon to iOS!";
        string descriptionParameter = "Shuffle Quest: Coming soon to iOS!";
        string pictureParameter = "";
        string redirectParameter = "http://www.facebook.com";

        Application.OpenURL(FACEBOOK_URL +
                             "?app_id=" + FACEBOOK_APP_ID +
                             "&link=" + WWW.EscapeURL(linkParameter) +
                             "&name=" + WWW.EscapeURL(nameParameter) +
                             "&caption=" + WWW.EscapeURL(captionParameter) +
                             "&description=" + WWW.EscapeURL(descriptionParameter) +
                             "&picture=" + WWW.EscapeURL(pictureParameter) +
                             "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
    }

    public void shareToGoogle()
    {

    }

    public void shareOut()
    {
        StartCoroutine(shaOut());
    }

    IEnumerator shaOut()
    {
        anim.Play("shareOut");
        yield return new WaitForSeconds(0.5f);
        panel.SetActive(false);
        
    }

}
