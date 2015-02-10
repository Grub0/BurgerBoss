using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inBetweenController : MonoBehaviour {

	private float timer;
	// Use this for initialization
	void Start () 
	{
		if(GameObject.FindGameObjectWithTag("globalStorage") != null)
		{
		this.GetComponent<Text>().text = "X " + GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().startingLives.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer+= Time.deltaTime;
		if(timer > 2f)
		{
			Application.LoadLevel("mainScene");
		}
	}
}
