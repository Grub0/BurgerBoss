using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enterHSController : MonoBehaviour {
	private globalStorage gst;
	private Text hsName;
	private Text currentlySelected;
	private string currentlySelectedAsString;
	private int currentlySelectedIndex = 0;
	// Use this for initialization
	void Start () 
	{
		gst = GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>();
		hsName = GameObject.FindGameObjectWithTag("highScoreName").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		handleLetterSelection();
	}

	private void handleLetterSelection()
	{
		if(Input.GetKeyDown("d"))
		{
			if((currentlySelectedIndex != 7) && (currentlySelectedIndex != 17) && (currentlySelectedIndex != 27))
			{
				currentlySelectedIndex += 1;
			}
		}
		if(Input.GetKeyDown("a"))
		{
			currentlySelectedIndex -= 1;
		}
		if(Input.GetKeyDown("w"))
		{
			currentlySelectedIndex -= 10;
		}
		if(Input.GetKeyDown("s"))
		{
			currentlySelectedIndex += 10;
		}

		if(currentlySelectedIndex < 10)
		{
			currentlySelectedAsString = currentlySelectedIndex.ToString();
		}
		else
		{
			currentlySelectedAsString = currentlySelected.ToString();
		}
		Debug.Log(currentlySelectedAsString);
	}
}
