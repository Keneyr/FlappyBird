using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

	public static GameMenu _instance;
	public GUIText currentScore;
	public GUIText highScore;
	public GUITexture start;


	//先不显示
	void Awake(){
		_instance = this;
		this.gameObject.SetActive (false);
	}
	//显示最高分数和当前分数
	public void UpdateScore(float _currentScore){
		//print (_currentScore);
		float _highScore = PlayerPrefs.GetFloat ("score",0);
		if (_currentScore > _highScore) {
			_highScore = _currentScore;
		}
		//把最高分数存储本地
		PlayerPrefs.SetFloat ("score",_highScore);

		this.currentScore.text = _currentScore+"";
		this.highScore.text = _highScore+"";

		if (Input.GetMouseButtonDown (0)&& GameManager.instance.GameState == GameManager.GAMESTATE_END) {
			//屏幕左上角为原点，一个是宽度，一个是高度，形成长方形
			Rect rect = start.GetScreenRect();
			Vector3 mousePos = Input.mousePosition;
			if(mousePos.x>rect.x&&
				mousePos.x<(rect.x+rect.width)&&
					mousePos.y>rect.y&&
					mousePos.y<(rect.y+rect.height)){
				//这两个都可以重新。但是最好是用manager
				SceneManager.LoadScene ("StartScene");
				//Application.LoadLevel(0);
				}
		}
	}

}
