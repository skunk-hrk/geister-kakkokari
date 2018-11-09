using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

	public const float square1X = 114f;
	public const float square1Y = 114f;
	public const float baseX = -291.1f;
	public const float baseY = -241f;
	public Vector3 GhostScale = new Vector3(89.7f,89.7f,0);
	public GameObject[,] squares = new GameObject[6, 6];

	// 位置計算
	static public Vector3 PositionCalculation(int r, int c){
		float x = BoardScript.baseX + (BoardScript.square1X * r);
		float y = BoardScript.baseY + (BoardScript.square1Y * c);
		return new Vector3 (x,y,0.0f);
	}


	// マス位置設定
	 public void BoardSpuaresInformation(){
		for (int r = 0; r < 6; r++){
			for(int c = 0; c < 6; c++){
				squares [r, c].transform.position = PositionCalculation (r, c);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
