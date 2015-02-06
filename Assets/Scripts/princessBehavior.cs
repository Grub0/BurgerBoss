using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class princessBehavior : MonoBehaviour {
	public Sprite[] frames = new Sprite[3];
	private float timer;
	private float timeBetweenFrames = 1f;
	private int currentFrame = 0;
	private bool active;
	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Image>().sprite = frames[currentFrame];
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			active = true;
			this.GetComponent<AudioSource>().Play();
			GameObject.Find("Stage Music").GetComponent<AudioSource>().Stop();
		}

	}
	// Update is called once per frame
	void Update () 
	{
		if(active == true)
		{
		timer+= Time.deltaTime;
		if(timer>timeBetweenFrames)
		{
			timer = 0;
			currentFrame+=1;
			if(currentFrame<frames.Length -1)
			{
				this.GetComponent<Image>().sprite = frames[currentFrame];
			}
			else
			{
				GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().gotPrincess = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<characterController>().getPrincess();
			}
		}
		}
	}
}
