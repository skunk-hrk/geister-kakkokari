using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MatchingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// キャンセルボタン押下
	public void PushCancelButtom(){
		SceneManager.LoadScene ("TitleScene");
	}
}
