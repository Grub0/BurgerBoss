using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {
	public float gravityAmount;
	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3(0, gravityAmount, 0);
		GameObject oneUP = GameObject.FindGameObjectWithTag("livesText");
		GameObject globalVar = GameObject.FindGameObjectWithTag("globalStorage");
		for(int i=1;i<globalVar.GetComponent<globalStorage>().startingLives + 1;i++)
		{
			GameObject lives = (GameObject)Resources.Load("Prefabs/Other/lives");
			Vector2 temp = oneUP.transform.position;
			temp.x += i* 50;
			lives.transform.position = temp; 
			GameObject.Instantiate(lives);
		}

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("livesPic"))
		{
			go.transform.SetParent(oneUP.transform);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
