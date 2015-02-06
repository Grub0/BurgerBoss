using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class characterController : MonoBehaviour {
	#region privateVariables
	private bool jumping;
	private bool attacking;
	private float startingHeight;
	private float attackTimer;
	private bool right;
	private bool hasWeapon;
	//The time that needs to elapse for a new frame of the movement animation to show
	private GameObject globalStorage;
	private GameObject gameOver;
	#endregion

	#region publicVariables
	public float jumpHeight;
	public float jumpSpeed;

	//Sprite Variables
	public Sprite right_open_weapon;
	public Sprite right_closed_weapon;
	public Sprite left_open_weapon;
	public Sprite left_closed_weapon;

	public Sprite right_open;
	public Sprite right_closed;
	public Sprite left_open;
	public Sprite left_closed;

	private Sprite right_sprite1;
	private Sprite right_sprite2;
	private Sprite left_sprite1;
	private Sprite left_sprite2;

	public Sprite left_attacking;
	public Sprite right_attacking;

	public float animationLag = .05f;
	public float animationTimer;

	//Audio Source Objects
	public GameObject powerupAudio;
	public int score;
	#endregion
	void Awake()
	{
		powerupAudio = GameObject.FindGameObjectWithTag("pupAudio");
		gameOver = GameObject.FindGameObjectWithTag("gameOver");
		globalStorage = GameObject.FindGameObjectWithTag("globalStorage");
		score = globalStorage.GetComponent<globalStorage>().score;
		setScore();
	}
	// Use this for initialization
	void Start () 
	{
		right_sprite1 = right_open;
		right_sprite2 = right_closed;
		left_sprite1 = left_open;
		left_sprite2 = left_closed;
		//gainWeapon();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOver.GetComponent<gameOverController>().activated == false)
		{
		move();
		jump ();
		attack();
		}
		else
		{
			Destroy(rigidbody);
		}
	}

	public void setScore()
	{
		GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text = string.Format("{0:n0}", score);
	}
	public void getPrincess()
	{
		globalStorage.GetComponent<globalStorage>().score = this.score;
		GameObject.FindGameObjectWithTag("gameOver").GetComponent<gameOverController>().activated = true;
	}
	public void death()
	{
		globalStorage.GetComponent<globalStorage>().score = score;
		globalStorage.GetComponent<globalStorage>().startingLives -=1;
		if(globalStorage.GetComponent<globalStorage>().startingLives == -1)
		{
			GameObject death = (GameObject)Resources.Load("Prefabs/Deaths/playerDeath");
			death.transform.position = this.transform.position;
			GameObject.Instantiate(death);
			Destroy(gameObject);
		}
		else if(globalStorage.GetComponent<globalStorage>().startingLives > -1)
		{
			globalStorage.GetComponent<globalStorage>().score = this.score;
			GameObject death = (GameObject)Resources.Load("Prefabs/Deaths/playerDeath");
			death.transform.position = this.transform.position;
			GameObject.Instantiate(death);
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "killBox")
		{
			death();
		}
		if(collision.gameObject.tag == "enemy")
		{
			if(attacking == false)
			{
				death();
			}
			else if(attacking == true)
			{
				collision.gameObject.GetComponent<enemyController>().death();
			}
		}
		if(collision.gameObject.tag == "weapon")
		{
			gainWeapon();
			collision.gameObject.GetComponent<AudioSource>().Play();
			Destroy(collision.gameObject);
			//Debug.Log("Touching Weapon");
		}

		if(collision.gameObject.tag == "powerUp")
		{
			collision.gameObject.GetComponent<powerupController>().getGrabbed();
			//Debug.Log("Touching Weapon");
		}
	}
	private void gainWeapon()
	{
		right_sprite1 = right_open_weapon;
		right_sprite2 = right_closed_weapon;
		left_sprite1 = left_open_weapon;
		left_sprite2 = left_closed_weapon;
		if((GetComponent<Image>().sprite == left_open|| GetComponent<Image>().sprite == left_closed))
		{
			GetComponent<Image>().sprite = left_sprite1;
			animationTimer = 0;
		}
		else if((GetComponent<Image>().sprite == right_open|| GetComponent<Image>().sprite == right_closed))
		{
			GetComponent<Image>().sprite = right_sprite1;
			animationTimer = 0;
		}
		hasWeapon = true;
		powerupAudio.GetComponent<AudioSource>().Play();
	}
	private void move()
	{
		Vector2 temp = this.transform.position;
		if(Input.GetKey("a"))
		{
			animationTimer += Time.deltaTime;
			if((GetComponent<Image>().sprite == left_sprite1|| GetComponent<Image>().sprite == right_sprite1 || GetComponent<Image>().sprite == right_sprite2) && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_sprite2;
				animationTimer = 0;

			}
			else if(GetComponent<Image>().sprite == left_sprite2 && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_sprite1;
				animationTimer = 0;
			}
			temp.x -= 5f;
		}
		if(Input.GetKey("d"))
		{
			animationTimer += Time.deltaTime;
			if((GetComponent<Image>().sprite == right_sprite1 || GetComponent<Image>().sprite == left_sprite1 || GetComponent<Image>().sprite == left_sprite2) && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = right_sprite2;
				animationTimer = 0;

			}
			else if(GetComponent<Image>().sprite == right_sprite2 && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = right_sprite1;
				animationTimer = 0;
			}
			temp.x += 5f;
		}
		this.transform.position = temp;
	}

	private void attack()
	{
		if(Input.GetKeyDown("space") && attacking == false && hasWeapon == true)
		{
			attacking = true;
			if((this.GetComponent<Image>().sprite == right_open_weapon)||(this.GetComponent<Image>().sprite == right_closed_weapon))
			{
				this.GetComponent<Image>().sprite = right_attacking;
				this.transform.localScale = new Vector2(1.2f,1f);
				this.GetComponent<BoxCollider>().size = new Vector2(120f,100f);

				
			}
			else if((this.GetComponent<Image>().sprite == left_open_weapon)||this.GetComponent<Image>().sprite == left_closed_weapon)
			{
				this.GetComponent<Image>().sprite = left_attacking;
				this.transform.localScale = new Vector2(1.2f,1f);
				this.GetComponent<BoxCollider>().size = new Vector2(120f,100f);

			}
		}

		if(attacking == true)
		{
			attackTimer += Time.deltaTime;
			if(attackTimer > 0.2f)
			{
				attacking = false;
				attackTimer = 0;
			}
		}
		else if(attacking == false)
		{
			if(this.GetComponent<Image>().sprite == left_attacking)
			{
				this.transform.localScale = new Vector2(1f,1f);
				this.GetComponent<Image>().sprite = left_closed_weapon;
				this.GetComponent<BoxCollider>().size = new Vector2(60f,100f);

				
			}
			else if(this.GetComponent<Image>().sprite == right_attacking)
			{
				this.transform.localScale = new Vector2(1f,1f);

				this.GetComponent<Image>().sprite = right_closed_weapon;
				this.GetComponent<BoxCollider>().size = new Vector2(60f,100f);

				
			}
		}
	}

	private void jump()
	{
		if(Input.GetKeyDown("w") && jumping == false &&  rigidbody.velocity.y > -0.4f)
		{
			jumping = true;
			startingHeight = transform.position.y;
			rigidbody.useGravity = false;
		}
		
		if(jumping == true)
		{
			Vector2 tempPos = transform.position;
			Vector2 goalPos = new Vector2(tempPos.x, startingHeight + jumpHeight);
			transform.position = Vector2.MoveTowards(tempPos,goalPos,jumpSpeed);
			if(tempPos.y >= startingHeight + jumpHeight -10f)
			{
				jumping = false;
				rigidbody.useGravity = true;
			}
		}
	}
}
