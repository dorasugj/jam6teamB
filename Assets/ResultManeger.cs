using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ResultManeger : MonoBehaviour {
	public static int totalFrame;
	private int frame;
	
	// Use this for initialization
	void Start () {
		ScoreManager.totalFrame = totalFrame;
		frame = totalFrame;
		totalFrame =0 ;
		Debug.Log("結果フレーム数"+frame);
		if (frame <= 30)
		{
			Debug.Log("Perfect");
			GameObject obj = Resources.Load("Prefabs/ResultPerfect") as GameObject;
			Instantiate(obj, new Vector3(0, -1.6f, 0), transform.rotation);
			obj = Resources.Load("Prefabs/TextPerfect") as GameObject;
			Instantiate(obj, new Vector3(0, 2.4f, 0), transform.rotation);
		}
		else if (frame <= 60)
		{
			Debug.Log("Great");
			GameObject obj = Resources.Load("Prefabs/ResultGreat") as GameObject;
			Instantiate(obj, new Vector3(0, -1.6f, 0), transform.rotation);
			obj = Resources.Load("Prefabs/TextGreat") as GameObject;
			Instantiate(obj, new Vector3(0, 2.4f, 0), transform.rotation);
		}
		else if (frame <= 90)
		{
			Debug.Log("Nice");
			GameObject obj = Resources.Load("Prefabs/ResultNice") as GameObject;
			Instantiate(obj, new Vector3(0, -1.6f, 0), transform.rotation);
			obj = Resources.Load("Prefabs/TextNice") as GameObject;
			Instantiate(obj, new Vector3(0, 2.4f, 0), transform.rotation);
		}
		else
		{
			Debug.Log("Miss");
			GameObject obj = Resources.Load("Prefabs/ResultMiss") as GameObject;
			Instantiate(obj, new Vector3(0, -1.6f, 0), transform.rotation);
			obj = Resources.Load("Prefabs/TextMiss") as GameObject;
			Instantiate(obj, new Vector3(0, 2.4f, 0), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsTouch())
		{
			SceneManager.LoadScene("Start");
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
			Debug.Log("タッチされた（スマホ）" );
			return true;
		}
		return false;
	}

}
