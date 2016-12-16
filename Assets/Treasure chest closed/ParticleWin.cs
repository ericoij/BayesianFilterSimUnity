using UnityEngine;
using System.Collections;

public class ParticleWin : MonoBehaviour {

	public bool win = false;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		win = SuitDudeScript.win;
		if (win) {
			gameObject.SetActive (true);
			Debug.Log ("WIN WIN WIN");
		}
	}
}
