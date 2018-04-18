using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEmotionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Check for correct emotion and add to score
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Happy emotion selected");

        GameObject deck = GameObject.FindGameObjectWithTag("Deck");
        GridOverlayScript overlayScript = deck.GetComponent<GridOverlayScript>();
        if (overlayScript.oddEmotionIndex == (int)Emotions.Happy)
        {
            Debug.Log("Correct emotion selected");

            ScoreKeeperScript scoreKeeper = deck.GetComponent<ScoreKeeperScript>();
            scoreKeeper.AddScore();
        }
        else
        {
            Debug.Log("Incorrect emotion selected");
        }
    }
}
