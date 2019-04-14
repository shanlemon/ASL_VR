using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour {

	public static SignManager INSTANCE;

	public List<string> signs = new List<string>();

	private void Awake() {
		if (INSTANCE == null) {
			INSTANCE = this;
		} else {
			Destroy(gameObject);
		}
	}
	public void add(string s) {
		signs.Add(s);
	}





}
