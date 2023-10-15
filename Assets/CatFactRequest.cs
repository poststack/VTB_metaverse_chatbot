using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CatFactRequest : MonoBehaviour
{
	private const string Url = "https://catfact.ninja/fact";
	private const string AcceptHeader = "application/json";
	private const string CsrfTokenHeader = "VP2CPsLUhUCaPNMhxLmLmySrIcA6QBbNwICRtSYT";
	
	
	
	public Text​Mesh​Pro​UGUI textObject;
	public string initialText;
	
	protected void Start()
	{
		initialText = textObject.text;
	}

	public void GetRandomFact()
	{
		StartCoroutine(GetCatFact());
	}

	private IEnumerator GetCatFact()
	{
		UnityWebRequest request = UnityWebRequest.Get(Url);
		request.SetRequestHeader("accept", AcceptHeader);
		request.SetRequestHeader("X-CSRF-TOKEN", CsrfTokenHeader);

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			string responseJson = request.downloadHandler.text;
			// Parse the JSON response
			CatFact catFact = JsonUtility.FromJson<CatFact>(responseJson);

			Debug.Log($"Cat Fact: {catFact.fact}");
			
			textObject.text = initialText + catFact.fact;
		}
		else
		{
			Debug.LogError($"Request failed. Error: {request.error}");
		}
	}
}

[System.Serializable]
public class CatFact
{
	public string fact;
	public int length;
}
