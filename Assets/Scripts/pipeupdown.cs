using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeupdown : MonoBehaviour {
	public AudioSource hitMusic;
	public AudioSource dieMusic;

	private AudioSource _audio;
	void Start(){
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			//print ("碰到柱子");
			hitMusic.Play();
			dieMusic.Play ();
			GameManager.instance.GameState = GameManager.GAMESTATE_END;
		}
	}
}
