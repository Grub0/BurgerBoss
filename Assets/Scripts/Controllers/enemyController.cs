using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	#region Public Variables
	public GameObject player;
	public float speed;
	#endregion

	#region Private Variables
	private float scorePoints;
	#endregion
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveToPlayer();
	}

	private void moveToPlayer()
	{
		Vector2 temp = this.transform.position;
		if(player.transform.position.x > this.transform.position.x)
		{
			temp.x += speed;
		}
		else if(player.transform.position.x < this.transform.position.x)
		{
			temp.x -= speed;
		}
		this.transform.position = temp;
	}

	public void death()
	{
		//Do something with score
		Destroy(this.gameObject);
	}
}
