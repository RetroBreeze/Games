using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenterShowLeaderboard : MonoBehaviour {

	// This very simple bit of code will display your game's Game Center inside of your app.

	// Note - I have it set up to open up upon a touch event of the object this script is attached to.
	// If you would rather have Game Center open upon the beginning of a room, then do the following:
		// 1 - uncomment line 15
		// 2 - comment line 16

	// void Start () {
	void OnMouseEnter () {

		Social.ShowLeaderboardUI();
	
	}

}