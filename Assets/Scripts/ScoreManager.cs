using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int totalFrame = 0;
	public int frame;
	public Text score;

	// Use this for initialization
	void Start () {
		frame = totalFrame;
		totalFrame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = frame + "フレーム差";
	}
}
