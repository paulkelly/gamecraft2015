using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
	public int Progress { get; set; }

	void Update()
	{
		transform.localPosition = new Vector3(0, 2 + (Progress * 0.02f), 0);
	}
}
