using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class splashController : MonoBehaviour {
	public GameObject ship;
	private float verticalShipMove = 2f;
	private float verticalLag = 1f;
	private float verticalTimer;
	public GameObject cloud1;
	public GameObject cloud2;
	public GameObject cloud3;
	public GameObject splashStart;
	private globalStorage gst;
	// Use this for initialization
	void Start () 
	{
		splashStart.GetComponent<AudioSource>().Play();
		gst = GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>();
		if(gst.score > gst.currentHighScore)
		{
			GameObject.FindGameObjectWithTag("highScoreName").GetComponent<Text>().text = gst.highScoreText;
			gst.currentHighScore = gst.score;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveShip();
		moveClouds();
		if(splashStart.GetComponent<AudioSource>().isPlaying == false && GetComponent<AudioSource>().isPlaying == false)
		{
			GetComponent<AudioSource>().Play();
		}
	}

	void moveShip()
	{
		verticalTimer+= Time.deltaTime;
		if(verticalTimer > verticalLag && verticalShipMove == 2f)
		{
			verticalShipMove = -2f;
			verticalTimer = 0;
		}
		else if(verticalTimer > verticalLag && verticalShipMove == -2f)
		{
			verticalShipMove =2f;
			verticalTimer = 0;
		}
		Vector2 temp = new Vector2(ship.transform.position.x+8f,ship.transform.position.y+verticalShipMove); 
		ship.transform.position = temp;
		if(ship.transform.position.x >Screen.width + 400f)
		{
			endSplash();
		}
	}

	void moveClouds()
	{
		Vector2 temp1 = cloud1.transform.position;
		Vector2 temp2 = cloud2.transform.position;
		Vector2 temp3 = cloud3.transform.position;
		temp1.x -= .1f;
		temp2.x -= .3f;
		temp3.x -= .6f;
		cloud1.transform.position = temp1;
		cloud2.transform.position = temp2;
		cloud3.transform.position = temp3;

	}

	void endSplash()
	{
		Application.LoadLevel("mainMenu");
	}
}
