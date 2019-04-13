using System.IO;
using UnityEngine;

public class WriteJSON : MonoBehaviour {

	//float[] test1;
	//float[] test2;
	//float[] test3;
	//float[] test4;
	//float[] test5;

	//public HandData testData;


	//// Start is called before the first frame update
	//void Start() {
	//	test1 = new float[] { 100f, 2f, 3f };
	//	test2 = new float[] { 4f, 5f, 6f };
	//	test3 = new float[] { 7f, 8f, 9f };
	//	test4 = new float[] { 10f, 11f, 12f };
	//	test5 = new float[] { 13f, 14f, 15f };

	//	testData = new HandData(test1, test2, test3, test4, test5);

	//	string s = JsonUtility.ToJson(testData, true);
	//	Debug.Log(s);
	//	File.WriteAllText(Application.dataPath + "/test.json", s);

	//}

	private void Start() {
		Debug.Log(loadJSON("letterA").AllAngles[0]);
	}


	public static string saveJSON(HandData data, string name) {
		string s = JsonUtility.ToJson(data);
		string filePath = Application.dataPath + "/" + name + ".json";
		File.WriteAllText(filePath, s);
		return s;
	}

	public static HandData loadJSON(string name) {
		string filePath = Application.dataPath + "/" + name + ".json";
		string data = File.ReadAllText(filePath);
		//Debug.Log(data);
		HandData newData = JsonUtility.FromJson<HandData>(data);
		//Debug.Log(newData.AllAngles[0]);
		return JsonUtility.FromJson<HandData>(data);
	}
}
