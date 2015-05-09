using UnityEngine;
using System.Collections;

public class playerProfectileFireScript : MonoBehaviour {
	
	public Vector2 aimAngle = new Vector2 ();
	public GameObject projectile;
	public GameObject currentProjectile;
	float projectileSpeed = 3500f;
	public GameObject spawnPreojectilesPosition;
	public float projectileNumbers = 2;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("addProjectile", 0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Vector2 aimAngle = controllerInput;
		
	}
	
	public void fireProjectile () {

		if (projectileNumbers > 0) {
		
			projectileNumbers -= 1;

			currentProjectile = (GameObject)Instantiate (projectile, spawnPreojectilesPosition.transform.position, Quaternion.identity);
		
			Vector3 aimAngle3D = aimAngle;
		
			currentProjectile.transform.rotation = Quaternion.LookRotation (aimAngle3D, new Vector3 (1, 0, 0));
		
			projectileScript pScript = currentProjectile.GetComponent<projectileScript> ();
		
			pScript.moveAngle = aimAngle;
			pScript.speed = projectileSpeed;
		}
		
	}

	public void addProjectile ()
	{
		if (projectileNumbers < 3)
		{
			projectileNumbers += 1;
		}
	}
}
