using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {
	public float gravityAmount;
	public 
	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3(0, gravityAmount, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
