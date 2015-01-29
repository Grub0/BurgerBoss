using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class victoryController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<Text>().text = string.Format("{0:n0}", GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>().score);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			Application.LoadLevel("mainMenu");
		}
	}
}
