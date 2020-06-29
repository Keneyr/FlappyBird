using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDie : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			GameManager.instance.GameState = GameManager.GAMESTATE_END;
		}
	}
}
