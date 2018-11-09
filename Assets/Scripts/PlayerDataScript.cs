using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataScript : MonoBehaviour {

	public bool checkUserNameInput = false;
	public string userName;
	public int userWinCount;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("UserName")) {
			checkUserNameInput = true;
			LoadUserName ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ユーザーネームを保存する
	public void SaveUserName (string UserName){
		PlayerPrefs.SetString("UserName", UserName);
		checkUserNameInput = true;
	}

	// ユーザーネームを取得する
	public void LoadUserName (){
		userName = PlayerPrefs.GetString("UserName");
	}

	// ユーザー勝利数を保存する
	public void SaveUserWinCount (int UserWinCount){
		PlayerPrefs.SetInt("UserWinCount", UserWinCount);
	}

	// ユーザー勝利数を取得する
	public void LoadUserWinCount (){
		userWinCount = PlayerPrefs.GetInt("UserWinCount");
	}

	// ユーザー敗北数を保存する
	public void SaveUserLoseCount (int UserLoseCount){
		PlayerPrefs.SetInt("UserLoseCount", UserLoseCount);
	}

	// ユーザー敗北数を取得する
	public void LoadUserLoseCount (){
		userWinCount = PlayerPrefs.GetInt("UserLoseCount");
	}
}
