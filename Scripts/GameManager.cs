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
	public Text topScore_info;

	// Use this for initialization
	void Start () 
	{
		InitGame();
		//PlayerPrefs.SetInt("Top Score", 0);	
	}
	
	// Initialize Game
	private void InitGame()
	{
		gameActive = true;
		score = 0;
		remainingTime = timer;
		UpdateTopScore(score);
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
	}

	void UpdateTopScore(int recordScore)
	{
		if (PlayerPrefs.GetInt("Top Score").Equals(null) || PlayerPrefs.GetInt("Top Score") < recordScore)
		PlayerPrefs.SetInt("Top Score", recordScore);
		topScore_info.text = "Top Score: " + PlayerPrefs.GetInt("Top Score").ToString();
	}
	public void GetScore(int po)
	{
		if (gameActive)
		score = score + po;
	}
}
