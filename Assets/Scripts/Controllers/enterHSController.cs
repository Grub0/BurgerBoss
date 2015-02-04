using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class enterHSController : MonoBehaviour {
	private globalStorage gst;
	private Text hsName;
	public string hsNameString;
	private GameObject currentlySelected;
	private int row = 0;
	private int collumn = 0;
	private string currentlySelectedPath;
	// Use this for initialization
	void Start () 
	{
		gst = GameObject.FindGameObjectWithTag("globalStorage").GetComponent<globalStorage>();
		hsName = GameObject.FindGameObjectWithTag("highScoreName").GetComponent<Text>();
		currentlySelected = GameObject.Find("Row "+row+"/"+collumn);
	}
	
	// Update is called once per frame
	void Update () 
	{
		handleLetterSelection();
		handleLetterGettingPicked();
		currentlySelected.GetComponent<Text>().color = Color.white;
	}

	private void handleLetterSelection()
	{
		int tempRow = row;
		int tempCollumn = collumn;
		if(Input.GetKeyDown("d"))
		{
			tempCollumn += 1;
		}
		if(Input.GetKeyDown("a"))
		{
			tempCollumn -= 1;
		}
		if(Input.GetKeyDown("w"))
		{
			tempRow-=1;
		}
		if(Input.GetKeyDown("s"))
		{
			tempRow+=1;
		}
		if(tempRow >= 0 && tempRow <=3 &&(GameObject.Find("Row "+tempRow+"/"+tempCollumn) != null))
		{
			row = tempRow;
			currentlySelected.GetComponent<Text>().color = Color.red;
			currentlySelected = GameObject.Find("Row "+row+"/"+collumn);
		}
		if(tempCollumn >= 0 && tempCollumn <=7&&(GameObject.Find("Row "+tempRow+"/"+tempCollumn) != null))
		{
			collumn = tempCollumn;
			currentlySelected.GetComponent<Text>().color = Color.red;
			currentlySelected = GameObject.Find("Row "+row+"/"+collumn);
		}
		//Debug.Log(currentlySelectedAsString);
	}

	private void handleLetterGettingPicked()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(currentlySelected.GetComponent<Text>().text == "back")
			{
				//hsNameString.Remove((hsNameString.Length-1),1);
				if(hsNameString.Length > 0)
				{
					hsNameString  = hsNameString.Substring(0, hsNameString.Length - 1);
				}
			}
			else if(currentlySelected.GetComponent<Text>().text == "enter")
			{
				gst.highScoreText = hsName.text;
				Application.LoadLevel("splash");
			}

			else
			{
				if(hsNameString.Length + 1 < 7)
				{
					hsNameString+=currentlySelected.GetComponent<Text>().text.ToString();
				}
			}
			if(hsNameString.Length < 7)
			{
				hsName.text = hsNameString;
			}
		}
	}
}
