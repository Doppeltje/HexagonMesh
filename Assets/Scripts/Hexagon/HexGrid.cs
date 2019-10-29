using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HexGrid : MonoBehaviour {
	// Grid size.
	public static int width = 3;
	public static int height = 3;

	public HexCell cellPrefab;
	public HexCell[] cells;
	public float hexHeight;
	HexMesh hexMesh;

	// Center grid.
	public GameObject centerGrid;

	// HUD Options.
	public int newWidth = 0;
	public int newHeight = 0;
	public Action newGrid;

	private void Awake() {
		hexMesh = GetComponentInChildren<HexMesh>();
	}

	public void Refresh() {
		hexMesh.Triangulate(cells);
	}

	public HexCell GetCell(Vector3 position) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
		return cells[index];
	}

	void CreateCell(int x, int z, int i) {
		hexHeight = Hexagon.height;
		Vector3 position;
		Vector3 position2;
		position.x = (x + z * 0.5f - z / 2) * (Hexagon.innerRadius * 2f) ;
		position.y = 0f;
		position.z = z * (Hexagon.outerRadius * 1.5f);

		position2.x = position.x + height;
		position2.y = position.y + height;
		position2.z = position.z + height;

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		//cell.transform.localPosition = (position + position2) / 2;
		cell.transform.localPosition = position;
	}

	public void AdjustWidth(InputField x) {
		newWidth = int.Parse(x.text);
	}

	public void AdjustHeight(InputField x) {
		newHeight = int.Parse(x.text);
	}

	public void RemakeGrid() {
		// Destroy previous grid.
		foreach (HexCell cell in cells) {
			Destroy(cell.gameObject);
		}

		cells = new HexCell[newHeight * newWidth];
		// Create grid.
		for (int z = 0, i = 0; z < newHeight; z++) {
			for (int x = 0; x < newWidth; x++) {
				CreateCell(x, z, i++);
			}
		}

		if (newGrid != null) {
			newGrid();
		}

		Vector3 centerPos = (cells[0].transform.position + cells[cells.Length-1].transform.position) / 2f;
		centerGrid.transform.position = centerPos;
		Refresh();
	}

}
