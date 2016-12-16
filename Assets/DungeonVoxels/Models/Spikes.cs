using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {


	public bool spikyOuch;
	public int time;
	public int number;
	//MeshRenderer renderer = new MeshRenderer();
	private float moveSpeed = 8f;
	public Transform[] WayPoints;
	public Transform currentWP;
	public int wpIndex;
	public bool whistle = false;
	public float beliefSpike;
	public static float beliefNo;
	public float beliefBarSpike;
	public float beliefBarNo;
	public float SNS = 1f;
	public float SNN = 0f;
	public float NNS = 0f;
	public float NNN = 1f;
	public float SWS = .2f;
	public float SWN = .8f;
	public float NWS = .3f;
	public float NWN = .7f;
	public float visionNN = .9f;
	public float visionNS = .1f;
	public float visionSS = .9f;
	public float visionSN = .1f;
	//public float visionSN = .3f;
	//public float visionNN = .7f;
	//public float visionNS = .3f;
	public float normalizer;
	float distance = 0f;
	public Text beliefNoText;
	public Slider SPIKEDOWN;
	public Slider SPIKEUP;
	public Slider noSpikeVision;
	public Slider spikeVision;
	public float downChance ;
	public float upChance ;



	// Use this for initialization
	void Start () {
		number = Random.Range(1,100);
		if (number > 50) {
			spikyOuch = true;
			wpIndex = 0;
		}
		else{
			spikyOuch = false;
			transform.Translate (Vector3.left*moveSpeed*Time.deltaTime);
			wpIndex = 1;
		}
		beliefNo = .5f;
		beliefSpike = .5f;
		beliefNoText.text = "Belief of No Spikes: " +beliefNo.ToString();
		SPIKEDOWN.value = NWS;
		SPIKEUP.value = SWN;
		noSpikeVision.value = visionNN;
		spikeVision.value = visionSS;
		//OnGUI ();
		//spikyOuch = true;
		//wpIndex = 0; 
		InvokeRepeating ("SpikeDecider", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {



		distance = Vector3.Distance (transform.position, WayPoints[wpIndex].position);
		//Debug.Log ("Made it here value " + distance + " WPINDEX  " + wpIndex);
		if (distance > 1) {
			if (wpIndex == 1) {
				transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);

			} else {

				transform.Translate (Vector3.right * moveSpeed * Time.deltaTime );
			}
		}

		beliefNoText.text = "Belief of No Spikes: " + beliefNo.ToString();
		SPIKEDOWN.onValueChanged.AddListener (delegate {
			NWN = SPIKEDOWN.value;;
		});
		;
		//NWS = SPIKEDOWN.value;
		SWS = SPIKEUP.value;
		NWS = 1 - NWN;
		SWN = 1 - SWS;
		//		if (Time.time %1 ==0 && spikyOuch == false) {
		visionNN = noSpikeVision.value;
		visionNS = 1 - noSpikeVision.value;
		visionSS = spikeVision.value;
		visionSN = 1 - spikeVision.value;

//			number = Random.Range(1,100);
//
//		}	
//		time-= Time.deltaTime;
////		if (Time.time > 3) {
////			number = 92;
////		}
//
//		if (number > 90) {
//			if (wpIndex == 0) {
//				wpIndex++;
//				spikyOuch = true;
//
//			}
//			if (spikyOuch == true  && transform.position.y > -1) {
//				transform.Translate (Vector3.left*moveSpeed*Time.deltaTime);
//				time = 5;
//				//(WayPoints [wpIndex].position ).normalized * moveSpeed * Time.deltaTime);
//			}
//		}


	}

	void SpikeDecider(){




			number = Random.Range (1, 100);
		downChance = 100 * NWN;
		upChance = 100 * SWS;

		if (wpIndex == 0 && !whistle) { //undo !,!!!
			if (number > (100 - downChance)){
				wpIndex++;
				spikyOuch = false;
				//transform.Translate (Vector3.left * moveSpeed );
			}
		}
		else if (wpIndex == 1 && !whistle) {
			if (number > (100 - upChance)) {
				wpIndex--;
				spikyOuch = true;
				//transform.Translate (-Vector3.left * moveSpeed );
			}



			//number = 50;
//			time = time - 1;
			//		if (Time.time > 3) {
			//			number = 92;
			//		}

//			if (wpIndex == 0 && !whistle) {
//				
//			} else if (wpIndex == 0 && whistle) { //undo !,!!!
//				if (number > 40){
//					wpIndex++;
//					spikyOuch = false;
//					//transform.Translate (Vector3.left * moveSpeed );
//				}
//			} else if (wpIndex == 1 && !whistle) {
//
//			} else if (wpIndex == 1 && whistle) {
//				if (number > 20) {
//					wpIndex--;
//					spikyOuch = true;
//					//transform.Translate (-Vector3.left * moveSpeed );
//				}
//





//			if (number > 70) {
//				if (wpIndex == 0) {
//					wpIndex++;
//					spikyOuch = false;
//
//				}
//				if (spikyOuch == false && transform.position.y > -8) {
//					transform.Translate (Vector3.left * moveSpeed );
//					time = 5;
//					//(WayPoints [wpIndex].position ).normalized * moveSpeed * Time.deltaTime);
//				}
//			}
		
		}
//		if (spikyOuch == false) {
//
//		}
		belief ();

		//if (!whistle) {
//
//			beliefBarSpike = SWS * beliefSpike + SWN * beliefNo;
//			beliefBarNo = NWS * beliefSpike + NWN * beliefNo;
//
//			beliefSpike = beliefBarSpike * vision;
//			beliefNo = beliefBarNo * vision;
//			Debug.Log (beliefBarNo + " "+ SWS + " " + SWN + " "+ NWS + " "+  NWN);
//
//			normalizer = 1/(beliefNo + beliefSpike);
//
//			beliefSpike = normalizer * beliefSpike;
//			beliefNo = normalizer * beliefNo;
//
//		} else {
//
//			beliefBarSpike = SNS * beliefSpike + SNN * beliefNo;
//			beliefBarNo = NNS * beliefSpike + NNN * beliefNo;
//
//			Debug.Log (beliefBarNo + SNS + SNN + NNS + NNN);
//			beliefSpike = beliefBarSpike * vision;
//			beliefNo = beliefBarNo * vision;
//
//			normalizer = 1/(beliefNo + beliefSpike);
//
//			beliefSpike = normalizer * beliefSpike;
//			beliefNo = normalizer * beliefNo;
//
//
//		}
		Debug.Log ("repeater " + beliefNo);

	}

	void belief(){
		if (!whistle) {

			beliefBarSpike = SWS * beliefSpike + SWN * beliefNo;
			beliefBarNo = NWS * beliefSpike + NWN * beliefNo;

			// if type of vision... 
			if (wpIndex == 1) {
				beliefSpike = beliefBarSpike * visionNS;
				beliefNo = beliefBarNo * visionNN;
				Debug.Log (beliefBarNo + " " + SWS + " " + SWN + " " + NWS + " " + NWN);
				normalizer = 1 / (beliefNo + beliefSpike);

				beliefSpike = normalizer * beliefSpike;
				beliefNo = normalizer * beliefNo;
			} else {
				beliefSpike = beliefBarSpike * visionSS;
				beliefNo = beliefBarNo * visionSN;
				Debug.Log (beliefBarNo + " " + SWS + " " + SWN + " " + NWS + " " + NWN);
				normalizer = 1 / (beliefNo + beliefSpike);

				beliefSpike = normalizer * beliefSpike;
				beliefNo = normalizer * beliefNo;

			}

}// else {
//
//			beliefBarSpike = SNS * beliefSpike + SNN * beliefNo;
//			beliefBarNo = NNS * beliefSpike + NNN * beliefNo;
//
//			beliefSpike = beliefBarSpike * visionSS;
//			beliefNo = beliefBarNo * visionNS;
//
//			normalizer = 1/(beliefNo + beliefSpike);
//
//			beliefSpike = normalizer * beliefSpike;
//			beliefNo = normalizer * beliefNo;
//
//
//		}

	}
//	public void setSWS()
//	{
//		SWS = SPIKEUP.value;
//
//	}
	void OnGUI(){
		//Here if the player hit the button Start will trigger an action
		if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 25), "Restart Game!")){
			//Here we call the method who will call the level named "LevelName"
			Application.LoadLevel("Markov");
		}
	}

}


