using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mainMenuController : MonoBehaviour {

	public GameObject insertCoin;
	private float coinTimer;
	// Use this for initialization
	void Start () 
	{
		setScore();
	}

	private void coinFading()
	{
		coinTimer+= Time.deltaTime;
		if(coinTimer >1f && insertCoin.GetComponent<Text>().color == Color.red)
		{
			insertCoin.GetComponent<Text>().color = Color.clear;
			coinTimer = 0;
		}
		else if(coinTimer >1f && insertCoin.GetComponent<Text>().color == Color.clear)
		{
			if(insertCoin.GetComponent<Text>().text == "INSERT COIN ")
			{
				insertCoin.GetComponent<Text>().text = "PRESS START";
			}
			else if(insertCoin.GetComponent<Text>().text == "PRESS START")
			{
				insertCoin.GetComponent<Text>().text = "INSERT COIN ";
			}
			insertCoin.GetComponent<Text>().color = Color.red;
			coinTimer = 0;
		}
	}

	public GameObject scoreText;
	public int score = 100000;
	public void setScore()
	{
		scoreText.GetComponent<Text>().text = "HIGH SCORE " + string.Format("{0:n0}", score);
	}
	// Update is called once per frame
	void Update () 
	{
		coinFading();
		if(Input.GetKeyDown("space"))
		{
			Application.LoadLevel(Resources.Load("Scenes/mainScene").name);
		}
	}
}
