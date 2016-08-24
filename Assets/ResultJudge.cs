using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ResultJudge : MonoBehaviour {
	private float timer;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(Hanabiman.targetLuanserNum==3)
		{
			if (timer >= 2.0f)
			{
				Hanabiman.targetLuanserNum++;
			}
		}
		if(Hanabiman.targetLuanserNum>=4)
		{
			Debug.Log("リザルトへ移行");
			SceneManager.LoadScene("Result");
		}
	}
}
