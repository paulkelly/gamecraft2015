using UnityEngine;
using System.Collections;
using QueenOfTheCastle.Character;

public class projectileScript : MonoBehaviour {

	public Vector3 moveAngle = new Vector3();
	public float speed = 3500f;

	public bool isActive = true;
	public ICharacter character;

	// Use this for initialization
	void Start ()
	{

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(moveAngle*speed);

		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = GetComponent<Rigidbody>();

		bool visible = GetComponent<Renderer>().isVisible;
			if (visible == false)
		{
			//Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collider)
	{
		if(!isActive)
		{
			return;
		}
		ICharacter chr = collider.transform.GetComponentInParent<ICharacter> ();
		if(chr != null)
		{
			if(chr == character)
			{
				return;
			}

			chr.Kill();
		}

		isActive = false;

		if(!collider.transform.tag.Equals("Arrow"))
		{
			Destroy(gameObject);
			//GetComponent<Rigidbody>().isKinematic = true;
			//GetComponent<Rigidbody>().velocity = Vector3.zero;
			//transform.parent = collider.transform;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if(!isActive)
		{
			return;
		}
		ICharacter chr = collider.transform.GetComponentInParent<ICharacter> ();
		if(chr != null)
		{
			if(chr == character)
			{
				return;
			}
			
			chr.Kill();
		}
		
		isActive = false;
		
		if(!collider.transform.tag.Equals("Arrow"))
		{
			Destroy(gameObject);
			//GetComponent<Rigidbody>().isKinematic = true;
			//GetComponent<Rigidbody>().velocity = Vector3.zero;
			//transform.parent = collider.transform;
		}
	}
}
