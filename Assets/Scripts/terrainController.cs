using UnityEngine;
using System.Collections;

public class terrainController : MonoBehaviour {
	public float horizontalMovementSpeed;
	public GameObject[] terrains;
	// Use this for initialization
	void Start () 
	{
		terrains = GameObject.FindGameObjectsWithTag("terrain");
		foreach(GameObject g in terrains)
		{
			Vector3 temp = new Vector3(horizontalMovementSpeed,0f,0f);
			g.rigidbody.velocity = temp;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
