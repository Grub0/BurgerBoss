using UnityEngine;
using System.Collections;

public class globalStorage : MonoBehaviour {
	public int startingLives = 3;
	public int score;
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
