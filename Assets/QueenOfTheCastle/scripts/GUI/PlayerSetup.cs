using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System.Collections.Generic;
using InControl;
using QueenOfTheCastle.Common;

public class PlayerSetup : View
{
	[Inject]
	public StartGame startGame { get; set; }

	public CharacterSpawner spawner;
		
	Dictionary<InputDevice, int> players = new Dictionary<InputDevice, int>();
	private int next = 0;


	private void Update ()
	{
		foreach(InputDevice device in InControl.InputManager.Devices)
		{
			if(device.AnyButton.IsPressed || device.MenuWasPressed)
			{
				if(players.Count == 0)
				{
					startGame.Dispatch();
				}
				MenuPressed(device);
			}
		}
	}

	private void MenuPressed(InputDevice activeDevice)
	{
		if(!players.ContainsKey(activeDevice))
		{
			AddPlayer(activeDevice);
		}
	}
	
	private void AddPlayer(InputDevice activeDevice)
	{
		players.Add(activeDevice, next);
		spawner.SpawnPlayer(next, InControl.InputManager.ActiveDevice);
		next++;
	}
	
	private void Reset()
	{
		next = 0;
		players.Clear();
	}
}
