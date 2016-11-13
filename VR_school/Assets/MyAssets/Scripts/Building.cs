using UnityEngine;
using System.Collections;


public class Building : MonoBehaviour,IGvrGazeResponder {

	private Color startColor;
	private Color newColor;
	private GameController gameController;

	void Start () {
		//获取初始的颜色
		startColor = GetComponent<Renderer>().material.color;
		
		//获取Game Controller对象
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log("Cannot find 'GameController' script");
		}

		SetGazedAt (false);
	}


	//当用户注视物体时的主要业务逻辑
	public void SetGazedAt(bool gazedAt) {
		if (gazedAt) {
			TriggerColorToGreen (true);	
			TellMyName (true);
		} else {
			TriggerColorToGreen (false);
			TellMyName (false);
		}
	}

	//颜色改变触发器
	//true，变绿色，false 恢复
	public void TriggerColorToGreen (bool triggered) {
		GetComponent<Renderer> ().material.color = triggered ? Color.green : startColor;
	}

	//说出本对象的名称
	public void	TellMyName (bool asked) {
		if (asked) {
			gameController.showBuildingName (this.name);

		} else {
			Debug.Log ("don‘t tell you");
		}
	}


#region If User focus 
	//
	public void OnGazeEnter(){
		SetGazedAt(true);
	    Debug.Log (name);
	}

	public void OnGazeExit(){
		SetGazedAt (false);
	    Debug.Log ("out");
	}

	public void OnGazeTrigger(){
		Debug.Log ("触发");
	}
#endregion
}
