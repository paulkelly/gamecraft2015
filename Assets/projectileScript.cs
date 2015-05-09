using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {

	public Vector3 moveAngle = new Vector3();
	public float speed = 3500f;

	// Use this for initialization
	void Start () {

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(moveAngle*speed);

	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent<Rigidbody>();

		transform.rotation = Quaternion.LookRotation(rb.velocity ,new Vector3(0,0,1));

		bool visible = GetComponent<Renderer>().isVisible;
			if (visible == false)
		{
			//Destroy(this.gameObject);
		}
	}
}
