using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private paddle padd;

	private Vector3 paddtoball;
	private bool started=false;

	// Use this for initialization
	void Start () {
		padd = GameObject.FindObjectOfType<paddle> ();
		paddtoball = this.transform.position - padd.transform.position;	
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(started)
			GetComponent<AudioSource>().Play ();
		Vector2 tweek = new Vector2 (Random.Range (-0.7f, 0.7f), Random.Range (0.0f, 0.2f));
		this.GetComponent<Rigidbody2D>().velocity += tweek;
		}

	public void OnTriggerEnter2D(Collider2D tri){
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			this.transform.position = padd.transform.position + paddtoball;
		
			if (Input.GetMouseButtonDown (0)) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2.0f, 10.0f);
				started = true;
			}
		}
	}
}
