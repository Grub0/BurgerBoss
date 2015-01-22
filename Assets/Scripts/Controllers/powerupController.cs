using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class powerupController : MonoBehaviour {
	public int pointValue;
	// Use this for initialization
	void Start () 
	{
	}

	public void getGrabbed()
	{
		//Do something with score
		GameObject enemyDeath = (GameObject)Resources.Load("Prefabs/enemyDeath");
		enemyDeath.transform.position = this.transform.position;
		enemyDeath.GetComponent<textureAnimation>().player = GameObject.FindGameObjectWithTag("Player");
		enemyDeath.GetComponent<textureAnimation>().setScore(pointValue);
		GameObject.Instantiate(enemyDeath);
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
