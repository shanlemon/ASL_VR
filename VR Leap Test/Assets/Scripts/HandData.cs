using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandData {

	//public float ThumbToPalm;
	//public float IndexToPalm;
	//public float MiddleToPalm;
	//public float RingToPalm;
	//public float PinkyToPalm;

	//public float ThumbToIndex;
	//public float IndexToMiddle;
	//public float MiddleToRing;
	//public float RingToPinky;

	public float[] AllDistances;

	public HandData(Vector3[] HandPos) {

		List<float> distances = new List<float>();

		for (int i = 0; i < HandPos.Length - 1; i++) {
			for (int j = i + 1; j < HandPos.Length; j++) {
				distances.Add(Vector3.Distance(HandPos[i], HandPos[j]));
			}
		}

		//ThumbToPalm = Vector3.Distance(thumb, palm);
		//IndexToPalm = Vector3.Distance(indexF, palm);
		//MiddleToPalm = Vector3.Distance(middleF, palm);
		//RingToPalm = Vector3.Distance(ringF, palm);
		//PinkyToPalm = Vector3.Distance(littleF, palm);
		//ThumbToIndex = Vector3.Distance(thumb, indexF);
		//IndexToMiddle = Vector3.Distance(indexF, middleF);
		//MiddleToRing = Vector3.Distance(middleF, ringF);
		//RingToPinky = Vector3.Distance(ringF, littleF);

		//AllDistances = new float[] {ThumbToPalm, IndexToPalm,
		//	MiddleToPalm, RingToPalm, PinkyToPalm,
		//	ThumbToIndex,IndexToMiddle, MiddleToRing, RingToPinky
		//};
		AllDistances = distances.ToArray();

	}

	public void SetVars(Vector3[] HandPos) {

		List<float> distances = new List<float>();

		for (int i = 0; i < HandPos.Length - 1; i++) {
			for (int j = i + 1; j < HandPos.Length; j++) {
				distances.Add(Vector3.Distance(HandPos[i], HandPos[j]));
			}
		}

		//ThumbToPalm = Vector3.Distance(thumb, palm);
		//IndexToPalm = Vector3.Distance(indexF, palm);
		//MiddleToPalm = Vector3.Distance(middleF, palm);
		//RingToPalm = Vector3.Distance(ringF, palm);
		//PinkyToPalm = Vector3.Distance(littleF, palm);
		//ThumbToIndex = Vector3.Distance(thumb, indexF);
		//IndexToMiddle = Vector3.Distance(indexF, middleF);
		//MiddleToRing = Vector3.Distance(middleF, ringF);
		//RingToPinky = Vector3.Distance(ringF, littleF);

		//AllDistances = new float[] {ThumbToPalm, IndexToPalm,
		//	MiddleToPalm, RingToPalm, PinkyToPalm,
		//	ThumbToIndex,IndexToMiddle, MiddleToRing, RingToPinky
		//};

		AllDistances = distances.ToArray();

	}
}

