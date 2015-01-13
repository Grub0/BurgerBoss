using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class characterController : MonoBehaviour {
	#region privateVariables
	private bool jumping;
	private bool attacking;
	private float startingHeight;
	#endregion

	#region publicVariables
	public float jumpHeight;
	public float jumpSpeed;
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
	}
	private void move()
	{
		Vector2 temp = this.transform.position;

		if(Input.GetKey("s"))
		{
			temp.y -= 5f;
		}
		if(Input.GetKey("a"))
		{
			temp.x -= 5f;
		}
		if(Input.GetKey("d"))
		{
			temp.x += 5f;
		}
		this.transform.position = temp;
	}

	private void attack()
	{
		if(Input.GetKeyDown("space") && attacking == false)
		{
			this.GetComponent<Image>().color = Color.red;
			attacking = true;
		}

		if(attacking == true)
		{
			//this.GetComponent<Image>().color = Color.white;
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
