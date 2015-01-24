using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class menuCharacter : MonoBehaviour {
	private float animationTimer;
	public float animationLag;
	public Sprite left_sprite1;
	public Sprite left_sprite2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 temp = this.transform.position;
			animationTimer += Time.deltaTime;
			if(GetComponent<Image>().sprite == left_sprite1 && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_sprite2;
				animationTimer = 0;
				
			}
			else if(GetComponent<Image>().sprite == left_sprite2 && animationTimer >= animationLag)
			{
				GetComponent<Image>().sprite = left_sprite1;
				animationTimer = 0;
			}
			temp.x -= 3f;
		this.transform.position = temp;
	}
}
