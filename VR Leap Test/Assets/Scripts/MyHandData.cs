using System.Collections.Generic;
using UnityEngine;

public class MyHandData : MonoBehaviour {

	public enum Handedness {
		Right, Left
	}

	public HandData data;

	// Start is called before the first frame update
	void Start() {
		//data = new HandData();
	}

	// Update is called once per frame
	void Update() {
		//Debug.Log("Hand: " + gameObject.name);
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterB"));
		}

		//Debug.Log(WriteJSON.loadJSON("letterA").AllAngles[0]);
		List<GuessLetter> accuracies = new List<GuessLetter>();

		string[] signals = new string[] { "ThumbsUp", "letterA", "letterB",
			"letterC", "letterD", "letterE", "letterF","letterG","letterH"};

		for (int i = 0; i < signals.Length; i++) {
			accuracies.Add(new GuessLetter(
				Mathf.Abs(Accuracy(data, WriteJSON.loadJSON(signals[i])) - 100f),
				signals[i]));
		}
		accuracies.Sort((a, b) => a.accuracy.CompareTo(b.accuracy));
		Debug.Log(accuracies[0].letter + " : " + accuracies[0].accuracy);


		//Debug.Log(gameObject.name + ": Thumb: " + data.thumb.knuckleSegment + " " + data.thumb.middleSegment + " " + data.thumb.endSegment);
		//Debug.Log("Index: " + data.indexFinger.knuckleSegment + " " + data.indexFinger.middleSegment + " " + data.indexFinger.endSegment);
		//Debug.Log("Middle: " + data.middleFinger.knuckleSegment + " " + data.middleFinger.middleSegment + " " + data.middleFinger.endSegment);
		//Debug.Log("Ring: " + data.ringFinger.knuckleSegment + " " + data.ringFinger.middleSegment + " " + data.ringFinger.endSegment);
		//Debug.Log("Pinky: " + data.littleFinger.knuckleSegment + " " + data.littleFinger.middleSegment + " " + data.littleFinger.endSegment);
	}

	public static float Accuracy(HandData myHand, HandData signal) {
		float sum = 0;

		for (int i = 0; i < myHand.AllDistances.Length; i++) {
			//Debug.Log(myHand.AllAngles[i] + " / " + signal.AllAngles[i]);
			sum += myHand.AllDistances[i] / signal.AllDistances[i];
		}

		float avg = sum / myHand.AllDistances.Length;

		return avg * 100;
	}
}


public class GuessLetter {
	public float accuracy;
	public string letter;

	public GuessLetter(float accuracy, string letter) {
		this.accuracy = accuracy;
		this.letter = letter;
	}
}