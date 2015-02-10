using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class victoryController : MonoBehaviour {
	private globalStorage gst;
	// Use this for initialization
	void Start () 
	{
		gst = GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>();
		if(gst.gotPrincess == true)
		{
			gst.score += 150000;
			GameObject.Find("bonus").GetComponent<Text>().text = "Level Complete Bonus: 150,000";
		}
		GetComponent<Text>().text = string.Format("{0:n0}", GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().score);
		gst.gotPrincess = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			if(gst.score > gst.currentHighScore)
			{
				//gst.highScoreText = "DRL";
				Application.LoadLevel("enterHS");
			}
			else
			{
				//gst.highScoreText = "DRL";
				Application.LoadLevel("splash");
			}
		}
	}
}
