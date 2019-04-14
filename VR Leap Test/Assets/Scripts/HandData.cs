using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandData {

	public double[] AllDistances;

	public void SetVars(Vector3[] HandPos, Hand hand) {

		List<double> distances = new List<double>();
		//List<float> angles = new List<float>();

		Vector3 wristPos = hand.Arm.WristPosition.ToVector3();

		for (int i = 0; i < HandPos.Length - 1; i++) {
			for (int j = i + 1; j < HandPos.Length; j++) {
				distances.Add(System.Math.Round(Vector3.Distance(HandPos[i] - wristPos, HandPos[j] - wristPos), 3));
				//distances.Add(Vector3.Angle(HandPos[i] - wristPos, HandPos[j] - wristPos));
			}
		}

		distances.Add(hand.Direction.ToVector3().x);
		distances.Add(hand.Direction.ToVector3().y);
		distances.Add(hand.Direction.ToVector3().z);



		//foreach (Finger f in hand.Fingers) {
		//	directions.Add(f.Direction.ToVector3().x);
		//	directions.Add(f.Direction.ToVector3().y);
		//	directions.Add(f.Direction.ToVector3().z);
		//}
		//AllDirections = directions.ToArray();

		AllDistances = distances.ToArray();

	}
}

