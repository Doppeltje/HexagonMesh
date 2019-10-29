using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {
	public GameObject cubePrefab;
	private GameObject[] cubeArray = new GameObject[128];
	private float maxscale = 700f;
	private float cubeSize = 3f;

	private void Start() {
		for (int i = 0; i < cubeArray.Length; i++) {
			GameObject instanceCube = (GameObject)Instantiate(cubePrefab);
			instanceCube.transform.position = this.transform.position;
			instanceCube.transform.parent = this.transform;
			instanceCube.name = "Cube" + i;
			this.transform.eulerAngles = new Vector3(0, (360 / (float)cubeArray.Length) * i, 0);
			Debug.Log("360/length = " + (360 / (float)cubeArray.Length));
			instanceCube.transform.position = Vector3.forward * 100;
			cubeArray[i] = instanceCube;
		}
	}

	private void Update() {
		for (int i = 0; i < cubeArray.Length; i++) {
			if (cubeArray != null) {
				cubeArray[i].transform.localScale = new Vector3(
					cubeSize,
					AudioPeer.samples[i] * maxscale + (cubeSize/2),
					cubeSize);
			}
		}
	}
}
