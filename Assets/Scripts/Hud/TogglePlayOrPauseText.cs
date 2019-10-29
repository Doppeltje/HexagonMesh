using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePlayOrPauseText : MonoBehaviour {
	public Text buttonText;
	public AudioPeer _audioPeer;

	private void Start() {
		_audioPeer.playOrPause += ChangeButtonText;
	}

	public void ChangeButtonText(bool text) {
		if (text) {
			buttonText.text = "Pause".ToUpper();
		} else {
			buttonText.text = "Play".ToUpper();
		}
	}
}
