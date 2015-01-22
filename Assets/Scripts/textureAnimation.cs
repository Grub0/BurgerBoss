using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textureAnimation : MonoBehaviour {
	public float timeBetweenFrames;
	private float timer;
	public Sprite[] frames;
	public int currentFrame;
	public Text scoreText;
	// Use this for initialization
	void Start () 
	{
		this.transform.SetParent(GameObject.FindGameObjectWithTag("sceneControl").transform);
		this.GetComponent<AudioSource>().Play();
		//scoreText = gameObject.GetComponent("Text").GetComponent<Text>();
	}

	public void setScore(int sv)
	{
		//this.GetComponentInChildren<Text>().text;
		//GetComponentInChildren<Text>().text = scoreValue.ToString();
		scoreText.text = string.Format("{0:n0}", sv);
		//Debug.Log(GetComponentsInChildren<Text>().);
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
