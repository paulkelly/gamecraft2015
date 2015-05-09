using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;
using QueenOfTheCastle.Character;

namespace QueenOfTheCastle.Common
{
	public class StartGame : Signal
	{
	}
	
	public class EndGame : Signal
	{
	}
	
	public class RollCredits : Signal<float>
	{
	}

	public class SpamB : Signal<ICharacter>
	{
	}
}