using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductionTime", menuName = "Data/ProductionTime", order = 1)]
public class ProductionTime : ScriptableObject {

	[Header("What are the production times of the items?")]
	[Tooltip("index 0 = coffee machine, 1 = kitchen, 2 = trunk, 3 = trash")]
	public float[] productionTimes = new float[4];
	
}
