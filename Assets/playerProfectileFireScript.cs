using UnityEngine;
using System.Collections;

public class playerProfectileFireScript : MonoBehaviour {

	public Vector2 aimAngle = new Vector2 ();
	public GameObject projectile;
	public GameObject currentProjectile;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		//Vector2 aimAngle = controllerInput;

	}

	public void fireProjectile () {

		currentProjectile = (GameObject)Instantiate (projectile, new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
	
		Vector3 aimAngle3D = aimAngle;
	
		currentProjectile.transform.rotation = Quaternion.Euler (aimAngle);
	
		projectileScript pScript = currentProjectile.GetComponent<projectileScript> ();
	
		pScript.moveAngle = aimAngle;

	}
}
