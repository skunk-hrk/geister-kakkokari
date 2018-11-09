using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GhostArrangement : MonoBehaviour {

	// ボード設定値読み込み
	public BoardScript BoardScript;

	// プレイヤーゴースト
	public GameObject[] PGhost = new GameObject[8];

	// 相手ゴースト
	public GameObject[] EGhost = new GameObject[8];

	// 配置完了フラグ
	public bool ArrangementCompleteFlag = false;

	// 選択中かどうか判定
	public bool GhostSelectFlg = false;

	// 選択中のゴースト
	public int GhostSelect;

	[SerializeField]
	GameObject canvas;

	// 敵ゴースト位置設定（ランダム）
	public List<int> RandomGhostCPU(){
		List<int> GhostList = new List<int>();
		int count = 0;
		while(true){
			int redNum = Random.Range (0, 7);
			if(GhostList.Contains(redNum)){
				continue;
			}

			GhostList.Add (redNum);
			count++;
			if(count == 4){
				
				break;
			}
		}
		return GhostList;
	}

	// ゴースト選択
	public void SelectGhost(){
		
	}


	Vector3 test = new Vector3(BoardScript.baseX,BoardScript.baseY,0.0f);

	// Use this for initialization
	void Start () {
		// プレハブ読み込み
		GameObject prefabGB = (GameObject)Resources.Load ("GhostBlue");
		GameObject prefabGR = (GameObject)Resources.Load ("GhostRed");
		GameObject prefabGW = (GameObject)Resources.Load ("GhostWhite");

		// 自軍青ゴースト
		for(int i = 0; i < 4; i++){
			Vector3 pos = BoardScript.PositionCalculation (i + 1,1);
			PGhost [i] = Instantiate (prefabGB, pos, Quaternion.identity);
			PGhost [i].transform.SetParent (canvas.transform,false);
			int _i = i;
			PGhost [i].AddComponent <Button>().onClick.AddListener(() => PushGhostSelect(_i));
			PGhost [i].name = "PlayerBlue" + _i;
		}
		// 自軍赤ゴースト
		for(int i = 0; i < 4; i++){
			Vector3 pos = BoardScript.PositionCalculation (i + 1,0);
			PGhost [i + 4] = Instantiate (prefabGR, pos, Quaternion.identity);
			PGhost [i + 4].transform.SetParent (canvas.transform,false);
			int _i = i + 4;
			PGhost [i + 4].AddComponent <Button>().onClick.AddListener(() => PushGhostSelect(_i));
			PGhost [i + 4].name = "PlayerRed" + _i;
		}

		// CPUゴースト配置位置を取得
		List<int> EGhostList = new List<int> ();
		EGhostList = RandomGhostCPU ();
		for(int test = 0; test < 4; test++){
			//Debug.Log (EGhostList[test]);
		}

		// 敵軍ゴースト
		for(int i = 0; i < 8; i++){
			int col = i;
			int row = 4;
			if(i > 3){
				row = 5;
				col = col - 4;
			}
			if (EGhostList.Contains (i)) {
				Vector3 pos = BoardScript.PositionCalculation (col + 1, row);
				EGhost [i] = Instantiate (prefabGW, pos, Quaternion.Euler(0, 0, 180));
				EGhost [i].transform.SetParent (canvas.transform, false);
				EGhost [i].name = "EnemyRed" + i;
			} else {
				Vector3 pos = BoardScript.PositionCalculation (col + 1,row);
				EGhost [i] = Instantiate (prefabGW, pos, Quaternion.Euler(0, 0, 180));
				EGhost [i].transform.SetParent (canvas.transform,false);
				EGhost [i].name = "EnemyBlue" + i;
			}
		}

		/*for(int i = 0; i < 8; i++){
			Debug.Log (PGhost[i]);
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int selecttest;
	public void PushGhostSelect (int num) {
		Debug.Log (GhostSelectFlg);

		if (GhostSelectFlg) {
			SelectedGhost (num, selecttest);
			//Debug.Log (GhostSelectFlg);
			GhostSelectFlg = false;
		} else {
			GhostSelectFlg = true;
			selecttest = num;
		}
	}

	// 第一ゴースト選択
	public GameObject SetGhost (int num) {
		//Debug.Log (PGhost[num]);
		GhostSelectFlg = true;
		return PGhost[num];
	}

	Button test1;
	// 第二ゴーストと交換
	public void SelectedGhost (int num2, int selectGhost) {
		

		//test1 = PGhost [num2].GetComponent <Button> ();
		//Button test2 = PGhost [selectGhost].GetComponent <Button> ();
		test1 = PGhost [num2].GetComponent <Button> ();
		test1.onClick.RemoveAllListeners();
		test1.onClick.AddListener( () => PushGhostSelect(selectGhost) );

		test1 = PGhost [selectGhost].GetComponent <Button> ();
		test1.onClick.RemoveAllListeners();
		test1.onClick.AddListener( () => PushGhostSelect(num2) );

		//test1 = PGhost [selectGhost].GetComponent <Button> ();
		//test1.RemoveListener (PushGhostSelect(selectGhost));
		GameObject _g = PGhost[selectGhost];
		Vector3 _g_pos = PGhost[selectGhost].transform.position;

		//test2.onClick.AddListener( () => test2.onClick.RemoveAllListeners() );
		PGhost [selectGhost] = PGhost [num2];
		PGhost [num2] = _g;
		PGhost [num2].transform.position =PGhost [selectGhost].transform.position;
		PGhost [selectGhost].transform.position = _g_pos;
		//Debug.Log (test1);
		//Debug.Log (test2);
		//test1.onClick.AddListener(() => PushGhostSelect(num2));
		//test2.onClick.AddListener(() => PushGhostSelect(selectGhost));
		//PGhost [num2].AddComponent <Button>().onClick.AddListener(() => PushGhostSelect(num2));
		//PGhost [selectGhost].AddComponent <Button>().onClick.AddListener(() => PushGhostSelect(selectGhost));
		/*for(int i = 0; i < 8; i++){
			Debug.Log (PGhost[i]);
		}
		**/
		/** 非永続的リスナーは消されてない説濃厚 **/
	}

	public void PushArrangementComplete () {
		ArrangementCompleteFlag = true;
	}

	void BtnAction()
	{
		Debug.Log( "btnAction" );
		this.RemoveBtnAction();
	}


	void RemoveBtnAction()
	{
		//ボタンのイベントをすべて削除する
		test1.onClick.RemoveAllListeners();
	}
}
