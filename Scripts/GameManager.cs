using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int score;
	public float timer;
	private float remainingTime = 0;
	public bool gameActive;
	public Text timer_info;
	public Text score_info;
	public Text highestScore_info;
	public BallSpawner ballSpawner;
	public OVRInput.Controller controllerRight;

	// Use this for initialization
	void Start () 
	{
		InitGame();
	}
	
	// Initialize Game
	private void InitGame()
	{
		gameActive = true;
		score = 0;
		remainingTime = timer;
		// Get the highest score to display
		UpdateTopScore(score);
		// Clean up all current running balls
		ballSpawner.ResetBallPool();
	}

	// Update is called once per frame
	void Update () 
	{
		if (gameActive)
		{
			score_info.text = "Score: " + score.ToString();
			remainingTime = remainingTime - Time.deltaTime;
			if(remainingTime <= 0)
			{
				remainingTime = 0;
				gameActive = false;
				timer_info.text = "<b> Time Over ! </b>";
			}
			else
				timer_info.text = "Timer: " + ((int)remainingTime +1).ToString();
		}
		else UpdateTopScore(score);

		if(OVRInput.GetDown(OVRInput.Button.Two, controllerRight))
		{
			InitGame();
		}
	}

	void UpdateTopScore(int recordScore)
	{
		if (PlayerPrefs.GetInt("The highest Score").Equals(null) || PlayerPrefs.GetInt("The highest Score") < recordScore)
		PlayerPrefs.SetInt("The highest Score", recordScore);
		highestScore_info.text = "The highest Score: " + PlayerPrefs.GetInt("The highest Score").ToString();
	}
	public void GetScore(int po)
	{
		if (gameActive)
		score = score + po;
	}
}
