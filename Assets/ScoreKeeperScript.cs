using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeperScript : MonoBehaviour {

    public int scoreIncrement;
    public int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Add an amount to the total score
    /// </summary>
    public void AddScore()
    {
        score += scoreIncrement;
    }
}
