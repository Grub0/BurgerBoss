using UnityEngine;
using System.Collections;

public class terrainController : MonoBehaviour {
	public float horizontalMovementSpeed;
	public GameObject[] terrains;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{		
		terrains = GameObject.FindGameObjectsWithTag("terrain");
		foreach(GameObject g in terrains)
		{
			Vector3 temp = g.transform.position;
			temp.x += horizontalMovementSpeed;
			g.transform.position = temp;
			if(g.transform.position.x < 0 - Screen.width/2)
			{
				Destroy(g);
			}
		}

		terrains = GameObject.FindGameObjectsWithTag("powerUp");
		foreach(GameObject g in terrains)
		{
			Vector3 temp = g.transform.position;
			temp.x += horizontalMovementSpeed;
			g.transform.position = temp;
			if(g.transform.position.x < 0 - Screen.width/2)
			{
				Destroy(g);
			}
		}

		terrains = GameObject.FindGameObjectsWithTag("weapon");
		foreach(GameObject g in terrains)
		{
			Vector3 temp = g.transform.position;
			temp.x += horizontalMovementSpeed;
			g.transform.position = temp;
			if(g.transform.position.x < 0 - Screen.width/2)
			{
				Destroy(g);
			}
		}
	}
}
