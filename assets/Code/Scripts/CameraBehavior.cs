using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	private GameObject ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("Ball");
		Camera.main.transform.eulerAngles = new Vector3(30, 0, 0);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 ballposition = ball.transform.position;
		Camera.main.transform.position = new Vector3(ballposition.x, ballposition.y + 5f, ballposition.z - 10F);
	}
}
