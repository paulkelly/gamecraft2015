using UnityEngine;
using System.Collections;
using QueenOfTheCastle.Character;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using QueenOfTheCastle.Common;

public class SwordInTheStone : View
{
	public Sword sword;
	public Transform hitBHint;

	private List<ICharacter> _charactersInRange = new List<ICharacter>();
	private int progress = 0;
	private int maxProgress = 100;

	void Update()
	{
		hitBHint.gameObject.SetActive(_charactersInRange.Count > 0);
	}
	
	public void BPress(ICharacter character)
	{
		if(_charactersInRange.Contains(character))
		{
			progress++;
			if(progress > maxProgress)
			{
				Winner(character);
			}
			else
			{
				sword.Progress = progress;
			}
		}
	}

	private void Winner(ICharacter character)
	{
		Debug.Log (character + " wins.");
	}

	public void PlayerEnter(ICharacter character)
	{
		if(!_charactersInRange.Contains(character))
		{
			_charactersInRange.Add(character);
		}
	}

	public void PlayerLeave(ICharacter character)
	{
		if(_charactersInRange.Contains(character))
		{
			_charactersInRange.Remove(character);
		}
	}
}
