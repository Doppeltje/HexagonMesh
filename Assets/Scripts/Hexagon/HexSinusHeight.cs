using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSinusHeight : MonoBehaviour {
	[SerializeField]
	HexGrid grid;
	float effect = 2f;

	// Hexagon height.
	private void Update() {
		for (int i = 0; i < grid.cells.Length; i++) {
			float sinHeight = Mathf.Sin(Time.time + i) * effect + (Hexagon.height * 3f);
			grid.cells[i].height = sinHeight;
			grid.Refresh();
		}
	}
}
