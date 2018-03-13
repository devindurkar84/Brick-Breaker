using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip Crack;

	public static int breakableCount =0;

	private int maxhit;

	private int timeshit;

	private LevelManager levelmanager;

	public Sprite[] spritesindex;

	public GameObject smoke;

	// Use this for initialization
	void Start () {
		if(this.tag=="Breakable"){
			breakableCount++;
			print (breakableCount);
		}
		timeshit = 0;
		maxhit = spritesindex.Length + 1;
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D(Collision2D col)
	{
		AudioSource.PlayClipAtPoint (Crack, transform.position);
		if (this.tag == "Breakable") {

			timeshit++;
			print ("hit=" + timeshit);

			if (maxhit <= timeshit) {
				Destroy (gameObject);
				breakableCount--;
				print (breakableCount);
				SmokeEmission ();
				levelmanager.BreakBrick ();
			} else {
				LoadSprites ();
			}
		}
	}

	void SmokeEmission(){
		smoke.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer> ().color;
		Instantiate (smoke, new Vector3 (this.transform.position.x,this.transform.position.y,0f), Quaternion.identity);
	}

	void LoadSprites()
	{
		int index = timeshit - 1;
		this.GetComponent<SpriteRenderer> ().sprite = spritesindex [index];
	}

	public void stimulateWin(){
		levelmanager.LoadNextLevel();
	}
}
