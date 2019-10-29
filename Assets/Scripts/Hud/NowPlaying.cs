using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowPlaying : MonoBehaviour {
	public Text songText;
	public AudioPeer _audioPeer;

	private void Start() {
		_audioPeer.updateSong += ChangeSongText;
		ChangeSongText("Welcome to Hexagon Audio Visualization, enjoy!");
	}

	public void ChangeSongText(string text) {
		songText.text = text.ToUpper();
	}
}
