using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuitDudeScript : MonoBehaviour {


//	public double[] MarkovProbs; 
	public Transform[] WayPoints;
	public int wpIndex;
	public float MoveSpeed = 5f;
	public float prob; 
	public float moveThresh = .73f;
	public RaycastHit vision; 
	public float distance;
	public float moveSpeed = 5f;
	public Text WinText;
	public static bool win = false;
	public Slider moveThreshold;

	public float RunSpeed = 10f;
	// Use this for initialization
	void Start () {
		wpIndex = 0;
		prob = .5f;
		WinText.text = "";
		moveThreshold.value = moveThresh;
	}
	
	// Update is called once per frame
	void Update () {
		//float movement = Input.GetAxis ("Horizontal") * RunSpeed;
		prob = Spikes.beliefNo;
		//Debug.Log ("prob " + prob);
		if (prob > moveThresh && wpIndex == 0) { // prob is satisfied
			wpIndex++;

		}
			distance = Vector3.Distance (transform.position, WayPoints[wpIndex].position);
			//Debug.Log ("Made it here value " + distance + " WPINDEX  " + wpIndex);
			if (distance > 1) {
				if (wpIndex == 1) {
					transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
				}
			}

		if (wpIndex == 1 && distance < 2) {
			WinText.text = "OODLES OF MONEYS!"; 
			win = true;
			//Debug.Log ("Win Win");
		}
		moveThresh = moveThreshold.value;
	}
}
