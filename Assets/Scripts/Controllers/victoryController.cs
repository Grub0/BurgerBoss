using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class victoryController : MonoBehaviour {
	private globalStorage gst;
	// Use this for initialization
	void Start () 
	{
		gst = GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>();
		GetComponent<Text>().text = string.Format("{0:n0}", GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().score);
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
		}
	}
}
