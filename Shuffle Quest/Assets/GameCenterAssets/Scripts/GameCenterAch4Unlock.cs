using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class GameCenterAch4Unlock : MonoBehaviour {

	void Start () {
		
		// In line 16 you MUST place an achievement ID that you set up in iTunesConnect inside the quotations.

		// For example - your code for line 16 should look something like the following:

		// Social.ReportProgress ("myachievementid4", 100.0, result => {
		
		// MAKE SURE TO LEAVE THE "" QUOTATION MARKS AROUND YOUR ACHIEVEMENT ID. THIS IS REQUIRED!
		Social.ReportProgress ("exampleach4", 100.0, result => {
			if (result)
				Debug.Log ("achievement report success");
			else
				Debug.Log ("achievement report fail");
		});
		
	}
	
}