using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartManeger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update()
	{
		if (IsTouch())
		{
			SceneManager.LoadScene("HanabiMan");
		}
	}
	public bool IsTouch()
	{
		if (Application.isEditor)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("タッチされた（エディター）");
				return true;
			}
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Debug.Log("タッチされた（スマホ）");
			return true;
		}
		return false;
	}

}
