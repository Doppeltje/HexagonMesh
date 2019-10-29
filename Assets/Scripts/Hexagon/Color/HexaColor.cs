using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaColor : MonoBehaviour {
	public HexGrid _grid;
	private float sampleMultiplier = 700f;
	private float normalize = 255f;
	private Color darkColor = new Color(0f, 0.0f, 0.01f);
	private Color classicColor = new Color(0.6f, 0.6f, 0.6f);

	private float minValue = 2f;
	private float lowValue = 30f;
	private float midValue = 80f;

	public enum Themes {
		Dark, Classic, Colors, Light, DarkRed
	}

	public Themes theme = Themes.Dark;

	private Color color;

	private void Update() {
		if (_grid.cells.Length > 0) {
			switch (theme) {
				case Themes.Dark:
					Dark();
					break;
				case Themes.Classic:
					Classic();
					break;
				case Themes.Colors:
					Colors();
					break;
				case Themes.Light:
					Light();
					break;
				case Themes.DarkRed:
					DarkRed();
					break;
				default:
					break;
			}
		}
	}

	public void Dark() {
		for (int i = 0; i < _grid.cells.Length; i++) {
			_grid.cells[i].color = darkColor;
		}
	}

	public void DarkRed() {
		for (int i = 0; i < _grid.cells.Length; i++) {
			float newColor = AudioPeer.samples[i] * sampleMultiplier;
			color = new Color(newColor / normalize, 0f, 0f);
			_grid.cells[i].color = color;
		}
	}

	public void Light() {
		for (int i = 0; i < _grid.cells.Length; i++) {
			float newColor = AudioPeer.samples[i] * sampleMultiplier;
			color = new Color(200f/normalize, 200f / normalize, 200f / normalize);
			_grid.cells[i].color = color;
		}
	}

	public void Classic() {
		for (int i = 0; i < _grid.cells.Length; i++) {
			float newColor = AudioPeer.samples[i] * sampleMultiplier;
			//color = new Color(233f / normalize, 235f / normalize, 0f);
			color = new Color(newColor / normalize, newColor / normalize, 0f);
			_grid.cells[i].color = classicColor;
		}
	}

	public void Colors() {
		for (int i = 0; i < _grid.cells.Length; i++) {
			float newColor = AudioPeer.samples[i] * sampleMultiplier;

			if (newColor > midValue) {
				color = new Color(191f * newColor / normalize / normalize, 38f * newColor / normalize / normalize, 11f * newColor / normalize / normalize);
			} else if (newColor > lowValue) {
				color = new Color(200f * newColor / normalize / normalize, 80f * newColor / normalize / normalize, 6f * newColor / normalize / normalize);
			} else if (newColor > minValue) {
				color = new Color(10f * newColor / normalize / normalize, 163f * newColor / normalize / normalize, 35f * newColor / normalize / normalize);
			} else {
				color = darkColor;
			}

			//_grid.cells[i].color = color + darkColor * 0.7f;
			_grid.cells[i].color = color;
		}
	}

	// UI Buttons.
	public void ButtonDark() {
		theme = Themes.Dark;
	}

	public void ButtonClassic() {
		theme = Themes.Classic;
	}

	public void ButtonColors() {
		theme = Themes.Colors;
	}

	public void ButtonLight() {
		theme = Themes.Light;
	}

	public void ButtonDarkRed() {
		theme = Themes.DarkRed;
	}
}
