using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Hexagon {
	public const float outerRadius = 10f;
	public const float innerRadius = outerRadius * 0.866025f; // Squareroot 3/2.
	public const float height = 1f;
	public const float elevationStep = 2f;

	// Color.
	public const float solidFactor = 0.85f;
	public const float blendFactor = 1f - solidFactor;

	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius),
		new Vector3(innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(0f, 0f, -outerRadius),
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
		new Vector3(0f, 0f, outerRadius)
	};

	//public static Vector3 GetFirstCorner 
}
