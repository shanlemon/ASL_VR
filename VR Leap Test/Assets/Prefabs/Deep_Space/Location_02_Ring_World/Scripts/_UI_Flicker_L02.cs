using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class _UI_Flicker_L02 : MonoBehaviour {

	public Image img;
	public Image img2;

	void Start () {

		StartCoroutine(Disp());
		img.enabled = false;
		img2.enabled = false;
	}

	IEnumerator Disp()
	{
		while(true)
		{
			img.enabled = true;
			img2.enabled = true;
			yield return new WaitForSeconds(0.5f);
			img.enabled = false;
			img2.enabled = false;
			yield return new WaitForSeconds(0.5f);
			yield return null;
	}
}
}
