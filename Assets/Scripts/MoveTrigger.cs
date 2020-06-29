using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {
	public Transform currentBg;
	public pipe pipe1;
	public pipe pipe2;

	void start(){
		
	}
	//移动场景，让场景无线循环下去
    public void OnTriggerEnter(Collider other){
		
		//print ("OntriggerEnter");
		if (other.tag == "Player") {
			//移动Bg到first transform的前面
			//1.得到第一个transform
			Transform firstBg = GameManager.instance.firstBg;
			//print(firstBg.name);
			//print(currentBg.name);
			//2.移动
			currentBg.position = new Vector3(firstBg.position.x+10,currentBg.position.y,currentBg.position.z);
			//3.更新
			GameManager.instance.firstBg = currentBg;

			pipe1.RandomGeneratePosition ();
			pipe2.RandomGeneratePosition ();
		}
	}
}
