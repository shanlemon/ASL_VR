using UnityEngine;

[System.Serializable]
public class HandData {

	public Finger thumb;
	public Finger indexFinger;
	public Finger middleFinger;
	public Finger ringFinger;
	public Finger littleFinger;

	public float[] AllAngles;

	public Quaternion handAngle;

	public HandData() {
		thumb = new Finger();
		indexFinger = new Finger();
		middleFinger = new Finger();
		ringFinger = new Finger();
		littleFinger = new Finger();
		AllAngles = new float[15];
	}

	public HandData(float[] thumb, float[] indexF, float[] middleF, float[] ringF, float[] littleF, Quaternion handAngle) {
		this.thumb = new Finger(thumb);
		indexFinger = new Finger(indexF);
		middleFinger = new Finger(middleF);
		ringFinger = new Finger(ringF);
		littleFinger = new Finger(littleF);
		this.handAngle = handAngle;

		AllAngles = new float[] {
			thumb[0], thumb[1], thumb[2],
			indexF[0], indexF[1], indexF[2],
			middleF[0], middleF[1], middleF[2],
			ringF[0], ringF[1], ringF[2],
			littleF[0], littleF[1], littleF[2],
		};
		//Debug.Log(AllAngles[0] + "inside init");
	}

	public void SetVars(float[] thumb, float[] indexF, float[] middleF, float[] ringF, float[] littleF, Quaternion handAngle) {
		this.thumb = new Finger(thumb);
		indexFinger = new Finger(indexF);
		middleFinger = new Finger(middleF);
		ringFinger = new Finger(ringF);
		littleFinger = new Finger(littleF);
		this.handAngle = handAngle;

		AllAngles = new float[] {
			thumb[0], thumb[1], thumb[2],
			indexF[0], indexF[1], indexF[2],
			middleF[0], middleF[1], middleF[2],
			ringF[0], ringF[1], ringF[2],
			littleF[0], littleF[1], littleF[2],
		};
		//Debug.Log(AllAngles[0] + "inside sset");
	}
}

[System.Serializable]
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
