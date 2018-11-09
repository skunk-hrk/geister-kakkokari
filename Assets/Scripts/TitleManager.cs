using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class TitleManager : MonoBehaviour {

	public GameObject PlayerDataScript;
	public InputField userNameInput;
	public GameObject InputFieldUserName;
	public GameObject UserName;
	public GameObject RenameButtom;
	public GameObject Err1TextUserName;
	public GameObject Err2TextUserName;
	// ユーザー名上限
	public const int userNameUpLimit = 10;
	// ユーザー名下限
	public const int userNameDownLimit = 0;


	// Use this for initialization
	void Start () {
		bool checkUserNameInput = PlayerDataScript.GetComponent <PlayerDataScript> ().checkUserNameInput;
		if (checkUserNameInput) {
			string username = PlayerDataScript.GetComponent <PlayerDataScript> ().userName;
			UserName.GetComponent<Text> ().text = username;
			RenameButtom.SetActive (true);
		} else {
			InputFieldUserName.SetActive (true);
		}

		int tesNum = 123;
		ConvertNumberIntoSpecialCharacter (tesNum);

	}

	// Update is called once per frame
	void Update () {
		
	}

	// マッチングボタン押下
	public void PushButtomMatching(){
		SceneManager.LoadScene ("MatchingScene");
	}

	public void InputUserName(){
		string InputUserName = userNameInput.GetComponent <InputField> ().text;
		if((InputUserName.Length <= userNameDownLimit) == true){
			ErrMessage (Err1TextUserName, "※名前を入力してください。");
			Err2TextUserName.SetActive (false);
		}else{
			if (Regex.IsMatch (InputUserName, "^[ァ-ヶー]*$") == true) {
				if((InputUserName.Length <= userNameUpLimit) == true){
					PlayerDataScript.GetComponent <PlayerDataScript> ().SaveUserName (InputUserName);
					UserName.GetComponent<Text> ().text = InputUserName;
					InputFieldUserName.SetActive  (false);
					RenameButtom.SetActive (true);
				}else{
					ErrMessage (Err1TextUserName, "※10文字以内で入力してください。");
					Err2TextUserName.SetActive (false);
				}
			} else {
				if((InputUserName.Length <= userNameUpLimit) == true){
					ErrMessage (Err1TextUserName, "※全角カナで入力してください。");
					Err2TextUserName.SetActive (false);
				}else{
					ErrMessage (Err1TextUserName, "※全角カナで入力してください。");
					ErrMessage (Err2TextUserName, "※10文字以内で入力してください。");
				}
			}
		}
	}

	// エラーメッセージを表示する時の関数
	void ErrMessage (GameObject ErrTextPosition, string message){
		ErrTextPosition.SetActive(true);
		ErrTextPosition.GetComponent<Text> ().text = message;
	}

	public void PushButtomRemoveName (){
		PlayerPrefs.DeleteKey("UserName");
		InputFieldUserName.SetActive (true);
	}



	// 数値→ABCDEFGHIJへ変換
	string ConvertNumberIntoSpecialCharacter (int number) {
		
		// Debug.Log (number.ToString().Length);
		string strI = number.ToString();
		char[] array = new char[number.ToString().Length];
		string s;
		//Debug.Log (strI[0]);
		for(int i = 0; i < number.ToString().Length; i++) {

			//Debug.Log ();
			switch(strI[i]) {
			case '0':
				array[i] = 'A';
				break;
			case '1':
				array[i] = 'B';
				break;
			case '2':
				array[i] = 'C';
				break;
			case '3':
				array[i] = 'D';
				break;
			case '4':
				array[i] = 'F';
				break;
			case '5':
				array[i] = 'G';
				break;
			case '6':
				array[i] = 'H';
				break;
			case '7':
				array[i] = 'I';
				break;
			case '8':
				array[i] = 'J';
				break;
			case '9':
				array[i] = 'K';
				break;
			}

		}

		s = new string (array);
		Debug.Log (s);
		return s;
	}

}
