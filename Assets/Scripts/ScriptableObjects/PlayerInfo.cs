using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PlayerInfo")]
public class PlayerInfo : ScriptableObject {

    public int money;
	public int rocketIteration;
    public int rocketSize;
    public float startingFuel;
    public float fuelConsumption;
    public int fruitNumber;
    public int fruitQuality;
}
