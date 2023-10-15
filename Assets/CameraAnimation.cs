using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraAnimation : MonoBehaviour
{
	public GameObject camera2;
	public GameObject camera3;
	public GameObject camera4main;
	public GameObject ceilingObject;
	[Space(20)]

	public float tile2;
	public float tile3;
	public float tile4;


	protected void Start()
	{
		camera2.SetActive(false);
		camera3.SetActive(false);
		camera4main.SetActive(false);
		ceilingObject.SetActive(true);

	}

	private void Update()
	{
		if (Time.time >= tile2)
		{
			camera2.SetActive(true);
		}

		if (Time.time >= tile3)
		{
			camera3.SetActive(true);
		}

		if (Time.time >= tile4)
		{
			camera4main.SetActive(true);
			ceilingObject.SetActive(false);
			StartCoroutine(SwitchOffAfterDelay());
	
		}
		
	IEnumerator SwitchOffAfterDelay()
	{
		yield return new WaitForSeconds(0.1f);
		gameObject.SetActive(false);
	}

	}
}
