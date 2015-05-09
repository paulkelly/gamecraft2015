using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {

	public Vector3 moveAngle = new Vector3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = transform.position + moveAngle;

		bool visible = GetComponent<Renderer>().isVisible;
			if (visible == false)
		{
			//Destroy(this.gameObject);
		}
	}
}
