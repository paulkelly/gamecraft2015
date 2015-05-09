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
		public bool Grounded = false;
		public bool LeftGround = false;
		void Update ()
		{
			Grounded = Physics.Raycast (ground.position, Vector3.down, 0.1f);
			Debug.DrawLine (ground.position, ground.position + new Vector3(0, -0.1f, 0));
			if(!LeftGround)
			{
				LeftGround = !Grounded;
			}

			if(Jumping && LeftGround && Grounded)
			{
				Jumping = false;
				LeftGround = false;
			}
		}
		
		#region ICharacter implementation
			
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
			animatorSpeed = translation.magnitude;

			//Debug.DrawRay (head.position, aim.position - head.position, Color.red);
		}

		public void Aim(Vector2 value)
		{
			projectileFire.aimAngle = value;
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

			if(!Jumping)
			{
				Jumping = true;

				GetComponent<Rigidbody>().AddForce(Vector3.up * 3200f);
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
			
			projectileFire.fireProjectile ();
		}

		public void Action3Up ()
		{
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