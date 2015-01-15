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
	//The time that needs to elapse for a new frame of the movement animation to show

	#endregion

	#region publicVariables
	public float jumpHeight;
	public float jumpSpeed;

	//Sprite Variables
	public Sprite right_open_weapon;
	public Sprite right_closed_weapon;
	public Sprite left_open_weapon;
	public Sprite left_closed_weapon;
	public Sprite left_attacking;
	public Sprite right_attacking;
	public float animationLag = .05f;
	public float animationTimer;
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		move();
		jump ();
		attack();
	}
	private void death()
	{
		Application.LoadLevel(Application.loadedLevel);

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
	}
	private void move()
	{
		Vector2 temp = this.transform.position;
		if(Input.GetKey("a"))
		{
			animationTimer += Time.deltaTime;
			if((GetComponent<Image>().sprite == left_open_weapon|| GetComponent<Image>().sprite == right_open_weapon || GetComponent<Image>().sprite == right_closed_weapon) && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_closed_weapon;
				animationTimer = 0;

			}
			else if(GetComponent<Image>().sprite == left_closed_weapon && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_open_weapon;
				animationTimer = 0;

				
			}
			temp.x -= 5f;
		}
		if(Input.GetKey("d"))
		{
			animationTimer += Time.deltaTime;
			if((GetComponent<Image>().sprite == right_open_weapon || GetComponent<Image>().sprite == left_open_weapon || GetComponent<Image>().sprite == left_closed_weapon) && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = right_closed_weapon;
				animationTimer = 0;

			}
			else if(GetComponent<Image>().sprite == right_closed_weapon && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = right_open_weapon;
				animationTimer = 0;
			}
			temp.x += 5f;
		}
		this.transform.position = temp;
	}

	private void attack()
	{
		if(Input.GetKeyDown("space") && attacking == false)
		{
			attacking = true;
			if((this.GetComponent<Image>().sprite == right_open_weapon)||(this.GetComponent<Image>().sprite == right_closed_weapon))
			{
				this.GetComponent<Image>().sprite = right_attacking;
				this.transform.localScale = new Vector2(1.2f,1f);
			}
			else if((this.GetComponent<Image>().sprite == left_open_weapon)||this.GetComponent<Image>().sprite == left_closed_weapon)
			{
				this.GetComponent<Image>().sprite = left_attacking;
				this.transform.localScale = new Vector2(1.2f,1f);

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
			}
			else if(this.GetComponent<Image>().sprite == right_attacking)
			{
				this.transform.localScale = new Vector2(1f,1f);

				this.GetComponent<Image>().sprite = right_closed_weapon;
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
