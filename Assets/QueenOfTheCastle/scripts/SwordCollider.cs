using UnityEngine;
using System.Collections;
using QueenOfTheCastle.Character;
using QueenOfTheCastle.Common;

public class SwordCollider : MonoBehaviour
{
	public SwordInTheStone swordInTheStone;

	void OnTriggerEnter(Collider collider)
	{
		ICharacter chr = collider.GetComponentInParent<ICharacter> ();
		if(chr != null)
		{
			swordInTheStone.PlayerEnter(chr);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		ICharacter chr = collider.GetComponentInParent<ICharacter> ();
		if(chr != null)
		{
			swordInTheStone.PlayerLeave(chr);
		}
	}
}
