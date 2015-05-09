using UnityEngine;
using System.Collections;

public class playerProfectileFireScript : MonoBehaviour {

	public Vector2 aimAngle = new Vector2 ();
	public bool fireTrue;
	public GameObject projectile;
	public Object currentProjectile;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		//Vector2 aimAngle = controllerInput;

		//bool fireTrue = controllerInput;

		if (fireTrue == true)
		{

			currentProjectile = Instantiate(projectile, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);

			fireTrue = false;

		}
	}
}
