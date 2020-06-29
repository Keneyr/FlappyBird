using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
目前为止有个bug，小鸟每次都卡在边界上，也就是bg1和bg2以及bg3的边界上。
已经解决，把所有bg的mesh collider删除掉，还有back的mesh collider删除掉。
解决方法：在bird内写代码，输出小鸟碰到的物体的名称，发现时back作祟。
*/
public class bird : MonoBehaviour {

	//这个动画一共三帧
	public int frameNumber = 10;//一秒显示10帧
	public int frameCount = 0;//帧计时器
	public float timer = 0;//计数器

	private Renderer _rend;
	private Rigidbody _rigid;
	public AudioSource sfx_wing;
	// Use this for initialization
	void Start () {
		
		_rend = GetComponent<Renderer> ();
		_rigid = GetComponent<Rigidbody> ();
		sfx_wing = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//进行小鸟煽动翅膀的渲染
		if (GameManager.instance.GameState == GameManager.GAMESTATE_PLAYING) {
			timer += Time.deltaTime;
			//如果timer超过了一帧的时间
			if (timer >= 1.0f / frameNumber) {
				frameCount++;
				timer -= 1.0f / frameNumber;
				int frameIndex = frameCount % 3;
				//更新材料上的属性offset x，怎么设置x offset 属性
				float offset = 0.33333f * frameIndex;
				//
				_rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
			}
		}

		//控制小鸟的跳跃
		if (GameManager.instance.GameState == GameManager.GAMESTATE_PLAYING) {
			if (Input.GetMouseButton (0)) {//按下左鼠标键
				sfx_wing.Play();	
				Vector3 vel2 = _rigid.velocity;
				_rigid.velocity = new Vector3 (vel2.x,5,vel2.z);
			}
		}

	}
	public void getLife(){
		//print ("游戏开始");
		_rigid.useGravity = true;
		Vector3 vel = _rigid.velocity;
		//给出向右的速度，同时受到重力的作用
		_rigid.velocity = new Vector3 (3,vel.y,vel.z);

	}
	void OnCollisionEnter(Collision other){
		//print ("小鸟碰到了"+other.gameObject.name);
	}
}
