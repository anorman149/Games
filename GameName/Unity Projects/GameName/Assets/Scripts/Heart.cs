using System;
using UnityEngine;

public class Heart : MonoBehaviour, IItem {
    private int value = 10;

    public void AnimateOnPickup() {
        AnimationMethods.setAnimationTypeAndValue(Animation.Collide, GetComponent<Animator>(), true);
    }

    public void DisableOnPickup() {
        //TODO Disable Object
        GetComponent<Renderer>().enabled = false;

        Destroy(this.gameObject);
    }

    public IItem GetItem() {
        return this;
    }

    public int GetValue() {
        return value;
    }

    public void PickupAction(GameObject gameObject) {
        if(gameObject.tag.Equals("Player")) {
            //The Player has collided
            Player player = gameObject.GetComponent<Player>();

            //Show the addition
            FloatingText.Show(string.Format("+{0}", Convert.ToString(value)), GUIUtils.heartStyle, new FromWorldPointTextPositioner(transform.position, 1f, 50));

            //Add the appropriate amount of Health
            player.AddHealth(value);

            //Animate
            AnimateOnPickup();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
