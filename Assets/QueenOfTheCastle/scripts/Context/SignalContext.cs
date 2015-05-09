﻿using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class SignalContext : MVCSContext
{
	public SignalContext (MonoBehaviour contextView) : base(contextView)
	{
	}
	
	protected override void addCoreComponents()
	{
		base.addCoreComponents ();
		
		injectionBinder.Unbind<ICommandBinder> ();
		injectionBinder.Bind<ICommandBinder> ().To<SignalCommandBinder> ();
	}
	
	public override void Launch()
	{
		base.Launch ();
	}
}
