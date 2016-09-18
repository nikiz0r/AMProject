using UnityEngine;

public class ConfigurationScript : MonoBehaviour {

    public static float shoalTriggerPosition = -5;
    public static float shoalAwakeXPosition = -8;
    public static int coinsCollected;
    public static float baseMovement = 1;
    public static float baseSpeed = 7;
    public static int bulletLimit = 3;

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
