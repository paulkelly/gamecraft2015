using UnityEngine;
using System.Collections;

namespace QueenOfTheCastle.Character
{
	public interface ICharacter
	{
		bool Grounded
		{
			get;
		}

		void Kill();

		void Move(Vector2 value);
		void Aim(Vector2 value);
		
		void Action1Down();
		void Action1Up();
		
		void Action2Down();
		void Action2Up();

		void Action3Down();
		void Action3Up();

		void Action4Down();
		void Action4Up();
	}
}