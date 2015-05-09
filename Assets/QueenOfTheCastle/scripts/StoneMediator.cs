using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using QueenOfTheCastle.Common;
using QueenOfTheCastle.Character;

public class StoneMediator : Mediator
{
	[Inject]
	public SwordInTheStone view { get; set; }

	[Inject]
	public SpamB spamBSignal { get; set; }

	public override void OnRegister()
	{
		spamBSignal.AddListener (HitB);
	}

	private void HitB(ICharacter chr)
	{
		view.BPress (chr);
	}
}
