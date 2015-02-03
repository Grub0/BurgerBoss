using UnityEngine;
using System.Collections;

public class globalStorage : MonoBehaviour {
	public int startingLives = 3;
	public int score;
	public string highScoreText;
	public int currentHighScore = 300;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
