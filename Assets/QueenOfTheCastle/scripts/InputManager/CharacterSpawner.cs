using UnityEngine;
using System.Collections;
using QueenOfTheCastle.Character;
using InControl;
using strange.extensions.mediation.impl;
using QueenOfTheCastle.Common;

public class CharacterSpawner : View
{		
	public virtual float MaxPlayers
	{
		get {return 0;}
	}
	
	public virtual ICharacter GetPlayer(int index)
	{
		return null;
	}
	
	public virtual void SpawnPlayer(int index, InputDevice device)
	{
	}
	
	public virtual void Reset()
	{
	}
}
