using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using AllHandsOnDeck.Common;

namespace AllHandsOnDeck.Character
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
		
		[Range (0,400)]
		public float turnSpeed;

		public Animator animator;

		public float animatorSpeed
		{
			set
			{
				animator.SetFloat("speed", value);
			}
		}
		protected override void OnStart ()
		{
			endgame.AddListener(GameOver);
		}
		
		void Update ()
		{

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
			
			translation = Camera.main.cameraToWorldMatrix.MultiplyVector (translation);
			
			translation.Set (translation.x, 0, translation.z);
			
			if(translation.magnitude > Mathf.Epsilon)
			{
				Rotate (translation);			
			}
			//transform.Translate (translation * speed * Time.deltaTime, Space.World);
			//rigidbody.MovePosition (rigidbody.position + translation * speed * Time.deltaTime);
			animatorSpeed = translation.magnitude;

			//Debug.DrawRay (head.position, aim.position - head.position, Color.red);
		}
		
		private void Rotate(Vector3 dir)
		{
			//transform.LookAt(dir);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
		}
	
		public void Action1Down ()
		{
			if(gameOver)
			{
				return;
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