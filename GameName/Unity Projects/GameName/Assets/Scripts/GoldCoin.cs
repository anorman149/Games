using UnityEngine;

public class GoldCoin : MonoBehaviour, IItem {
    private int value = 10;

    private Animator animator;
    private Renderer rend;

    public void AnimateOnPickup() {
        AnimationMethods.setAnimationTypeAndValue(Animation.Collide, animator, true);
    }

    public IItem GetItem() {
        return this;
    }

    public int GetValue() {
        return value;
    }

    public void DisableOnPickup() {
        //TODO Disable Object
        rend.enabled = false;

        Destroy(this.gameObject);
    }

    public void PickupAction(GameObject gameObject) {
        if(gameObject.tag.Equals("Player")) {
            //The Player has collided
            Player player = gameObject.GetComponent<Player>();

            //Subtract the appropriate amount of coins
            player.AddCoins(value);

            //Animate
            AnimateOnPickup();
        }
    }

    void Start () {
        animator = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }
	
	void Update () {
	    
	}
}
