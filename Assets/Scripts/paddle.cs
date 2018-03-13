using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {

	float mpos;

	public bool autoplay = false;

	private Ball ball;


	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoplay){
			MoveWithMouse ();
		}
		else{
			AutoPlay ();
		}

	}

	void AutoPlay(){
		Vector3 ballpos = new Vector3 (0.5f, this.transform.position.y, 0f);

		ballpos.x = Mathf.Clamp(ball.transform.position.x,1.5f,14.5f);

		this.transform.position = ballpos;
	}

	void MoveWithMouse(){
		mpos = (Input.mousePosition.x / Screen.width) * 16;

		Vector3 paddlepos = new Vector3(15.0f, this.transform.position.y , 0f);

		paddlepos.x = Mathf.Clamp(mpos,1.5f,14.5f);

		this.transform.position = paddlepos;
	}
}