using UnityEngine;

public class MyHandData : MonoBehaviour {

	public enum Handedness {
		Right, Left
	}

	public HandData data;

	// Start is called before the first frame update
	void Start() {
		data = new HandData();
	}

	// Update is called once per frame
	void Update() {
		//Debug.Log("Hand: " + gameObject.name);

		Debug.Log(gameObject.name + ": Thumb: " + data.thumb.knuckleSegment + " " + data.thumb.middleSegment + " " + data.thumb.endSegment);
		//Debug.Log("Index: " + data.indexFinger.knuckleSegment + " " + data.indexFinger.middleSegment + " " + data.indexFinger.endSegment);
		//Debug.Log("Middle: " + data.middleFinger.knuckleSegment + " " + data.middleFinger.middleSegment + " " + data.middleFinger.endSegment);
		//Debug.Log("Ring: " + data.ringFinger.knuckleSegment + " " + data.ringFinger.middleSegment + " " + data.ringFinger.endSegment);
		//Debug.Log("Pinky: " + data.littleFinger.knuckleSegment + " " + data.littleFinger.middleSegment + " " + data.littleFinger.endSegment);
	}
}
