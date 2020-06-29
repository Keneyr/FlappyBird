using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
出现了一个bug，得分的声音播放不了
*/

public class pipe : MonoBehaviour {
	public AudioSource pointMusic;
	void start(){
		RandomGeneratePosition ();
	}

	public void RandomGeneratePosition(){
		//怎样随机生成一个数字,localposition是本地坐标，position是世界坐标
		float pos_y = Random.Range(-5.0f,-2.0f);
		//print (this.transform.name+"of"+this.transform.parent.name);
		this.transform.position = new Vector3 (this.transform.position.x, pos_y, this.transform.position.z);
		//this.transform.localPosition = new Vector3 (this.transform.localPosition.x,pos_y,this.transform.localPosition.z);
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player") {
			pointMusic.Play ();
			GameManager.instance.score++;
		}
	}

	void OnGUI(){
		GUILayout.Label ("Score:"+GameManager.instance.score);
	}
}
