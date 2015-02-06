using UnityEngine;
using System.Collections;

public class burgerRun : MonoBehaviour {
	public GameObject player;
	private bool scared;
	public float distBeforeRun = 10f;
	public float speed = 4f;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player != null && (player.transform.position.x > this.transform.position.x - distBeforeRun))
		{
			scared = true;
		}
		if(scared == true)
		{
			Vector3 temp = this.transform.position;
			temp.x+=speed;
			this.transform.position = temp;
		}
	}
}
