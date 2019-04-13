using UnityEngine;

public class HandData : MonoBehaviour {

	public Finger thumb;
	public Finger indexFinger;
	public Finger middleFinger;
	public Finger ringFinger;
	public Finger littleFinger;

	public HandData() {
		thumb = new Finger();
		indexFinger = new Finger();
		middleFinger = new Finger();
		ringFinger = new Finger();
		littleFinger = new Finger();
	}

	public HandData(float[] thumb, float[] indexF, float[] middleF, float[] ringF, float[] littleF) {
		this.thumb = new Finger(thumb);
		indexFinger = new Finger(indexF);
		middleFinger = new Finger(middleF);
		ringFinger = new Finger(ringF);
		littleFinger = new Finger(littleF);
	}

	public void SetVars(float[] thumb, float[] indexF, float[] middleF, float[] ringF, float[] littleF) {
		this.thumb = new Finger(thumb);
		indexFinger = new Finger(indexF);
		middleFinger = new Finger(middleF);
		ringFinger = new Finger(ringF);
		littleFinger = new Finger(littleF);
	}
}

public class Finger {
	public float knuckleSegment;
	public float middleSegment;
	public float endSegment;

	public Finger(float[] joints) {
		knuckleSegment = joints[0];
		middleSegment = joints[1];
		endSegment = joints[2];
	}

	public Finger() {
		knuckleSegment = 0f;
		middleSegment = 0f;
		endSegment = 0f;
	}

}
