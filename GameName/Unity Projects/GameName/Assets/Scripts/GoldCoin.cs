using UnityEngine;

public class GoldCoin : MonoBehaviour, IItem {
    private int value = 10;

    public void AnimateOnPickup() {
        AnimationMethods.setAnimationTypeAndValue(Animation.Collide, GetComponent<Animator>(), true);
    }

    public IItem GetItem() {
        return this;
    }

    public int GetValue() {
        return value;
    }

    public void DisableOnPickup() {
        //TODO Disable Object
        GetComponent<Renderer>().enabled = false;

        Destroy(this.gameObject);
    }

    public void PickupAction(GameObject gameObject) {
        if(gameObject.tag.Equals("Player")) {
            //The Player has collided
            //Add the appropriate amount of coins
            GameManager.instance.AddCoins(value);

            //Animate
            AnimateOnPickup();
        }
    }

    void Start () {

    }
	
	void Update () {
	    
	}
}
