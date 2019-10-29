using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {
	public GameObject target;
	public HexGrid _grid;
	public AudioPeer _audioPeer;
	float baseSpeed = 25f;
	float speed;
	float slowSpeed = 0.5f;
	float speedLerp;
	bool playing = false;

	// Camera default.
	private Vector3 defaultPos = new Vector3(11f, 53.1f, -75.3f);

	private void Start() {
		_grid.newGrid += ResetPos;
		_audioPeer.playOrPause += TogglePlaying;
		speed = baseSpeed;
		speedLerp = baseSpeed / 1.2f;
	}

	private void Update() {
		if (playing == true) {
			if (speed < baseSpeed) {
				speed += Time.deltaTime * speedLerp;
			}
			transform.LookAt(target.transform);
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		} else {
			if (speed >= slowSpeed) {
				speed -= Time.deltaTime * speedLerp;
			}
			transform.LookAt(target.transform);
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}

	private void TogglePlaying(bool value) {
		playing = value;
	}

	private void ResetPos() {
		Vector3.Lerp(gameObject.transform.position, defaultPos, Time.deltaTime);
		//gameObject.transform.position = defaultPos;
	}
}
