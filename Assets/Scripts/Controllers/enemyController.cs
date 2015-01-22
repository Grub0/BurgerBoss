using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyController : MonoBehaviour {
	#region Public Variables
	public GameObject player;
	public float speed;
	public Vector3 size;
	public int scorePoints;

	#endregion

	#region Private Variables
	#endregion
	// Use this for initialization
	void Start () 
	{
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveToPlayer();
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "killBox")
		{
			death();
		}
	}

	private void moveToPlayer()
	{
		Vector2 temp = this.transform.position;
		if(player.transform.position.x > this.transform.position.x)
		{
			temp.x += speed;
			this.transform.localScale = new Vector3(size.x,size.y,size.z);
		}
		else if(player.transform.position.x < this.transform.position.x)
		{
			temp.x -= speed;
			this.transform.localScale = new Vector3(-size.x,size.y,size.z);
		}
		this.transform.position = temp;
	}

	public void death()
	{
		//Do something with score
		GameObject enemyDeath = (GameObject)Resources.Load("Prefabs/enemyDeath");
		enemyDeath.transform.position = this.transform.position;
		enemyDeath.GetComponent<textureAnimation>().player = GameObject.FindGameObjectWithTag("Player");
		enemyDeath.GetComponent<textureAnimation>().setScore(scorePoints);
		GameObject.Instantiate(enemyDeath);



		Destroy(this.gameObject);
	}
}
