using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour {
	GameObject _light;
	float rotation = 0f;
	float rotationSpeed = 50f;

	private void Start() {
		_light = gameObject;
		rotation = _light.transform.rotation.y;
	}

	private void Update() {
		rotation += Time.deltaTime * rotationSpeed;
		_light.transform.eulerAngles = new Vector3(
			_light.transform.eulerAngles.x,
			rotation,
			_light.transform.eulerAngles.z);
	}
}
