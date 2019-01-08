using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstationManager : MonoBehaviour {

	[Header("All the items that the workstations can produce")]
	public List<ItemType> coffeeMachine;
	public List<ItemType> kitchen;
	public List<ItemType> trunk;
	public List<ItemType> trashCan;
}
