using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexAudioHeight : MonoBehaviour {
	[SerializeField]
	HexGrid grid;
	float speed = 0.2f;
	float maxScale = 250f;

	// Hexagon height.
	private void Update() {
		for (int i = 0; i < grid.cells.Length; i++) {
			float audioHeight = AudioPeer.samples[i] * maxScale;
			float lerpHeight = Mathf.Lerp(grid.cells[i].height, audioHeight, speed);
			grid.cells[i].height = lerpHeight + Hexagon.height;
			grid.Refresh();
		}
	}
}
