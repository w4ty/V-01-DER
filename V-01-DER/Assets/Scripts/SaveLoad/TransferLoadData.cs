using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferLoadData : MonoBehaviour {

	void Start () {
		if(LoadGame.queueLoad == true)
		{
			this.GetComponent<PlayerStatistics>().shipLVL = LoadGame.shipLvl;
			this.GetComponent<PlayerStatistics>().currentXP = LoadGame.xp;
			this.GetComponent<PlayerStatistics>().perkSelected = LoadGame.perk;
			this.transform.position = LoadGame.pos;
		}
	}
}
