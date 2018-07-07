using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour 
{
    public static BallSpawner current;
    public GameManager gameManager;
    public GameObject pooledBall; //the prefab of the object in the object pool
    public int ballsAmount = 20; //the number of objects you want in the object pool
    public List<Ball> ball; //the object pool
    public static int ballPoolNum = 0; //a number used to cycle through the pooled objects

    private float cooldown;
    private float cooldownLength = 0.5f;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    void Start()
    {
        //Create Ball Pool
        ball = new List<Ball>();
        for (int i = 0; i < ballsAmount; i++)
        {
            AddNewBall();
        }
    }
    private void AddNewBall()
    {
        GameObject obj = Instantiate(pooledBall);
        Ball newBall = obj.GetComponent<Ball>();
        ball.Add(newBall);
    }
   	
	// Update is called once per frame
	void Update () 
    {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0 && gameManager.gameActive )
            {
                // Reset the timer at every 30 sec. by checking out cooldownLength 0.5f and create a newBall.
                cooldown = cooldownLength; 
                SpawnBall();
            }
	}

    private void SpawnBall()
    {
        int counter = 0;
        while (counter < ball.Count)
        {
            if(ballPoolNum >= ball.Count)
                ballPoolNum = 0;
            if(ball[ballPoolNum].gameObject.activeSelf == false || ball[ballPoolNum].ballStopped)
            {
                ball[ballPoolNum].Activate(transform.position);
                return; // Exit after creating 1 new ball.
            }
            ballPoolNum ++;
            counter ++;
        }
        ballPoolNum = 0;
    }
    public void ResetBallPool()
    {
        for (int i=0; i< ball.Count; i++)
        {
            ball[i].gameObject.SetActive(false);
            ball[i].ballStopped = true; 
        }
    }
}
