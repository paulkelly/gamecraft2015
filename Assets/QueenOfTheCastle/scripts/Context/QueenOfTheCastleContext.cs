using UnityEngine;
using System.Collections;
using QueenOfTheCastle.Common;

namespace AllHandsOnDeck.Context
{
	public class QueenOfTheCastleContext : SignalContext 
	{
		public QueenOfTheCastleContext(MonoBehaviour contextView) : base(contextView)
		{
		}
		
		protected override void mapBindings()
		{
			base.mapBindings ();
			
			injectionBinder.Bind<StartGame>().ToSingleton();
			injectionBinder.Bind<EndGame>().ToSingleton();
			injectionBinder.Bind<RollCredits>().ToSingleton();
		}
	}
}