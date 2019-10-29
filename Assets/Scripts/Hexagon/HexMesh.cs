using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
	// Hex mesh.
	Mesh hexMesh;
	List<Vector3> vertices;
	List<int> triangles;
	[SerializeField]
	List<Color> colors;
	public Vector3 height = new Vector3(0, Hexagon.height, 0);

	// Touching the cells.
	MeshCollider meshCollider;

	private void Awake() {
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
		meshCollider = gameObject.AddComponent<MeshCollider>();
		hexMesh.name = "Hex Mesh";

		// Hex.
		vertices = new List<Vector3>();
		colors = new List<Color>();
		triangles = new List<int>();
	}


	public void Triangulate(HexCell[] cells) {
		// Hex.
		hexMesh.Clear();
		vertices.Clear();
		colors.Clear();
		triangles.Clear();

		for(int i = 0; i < cells.Length; i++) {
			Triangulate(cells[i]);
		}

		// Hex.
		hexMesh.vertices = vertices.ToArray();
		hexMesh.colors = colors.ToArray();
		hexMesh.triangles = triangles.ToArray();
		hexMesh.RecalculateNormals();
		meshCollider.sharedMesh = hexMesh;
	}

	void Triangulate(HexCell cell) {
		Vector3 center = cell.transform.localPosition;
		Vector3 sinHeight = new Vector3(0, cell.height, 0);

		// Loop through all six corners of the hexagon.
		for (int i = 0; i < 6; i++) {
			// Bottom.
			AddTriangle(
				center,
				center + Hexagon.corners[i],
				center + Hexagon.corners[i + 1]);

			// Top.
			AddTriangle(
				center + sinHeight,
				center + sinHeight + Hexagon.corners[i],
				center + sinHeight + Hexagon.corners[i + 1]);

			// Plane filler.
			AddTriangle(
				center + Hexagon.corners[i],
				center + Hexagon.corners[i + 1],
				center + Hexagon.corners[i + 1] + sinHeight);
			AddTriangle(
				center + Hexagon.corners[i],
				center + Hexagon.corners[i + 1] + sinHeight,
				center + Hexagon.corners[i] + sinHeight);

			// Add color.
			AddTriangleColor(cell.color);
		}
	}

	// Add color to each triangle.
	void AddTriangleColor(Color color) {
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
	}
	
	// Creates triangle.
	void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3) {
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}
}
