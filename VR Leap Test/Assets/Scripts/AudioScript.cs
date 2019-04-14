using System.Collections;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip musicClip1;
	public AudioClip musicClip2;

	public AudioSource musicSource;

	private float time;

	private bool started = false;
	public GameObject signs;

	// Start is called before the first frame update
	void Start() {
		musicSource.clip = musicClip1;
		StartCoroutine(playInTime(10));
	}

	IEnumerator playInTime(float secs) {
		yield return new WaitForSeconds(secs);
		musicSource.Play();

	}


	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
		if (SignManager.INSTANCE.signs.Contains("ThumbsUp") && !started && time > 65f) {
			musicSource.clip = musicClip2;
			signs.SetActive(true);
			musicSource.Play();
			started = true;
			SignManager.INSTANCE.signs.Clear();
		}


	}
}
