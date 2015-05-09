using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using QueenOfTheCastle.Common;

namespace QueenOfTheCastle.Character
{
	[RequireComponent (typeof(Rigidbody))]
	public class ThreeDMovement : View, ICharacter
	{
		[Inject]
		public EndGame endgame { get; set; }

		[Inject]
		public SpamB spamBSignal { get; set;}

		public Transform[] SpawnPoints;

		private bool XHeldDown = false;
		
		private bool gameOver = false;
		private void GameOver()
		{
			gameOver = true;
		}
	
		[Range (0,20)]
		public float speed;

		public playerProfectileFireScript projectileFire;

		public Animator animator;

		public float animatorSpeed
		{
			set
			{
				animator.SetFloat("Speed", value);
			}
		}
		public bool Jump
		{
			set
			{
				animator.SetBool("Jump", value);
			}

			get
			{
				return animator.GetBool("Jump");
			}
		}
		public void HitHead()
		{
			animator.SetTrigger("HitHead");
		}

		protected override void OnStart ()
		{
			endgame.AddListener(GameOver);
		}

		public Transform ground;
		public bool Jumping = false;
		public bool Grounded { get; set; }
		public bool LeftGround = false;
		void Update ()
		{
			var layerMask = 1 << 10;
			Grounded = Physics.Raycast (ground.position, Vector3.down, 0.1f, layerMask);
			//Debug.DrawLine (ground.position, ground.position + new Vector3(0, -0.1f, 0));
			if(!LeftGround)
			{
				LeftGround = !Physics.Raycast (ground.position, Vector3.down, 0.2f, layerMask);
			}

			if(Jump && LeftGround && Grounded)
			{
				Jump = false;
				LeftGround = false;
			}
		}
		
		#region ICharacter implementation

		public void Kill()
		{
			Invoke ("Respawn", 3f);
			gameObject.SetActive (false);
		}

		private void Respawn()
		{
			gameObject.SetActive (true);
			transform.position = SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Length)].position;
		}
			
		public void Move (Vector2 value)
		{
			if(gameOver)
			{
				animatorSpeed = 0;
				return;
			}
		
			Vector3 translation = new Vector3 (value.x, 0, 0);
			
			//translation = Camera.main.cameraToWorldMatrix.MultiplyVector (translation);
			
			//translation.Set (translation.x, 0, translation.z);
			
			if(translation.magnitude > Mathf.Epsilon)
			{
				transform.rotation = Quaternion.LookRotation(translation);
			}
			//transform.Translate (translation * speed * Time.deltaTime, Space.World);
			//rigidbody.MovePosition (rigidbody.position + translation * speed * Time.deltaTime);
			if(!XHeldDown || Jump)
			{
				animatorSpeed = translation.magnitude;
			}
			else
			{
				animatorSpeed = 0;
			}
			projectileFire.aimAngle = value;
			//Debug.DrawRay (head.position, aim.position - head.position, Color.red);
		}

		public void Aim(Vector2 value)
		{
		}

		//private void Rotate(Vector3 dir)
		//{
			//transform.LookAt(dir);
		//	transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
		//}
	
		public void Action1Down ()
		{
			if(gameOver)
			{
				return;
			}

			if(!Jump)
			{
				Jump = true;

				//GetComponent<Rigidbody>().AddForce(Vector3.up * 3200f);
			}
		}

		public void Action1Up ()
		{
			if(gameOver)
			{
				return;
			}
		}

		public void Action2Down ()
		{
			if(gameOver)
			{
				return;
			}

			spamBSignal.Dispatch (this);
		}

		public void Action2Up ()
		{

		}
	
		public void Action3Down ()
		{
			if(gameOver)
			{
				return;
			}
			XHeldDown = true;
		}

		public void Action3Up ()
		{
			XHeldDown = false;
			projectileFire.fireProjectile ();
		}
	
		public void Action4Down ()
		{
		}

		public void Action4Up ()
		{
		}
	
		#endregion
	}
}