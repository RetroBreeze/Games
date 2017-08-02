using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class GameCenterLeaderboardReport : MonoBehaviour {

	void Start () {
		
		// Leaderboard - YOU MUST UNCOMMENT LINES 29 & 33 BEFORE CORRECTLY USING THIS SCRIPT. REFER TO INCLUDED DOCUMENTATION.

		// The below line of code (line 29) is EXTREMELY IMPORTANT!

		// You are REQUIRED to edit this line with *YOUR* sciptname.var and unique leaderboard ID to make a leaderboard report.

		// The below line (line 29) should look something like the following:

		// Social.ReportScore(HighScoreDeclaration.killcount, "mostkills123", (bool success) => {

		// In the example code in line 17 - the player is referencing 3 things:

			// 1 - HighScoreDeclaration is the script where the the score variable is initially declared

			// 2 - killcount is the score variable declared in the script HighScoreDeclaration

			// 3 - "mostkills123" is the ID of the Game Center leaderboard set up in iTunesConnect

		// MAKE ABSOLUTELY SURE TO LEAVE THE "" QUOATATION MARKS AROUND YOUR LEADERBOARD ID. THIS IS REQUIRED!

//	Social.ReportScore(YOUR_SCRIPT_NAME_HERE.YOUR_SCORE_VARIABLE_HERE, "YOUR_LEADERBOARD_ID_HERE", (bool success) => {

		// The bool success will handle the case of a failure. If there is a failed report, it will try again.

//	});
	}
}