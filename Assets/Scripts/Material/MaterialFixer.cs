using UnityEngine;
using UnityEngine.UI;

public class MaterialFixer : MonoBehaviour {
	void Awake() {
		Image canvasElement = gameObject.AddComponent<Image>();
		canvasElement.material.color = Color.white;
	}
}