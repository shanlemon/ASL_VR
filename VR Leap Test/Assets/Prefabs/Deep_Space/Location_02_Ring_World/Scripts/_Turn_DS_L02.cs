using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Turn_DS_L02 : MonoBehaviour {

	public float SpeedY = 0.01f;
	public float SpeedZ = 0.0f;

	void Start () {
		
	}

	void Update(){
		transform.Rotate(0, SpeedY, SpeedZ);
	}
}
