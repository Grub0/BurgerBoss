using UnityEngine;
using System.Collections;

public class globalStorage : MonoBehaviour {
	public int startingLives = 3;
	public int score = 0;
	public string highScoreText = "BOBSUX";
	public int currentHighScore = 317000;
	public bool gotPrincess;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
