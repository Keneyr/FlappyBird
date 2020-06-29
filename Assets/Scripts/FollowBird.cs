using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBird : MonoBehaviour {

	//实现相机和bird的坐标差不变就行了
	private GameObject _bird;
	private Transform birdTransform;
	private Transform Camera;

	// Use this for initialization
	void Start () {
		
		_bird = GameObject.FindGameObjectWithTag("Player");
		birdTransform = _bird.transform;
		Camera = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 birdPos = birdTransform.position;
		/*控制相机的上下界限，不要超过边界。但是我感觉效果并不好，所以就固定了相机的y，只让相机的x随着bird而移动。
		float y = birdPos.y-3.5088f;
		if (y > 2.6f) {
			y = 2.6f;
		}
		if (y < -2.0f) {
			y = -2.0f;
		}
		*/
		Camera.position = new Vector3 (Camera.position.x,1,Camera.position.z);

	}
}
