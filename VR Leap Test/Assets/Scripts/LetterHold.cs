using UnityEngine;
using UnityEngine.UI;

public class LetterHold : MonoBehaviour {




	[SerializeField] private TMPro.TextMeshProUGUI text;
	[SerializeField] private float speed = 1;

	private string previousLetter;
	private string currentLetter;

	public Image image;
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		currentLetter = text.text;

		if (currentLetter.Equals(previousLetter)) {
			image.fillAmount += Time.deltaTime * speed;
		} else
			image.fillAmount = 00;
		//if (image.fillAmount > 0) {
		//	image.fillAmount -= Time.deltaTime * speed;
		//}

		previousLetter = text.text;
	}
}
