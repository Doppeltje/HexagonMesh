using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexMapEditor : MonoBehaviour {
	public Color[] colors;
	public HexGrid hexGrid;
	private Color activeColor;

	int activeElevation;

	private void Awake() {
		SelectColor(0);
	}

	private void Update() {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}

	void HandleInput() {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			EditCell(hexGrid.GetCell(hit.point));
		}
	}

	void EditCell(HexCell cell) {
		cell.color = activeColor;
		cell.Elevation = activeElevation;
		hexGrid.Refresh();
	}

	public void SelectColor(int index) {
		activeColor = colors[index];
	}

	public void SetElevation(Slider slider) {
		activeElevation = (int)slider.value;
	}
}
