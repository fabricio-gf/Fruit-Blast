using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unlocks", menuName = "Unlocks")]
public class Unlocks : ScriptableObject {

	public int rocketSizeIndex;
    public int[] rocketSizeUnlocks;
	public int[] rocketSizePrices;

	public int startingFuelIndex;
    public float[] startingFuelUnlocks;
	public int[] startingFuelPrices;
    
	public int fuelConsumptionIndex;
	public float[] fuelConsumptionUnlocks;
	public int[] fuelConsumptionPrices;

	public int fruitNumberIndex;
    public int[] fruitNumberUnlocks;
	public int[] fruitNumberPrices;

	public int fruitQualityIndex;
    public int[] fruitQualityUnlocks;
	public int[] fruitQualityPrices;
}
