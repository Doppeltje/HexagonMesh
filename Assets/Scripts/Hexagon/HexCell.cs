using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour {
	public HexCoordinates coordinates;
	public Color color;
	public float height = 2f;
	int elevation;

	public int Elevation {
		get {
			return elevation;
		}
		set {
			elevation = value;
			Vector3 position = transform.localPosition;
			position.y = value * Hexagon.elevationStep;
			transform.localPosition = position;
		}
	}
}
