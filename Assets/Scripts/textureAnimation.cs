using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textureAnimation : MonoBehaviour {
	public float timeBetweenFrames;
	private float timer;
	public Sprite[] frames;
	public int currentFrame;
	public Text scoreText;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		this.transform.SetParent(GameObject.FindGameObjectWithTag("sceneControl").transform);
		this.GetComponent<AudioSource>().Play();
	}

	public void setScore(int sv)
	{
		int score = player.GetComponent<characterController>().score;
		score += sv;
		player.GetComponent<characterController>().score = score;
		scoreText.text = string.Format("{0:n0}", sv);
		GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text = string.Format("{0:n0}", score);

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
		else if(currentFrame+1 >= frames.Length) 
		{
			Destroy(gameObject);
		}
	}
}
