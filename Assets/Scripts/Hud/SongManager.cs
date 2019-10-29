using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public AudioPeer _audioPeer;

	public void PreviousSong() {
		AudioPeer.songIndex--;
	}

	public void NextSong() {
		AudioPeer.songIndex++;
	}

}
