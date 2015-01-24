using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enemyController : MonoBehaviour {
	#region Public Variables
	public GameObject player;
	public float speed;
	public int scorePoints;

	//Sprites
	public Sprite frame1;
	public Sprite frame2;
	public float frameTimer;
	public float timeTIlChange = .2f;
	#endregion

	#region Private Variables
	private Vector3 size;

	#endregion
	// Use this for initialization
	void Start () 
	{
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		size = this.transform.localScale;
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

		if(collision.gameObject.tag == "powerUp" || collision.gameObject.tag == "weapon" || collision.gameObject.tag == "enemy")
		{
			Physics.IgnoreCollision(collision.gameObject.collider, collider);
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
		frameTimer+= Time.deltaTime;
		if(frameTimer > timeTIlChange)
		{
			animate();
			frameTimer = 0;
		}
	}

	private void animate()
	{
		if(this.GetComponent<Image>().sprite == frame1)
		{
			this.GetComponent<Image>().sprite = frame2;
		}
		else
		{
			this.GetComponent<Image>().sprite = frame1;
		}
	}
	public void death()
	{
		//Do something with score
		GameObject enemyDeath = (GameObject)Resources.Load("Prefabs/Deaths/enemyDeath");
		enemyDeath.transform.position = this.transform.position;
		enemyDeath.GetComponent<textureAnimation>().player = GameObject.FindGameObjectWithTag("Player");
		enemyDeath.GetComponent<textureAnimation>().setScore(scorePoints);
		GameObject.Instantiate(enemyDeath);
		Destroy(this.gameObject);
	}
}
