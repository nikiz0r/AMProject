using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private BossShotControl bossShCt;
    //private Slider bossSlider;
    void Start()
    {
        bossShCt = (BossShotControl)FindObjectOfType(typeof(BossShotControl));
        //bossSlider = (Slider)FindObjectOfType(typeof(Slider));
    }
    void Update(){
        IsVisible();
    }
	
	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "enemy1":
			Destroy (col.gameObject);
            Destroy(this.gameObject);
            break;
        case "Boss":
            bossShCt.bossHp -= 1;
            //bossSlider.value -= 1;
            Destroy(this.gameObject);
            break;
        }
	}

    void IsVisible(){
        if (!GetComponent<Renderer>().isVisible)
            Destroy(this.gameObject);
    }
}
