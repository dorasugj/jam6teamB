using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hanabiman : MonoBehaviour {
	private float startDeltaTime = 0;
	private float baseTime = 0;
	private float shotTime=0;
	public int launcherNum;
	private int []launcherTimingList= {1000,2000,3000};
	private int launcherTiming;
	private int launcherFase;
	private int ignitionTiming;
	public static int targetLuanserNum=0;
	private enum eIgnitionJudge
	{
		Miss, Nice, Great, Perfect
	}

	private bool touchDown;
	private AudioSource audioSource;
	public AudioClip audioClipLanch;
	public AudioClip audioClipWork;

	// Use this for initialization
	void Start () {
		launcherTiming = launcherTimingList[launcherNum];
		launcherFase = 0;
		ignitionTiming = 3000;
		Application.targetFrameRate = 60;
		targetLuanserNum = 0;
		touchDown = false;
		audioSource = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		baseTime += 1000*Time.deltaTime;
		if (baseTime > launcherTiming&&launcherFase==0)
		{
			Debug.Log("花火発射launcerNum "+launcherNum);
			launcherFase = 1;
			baseTime = 0;
			audioSource.clip = audioClipLanch;
			audioSource.Play();
			audioSource.clip = audioClipWork;
			audioSource.Play();
			if (launcherNum == 0)
			{
				GameObject obj = Resources.Load("Prefabs/LanchKemuri") as GameObject;
				Instantiate(obj, new Vector3(-0.79f, -3.55f, 0), transform.rotation);
			}
			if (launcherNum == 1)
			{
				GameObject obj = Resources.Load("Prefabs/LanchKemuri") as GameObject;
				Instantiate(obj, new Vector3(0.5f, -3.55f, 0), transform.rotation);
			}
			if (launcherNum == 2)
			{
				GameObject obj = Resources.Load("Prefabs/LanchKemuri") as GameObject;
				Instantiate(obj, new Vector3(1.85f, -3.55f, 0), transform.rotation);
			}
		}
		if (launcherFase==1&&baseTime>ignitionTiming)
		{
			Debug.Log("印を表示"+launcherNum+" time:"+ ignitionTiming);
			launcherFase = 2;
			if (launcherNum == 0)
			{
				GameObject obj = Resources.Load("Prefabs/HanabiMark") as GameObject;
				Instantiate(obj, new Vector3(-1.3f, 2.4f, 0), transform.rotation);
			}
			if (launcherNum == 1)
			{
				GameObject obj = Resources.Load("Prefabs/HanabiMark") as GameObject;
				Instantiate(obj, new Vector3(0, 2.4f, 0), transform.rotation);
			}
			if (launcherNum == 2)
			{
				GameObject obj = Resources.Load("Prefabs/HanabiMark") as GameObject;
				Instantiate(obj, new Vector3(1.3f, 2.4f, 0), transform.rotation);
			}
		}
		if (launcherFase>=1&&targetLuanserNum==launcherNum)
		{
			Debug.Log("タッチ判定"+launcherNum);
			if(touchDown==true)
			{
				targetLuanserNum++;
			}
			if(IsTouch())
			{
				touchDown=true;

				int oldframe = ResultManeger.totalFrame;
				ResultManeger.totalFrame+=(int)Mathf.Abs((ignitionTiming-baseTime) / 20.0f);
				Debug.Log("花火の種類を決定 [" + oldframe + "]["+ResultManeger.totalFrame+"]" + launcherNum);

				switch (GetIgnitionJudge(ignitionTiming-baseTime))
				{

					case eIgnitionJudge.Miss:
						Debug.Log("Miss");
						
						break;
					case eIgnitionJudge.Nice:
						Debug.Log("Nice");
						break;
					case eIgnitionJudge.Great:
						Debug.Log("Great");
						break;
					case eIgnitionJudge.Perfect:
						Debug.Log("Perfect");
						break;

				}
				if (launcherNum == 0)
				{
					GameObject obj = Resources.Load("Prefabs/HanabiBig") as GameObject;
					Instantiate(obj, new Vector3(-1.3f, 0, 0), transform.rotation);
				}
				if (launcherNum == 1)
				{
					GameObject obj = Resources.Load("Prefabs/HanabiBig") as GameObject;
					Instantiate(obj, new Vector3(0, 0, 0), transform.rotation);
				}
				if (launcherNum == 2)
				{
					GameObject obj = Resources.Load("Prefabs/HanabiBig") as GameObject;
					Instantiate(obj, new Vector3(1.3f, 0, 0), transform.rotation);
				}
			}
		}

	}
	public bool IsTouch()
	{
//#if UNITY_WEBGL || UNITY_EDITOR
//		if (Input.GetMouseButtonDown(0))
//		{
//			Debug.Log("タッチされた（エディター）" + launcherNum);
//			return true;
//		}
//#elif UNITY_ANDROID || UNITY_IPHONE
//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//		{
//			Debug.Log("タッチされた（スマホ）" + launcherNum);
//			return true;
//		}
//#endif
		if (Application.isEditor)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("タッチされた（エディター）" + launcherNum);
				return true;
			}
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Debug.Log("タッチされた（スマホ）" + launcherNum);
			return true;
		}
		return false;
	}

	private eIgnitionJudge GetIgnitionJudge(float aDiffTime)
	{

		if (-400.0f <= aDiffTime && aDiffTime <= 400.0f)
		{
			return eIgnitionJudge.Perfect;
		}
		if (-800.0f <= aDiffTime && aDiffTime <= 800.0f)
		{
			
			return eIgnitionJudge.Great;
		}
		if (-1200.0f <= aDiffTime && aDiffTime <= 1200.0f)
		{
			return eIgnitionJudge.Nice;
		}
		return eIgnitionJudge.Miss;

	}

}
