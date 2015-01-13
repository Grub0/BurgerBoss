using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {
	public float gravityAmount;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Physics.gravity = new Vector3(0, gravityAmount, 0);
	}
}
