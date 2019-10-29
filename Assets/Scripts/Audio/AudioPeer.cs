using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {
	AudioSource audioSource;
	public Action<string> updateSong;
	public Action<bool> playOrPause;
	public AudioClip[] songs;
	private AudioClip currentSong;
	public static int songIndex = 0;
	public static float[] samples = new float[512];
	private bool isPlaying = false;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = currentSong = songs[songIndex];
		if (playOrPause != null) {
			playOrPause(isPlaying);
		}
	}

	private void Update() {
		GetSpectrumAudioSource();
	}

	void GetSpectrumAudioSource() {
		audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
	}

	public void TogglePlaying() {
		if (isPlaying) {
			isPlaying = false;
			audioSource.Pause();
			if (updateSong != null) {
				updateSong("Paused: " + currentSong.name);
			}

			if (playOrPause != null) {
				playOrPause(isPlaying);
			}
		} else {
			isPlaying = true;
			audioSource.Play();
			if (updateSong != null) {
				updateSong("Now playing: " + currentSong.name);
			}

			if (playOrPause != null) {
				playOrPause(isPlaying);
			}
		}
	}

	public void PreviousSong() {
		if (songIndex <= 0) {
			songIndex = songs.Length - 1;
		} else {
			songIndex--;
		}
		audioSource.clip = currentSong = songs[songIndex];
		audioSource.Play();
		if (updateSong != null) {
			updateSong("Now playing: " + currentSong.name);
		}
	}

	public void NextSong() {
		if (songIndex >= songs.Length - 1) {
			songIndex = 0;
		} else {
			songIndex++;
		}
		audioSource.clip = currentSong = songs[songIndex];
		audioSource.Play();
		if (updateSong != null) {
			updateSong("Now playing: " + currentSong.name);
		}
	}
}
