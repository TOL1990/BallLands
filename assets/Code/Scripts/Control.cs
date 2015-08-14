using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{

	private static float force;
	private static float jumpForce;
	private Rigidbody rigidbody;
	//
	private const float STOP_COEFFICIENT = 0.95f;
	private const float STOP_LIMIT = 0.05f;

	// Use this for initialization
	void Start () {
		init();
	}

	private void init()
	{
		rigidbody = gameObject.GetComponent<Rigidbody>();
		//
		force = 10;
        jumpForce = 5;
	}
	
	// Update is called once per frame
	void Update () {
		BallStopping();
		if (Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody.AddForce(new Vector3(0, 0, force), ForceMode.Force);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody.AddForce(new Vector3(-force, 0, 0), ForceMode.Force);
        }
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody.AddForce(new Vector3(force, 0, 0), ForceMode.Force);
        }
		if (Input.GetKey(KeyCode.DownArrow))
		{
			rigidbody.AddForce(new Vector3(0, 0, -force), ForceMode.Force);
        }
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

	}
	private void BallStopping ()
	{
		if (rigidbody.velocity.magnitude < STOP_LIMIT)
		{
			rigidbody.velocity = new Vector3(0, 0, 0);
		}
		else
		{
			rigidbody.velocity -= rigidbody.velocity.normalized * (STOP_COEFFICIENT * Time.deltaTime);
		}
		//
		if (rigidbody.angularVelocity.magnitude < STOP_LIMIT)
		{
			rigidbody.angularVelocity = new Vector3(0, 0, 0);
		}
		else
		{
			rigidbody.angularVelocity -= rigidbody.angularVelocity.normalized * (STOP_COEFFICIENT * Time.deltaTime);
		}
	}
}
