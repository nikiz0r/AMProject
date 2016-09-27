using UnityEngine;

public class ConfigurationScript : MonoBehaviour {

    public static float shoalTriggerPosition = -5, shoalAwakeXPosition = -8, baseMovement = 1, baseSpeed = 7, minSpawnYPosition = -3.3f, maxSpawnYPosition = 3.3f;
    public static int coinsCollected, bulletLimit = 3;

    #region Player
    public static float playerSpeed = 10;
	public static float jumpForce = 300;
	public static float jumpBoost = 40;
    public static float dashForce = 5000;
	public static float speedBulletR = 15;
    public static float speedBulletL = speedBulletR * -1;
    #endregion

    #region Coin
    public static int regularCoinValue = 1;
    public static int superCoinValue = 5;
    #endregion

    #region Shoal
    public static float shoalMovementSpeed = 3;
    public static float shoalDelayTime = 0.8f;
    #endregion
}
