using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBGM : MonoBehaviour {
	public BGMData bgm;
	public float delay = 2f;
	public AudioSource audioSource;

	private BGMPlayer m_bgmPlayer;

	IEnumerator Start() {
		m_bgmPlayer = new BGMPlayer();
		m_bgmPlayer.audioSource = audioSource;

		yield return new WaitForSeconds(delay);

		m_bgmPlayer.ChangeTrack(bgm);
	}
}
