using System.Collections;
using UnityEngine;

public class DisableInTime : MonoBehaviour {

	public float time;
	public bool value = false;
	// Start is called before the first frame update
	void Start() {
		StartCoroutine(waitThenDisable(time));
	}

	IEnumerator waitThenDisable(float secs) {
		yield return new WaitForSeconds(secs);
		gameObject.SetActive(value);
	}
}
