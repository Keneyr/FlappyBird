using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
目前的bug，小鸟碰到pipe_up不会死掉。
*/

//挂载到了MainCamera上
public class GameManager : MonoBehaviour {
	//最后的一个bg
	public static int GAMESTATE_MENU = 0; //游戏菜单状态
	public static int GAMESTATE_PLAYING = 1; //游戏中状态
	public static int GAMESTATE_END = 2; //游戏结束状态

	public Transform firstBg;
	public int score = 0;
	public int GameState = GAMESTATE_MENU;

	private Rigidbody _bird;

	public static GameManager instance;

	void Awake(){
		instance = this;
	}
	void Start(){
		//获取bird这个刚体
		_bird = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> () as Rigidbody;
	}
	void Update(){
		if (GameState == GAMESTATE_MENU) {
			//如果按下鼠标左键，游戏开始
			if (Input.GetMouseButtonDown (0)) {
				GameState = GAMESTATE_PLAYING;
				_bird.SendMessage ("getLife");
			}
		}
		if (GameState == GAMESTATE_END) {
			//游戏结束
			GameMenu._instance.gameObject.SetActive(true);
			GameMenu._instance.UpdateScore (score);
		}
	}

}
