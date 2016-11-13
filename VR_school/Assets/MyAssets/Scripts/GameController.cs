using UnityEngine;
using UnityEngine.UI;//引入GUI
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public Text buildingName;

	void Start () {
	   
	}

	public void showBuildingName(string name){
		buildingName.text =  name;
	}

}
