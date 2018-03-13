using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake()
	{
		Debug.Log ("Music Player awake" + GetInstanceID ());
		if(instance != null)
		{
			Destroy (gameObject);
			print ("new one destroy");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			print ("new one created");
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Music Player Start" + GetInstanceID ());


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
