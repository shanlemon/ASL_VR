using System.Collections.Generic;
using UnityEngine;

public class MyHandData : MonoBehaviour {

	public enum Handedness {
		Right, Left
	}

	public HandData data;

	[SerializeField] private TMPro.TextMeshProUGUI letterGuess;

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
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "A"));
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "B"));
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "C"));
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "D"));
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "E"));
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "F"));
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "G"));
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "H"));
		}
		if (Input.GetKeyDown(KeyCode.I)) {
			Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "I"));
		}
		//if (Input.GetKeyDown(KeyCode.J)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "J"));
		//}
		//if (Input.GetKeyDown(KeyCode.K)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterK"));
		//}
		//if (Input.GetKeyDown(KeyCode.L)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterL"));
		//}
		//if (Input.GetKeyDown(KeyCode.M)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterM"));
		//}
		//if (Input.GetKeyDown(KeyCode.N)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterN"));
		//}
		//if (Input.GetKeyDown(KeyCode.O)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterO"));
		//}
		//if (Input.GetKeyDown(KeyCode.P)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterP"));
		//}
		//if (Input.GetKeyDown(KeyCode.Q)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterQ"));
		//}
		//if (Input.GetKeyDown(KeyCode.R)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterR"));
		//}
		//if (Input.GetKeyDown(KeyCode.S)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterS"));
		//}
		//if (Input.GetKeyDown(KeyCode.T)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterT"));
		//}
		//if (Input.GetKeyDown(KeyCode.U)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterU"));
		//}
		//if (Input.GetKeyDown(KeyCode.V)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterV"));
		//}
		//if (Input.GetKeyDown(KeyCode.W)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterW"));
		//}
		//if (Input.GetKeyDown(KeyCode.X)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterX"));
		//}
		//if (Input.GetKeyDown(KeyCode.Y)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterY"));
		//}
		//if (Input.GetKeyDown(KeyCode.Z)) {
		//	Debug.Log("Saved Hand: " + WriteJSON.saveJSON(data, "letterZ"));
		//}

		if (letterGuess != null) {
			if (!data.active) {
				letterGuess.text = "";
			} else
				letterGuess.text = GetAccuracies().letter;
		} else
			GetAccuracies();

		//Debug.Log(gameObject.name + ": Thumb: " + data.thumb.knuckleSegment + " " + data.thumb.middleSegment + " " + data.thumb.endSegment);
		//Debug.Log("Index: " + data.indexFinger.knuckleSegment + " " + data.indexFinger.middleSegment + " " + data.indexFinger.endSegment);
		//Debug.Log("Middle: " + data.middleFinger.knuckleSegment + " " + data.middleFinger.middleSegment + " " + data.middleFinger.endSegment);
		//Debug.Log("Ring: " + data.ringFinger.knuckleSegment + " " + data.ringFinger.middleSegment + " " + data.ringFinger.endSegment);
		//Debug.Log("Pinky: " + data.littleFinger.knuckleSegment + " " + data.littleFinger.middleSegment + " " + data.littleFinger.endSegment);
	}

	public GuessLetter GetAccuracies() {
		//Debug.Log(WriteJSON.loadJSON("letterA").AllAngles[0]);
		List<GuessLetter> accuracies = new List<GuessLetter>();

		string[] signals = new string[] { "ThumbsUp", "A", "B",
			"C", "D", "E","F","G","H","I"};

		for (int i = 0; i < signals.Length; i++) {
			accuracies.Add(new GuessLetter(
				Mathf.Abs((float)Accuracy(data, WriteJSON.loadJSON(signals[i])) - 100),
				signals[i]));
		}


		accuracies.Sort((a, b) => a.accuracy.CompareTo(b.accuracy));
		//Debug.Log(gameObject.name + " " + accuracies[0].letter + " : " + accuracies[0].accuracy);
		return accuracies[0];
	}

	public static double Accuracy(HandData myHand, HandData signal) {
		double sum1 = 0;
		if (myHand.AllDistances != null) {
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
		return 100;
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