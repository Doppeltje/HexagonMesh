using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSinusPosition : MonoBehaviour {
	[SerializeField]
	HexGrid grid;
	float effect = 2f;

	// Hexagon vertical position.
	private void Update() {
		for (int i = 0; i < grid.cells.Length; i++) {
			Vector3 pos = grid.cells[i].transform.localPosition;
			pos.y = Mathf.Sin(Time.time + i) * 2f;
			grid.cells[i].transform.localPosition = pos;
			grid.Refresh();
		}
	}
}
