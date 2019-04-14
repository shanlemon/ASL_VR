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

		if (currentLetter.Equals(previousLetter) && image.fillAmount <= 1 && !currentLetter.Equals("")) {
			image.fillAmount += Time.deltaTime * speed;
		} else
			image.fillAmount = 0;

		if (image.fillAmount >= 1) {
			SignManager.INSTANCE.add(currentLetter);
			Debug.Log(currentLetter + " pressed");
			image.fillAmount = 0;
		}

		//if (image.fillAmount > 0) {
		//	image.fillAmount -= Time.deltaTime * speed;
		//}

		previousLetter = text.text;
	}

	private void clearLetter() {
		currentLetter = "";
	}
}
