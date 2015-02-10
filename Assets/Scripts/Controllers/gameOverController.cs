using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour {
	public float timer;
	public float lagBetweenLetters = .1f;
	public bool activated;
	// Use this for initialization
	void Start () 
	{
		//Application.LoadLevel("mainMenu");
		activated = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(activated == true)
		{
			timer+= Time.deltaTime;
		}

		if(timer >lagBetweenLetters*11)
		{
			GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().startingLives = 3;
			//Application.LoadLevel("mainMenu");
			Application.LoadLevel("victory");

		}
		else if(timer >lagBetweenLetters*8)
		{
			GetComponent<Text>().text = "GAME OVER";
		}
		else if(timer >lagBetweenLetters*7)
		{
			GetComponent<Text>().text = "GAME OVE";
		}
		else if(timer >lagBetweenLetters*6)
		{
			GetComponent<Text>().text = "GAME OV";
		}
		else if(timer >lagBetweenLetters*5)
		{
			GetComponent<Text>().text = "GAME O";
		}
		else if(timer >lagBetweenLetters*4)
		{
			GetComponent<Text>().text = "GAME";
		}
		else if(timer >lagBetweenLetters*3)
		{
			GetComponent<Text>().text = "GAM";
		}
		else if(timer >lagBetweenLetters*2)
		{
			GetComponent<Text>().text = "GA";
		}
		else if(timer >lagBetweenLetters)
		{
			GetComponent<Text>().text = "G";
		}

	}
}
