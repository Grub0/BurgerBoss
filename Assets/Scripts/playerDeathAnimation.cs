using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerDeathAnimation : MonoBehaviour {
	public float timeBetweenFrames;
	private float timer;
	public Sprite[] frames;
	public int currentFrame;
	public GameObject player;
	public bool looping;
	public bool destroyOnEnd;
	// Use this for initialization
	void Start () 
	{
		this.transform.SetParent(GameObject.FindGameObjectWithTag("sceneControl").transform);
		this.GetComponent<AudioSource>().Play();
		//GameObject.FindGameObjectWithTag("gameOver").GetComponent<gameOverController>().activated = true;
	}

	// Update is called once per frame
	void Update () 
	{
		timer+= Time.deltaTime;
		if(timer > timeBetweenFrames && currentFrame+1 <frames.Length)
		{
			currentFrame+=1;
			this.GetComponent<Image>().sprite = frames[currentFrame];
			timer = 0;
		}
		else if(currentFrame+1 >= frames.Length && looping == true) 
		{
			currentFrame = 0;
			this.GetComponent<Image>().sprite = frames[currentFrame];
			timer = 0;
		}
		else if(currentFrame+1 >= frames.Length && looping == false && GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().startingLives == -1) 
		{
			GameObject.FindGameObjectWithTag("gameOver").GetComponent<gameOverController>().activated = true;
		}
		else if(currentFrame+1 >= frames.Length && looping == false && GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().startingLives > -1 && GameObject.FindGameObjectWithTag("gameOver").GetComponent<gameOverController>().activated == false) 
		{
			Application.LoadLevel("inBetweenLives");
		}

	}
}
