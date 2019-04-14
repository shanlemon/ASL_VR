using System.Collections.Generic;
using UnityEngine;

public class MyHandData : MonoBehaviour {

	public enum Handedness {
		Right, Left
	}

	public HandData data;

	private void Start() {
		data = new HandData();
	}

	// Update is called once per frame
	void Update() {
		//Debug.Log("Hand: " + gameObject.name);
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "ThumbsUp"));
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterA"));
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterB"));
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterC"));
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterD"));
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterE"));
		}



		GetAccuracies();


		//Debug.Log(gameObject.name + ": Thumb: " + data.thumb.knuckleSegment + " " + data.thumb.middleSegment + " " + data.thumb.endSegment);
		//Debug.Log("Index: " + data.indexFinger.knuckleSegment + " " + data.indexFinger.middleSegment + " " + data.indexFinger.endSegment);
		//Debug.Log("Middle: " + data.middleFinger.knuckleSegment + " " + data.middleFinger.middleSegment + " " + data.middleFinger.endSegment);
		//Debug.Log("Ring: " + data.ringFinger.knuckleSegment + " " + data.ringFinger.middleSegment + " " + data.ringFinger.endSegment);
		//Debug.Log("Pinky: " + data.littleFinger.knuckleSegment + " " + data.littleFinger.middleSegment + " " + data.littleFinger.endSegment);
	}

	private void GetAccuracies() {
		//Debug.Log(WriteJSON.loadJSON("letterA").AllAngles[0]);
		List<GuessLetter> accuracies = new List<GuessLetter>();

		string[] signals = new string[] { "ThumbsUp", "letterA", "letterB",
			"letterC", "letterD", "letterE"};

		for (int i = 0; i < signals.Length; i++) {
			accuracies.Add(new GuessLetter(
				Mathf.Abs((float)Accuracy(data, WriteJSON.loadJSON(signals[i])) - 100),
				signals[i]));
		}


		accuracies.Sort((a, b) => a.accuracy.CompareTo(b.accuracy));
		Debug.Log(gameObject.name + " " + accuracies[0].letter + " : " + accuracies[0].accuracy);
	}

	public static double Accuracy(HandData myHand, HandData signal) {
		double sum1 = 0;

		for (int i = 0; i < myHand.AllDistances.Length; i++) {
			//Debug.Log(myHand.AllAngles[i] + " / " + signal.AllAngles[i]);
			sum1 += myHand.AllDistances[i] / signal.AllDistances[i];
		}

		double avg1 = sum1 / myHand.AllDistances.Length;

		//float sum2 = 0;

		//for (int i = 0; i < myHand.AllDirections.Length; i++) {
		//	//Debug.Log(myHand.AllAngles[i] + " / " + signal.AllAngles[i]);
		//	sum2 += myHand.AllDirections[i] /
		//		signal.AllDirections[i];
		//}

		//float avg2 = sum2 / myHand.AllDirections.Length;

		return avg1 * 100;
	}
}


public class GuessLetter {
	public double accuracy;
	public string letter;

	public GuessLetter(double accuracy, string letter) {
		this.accuracy = accuracy;
		this.letter = letter;
	}
}