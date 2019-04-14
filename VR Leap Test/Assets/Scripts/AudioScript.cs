using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip musicClip1;
	public AudioClip musicClip2;
	public AudioClip musicClip3;

	public AudioSource musicSource;

	private bool started = false;
	// Start is called before the first frame update
	void Start() {
		musicSource.clip = musicClip1;

	}

	// Update is called once per frame
	void Update() {
		if (SignManager.INSTANCE.signs.Contains("ThumbsUp") && !started) {
			musicSource.Play(2);
			Debug.Log("Starting");
			started = true;
			SignManager.INSTANCE.signs.Clear();
		}


	}
}
