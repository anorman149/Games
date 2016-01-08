using System;
using UnityEngine;

public class Heart : MonoBehaviour, IItem {
    private int value = 0;

    private Animator animator;

    public void AnimateOnPickup() {
        throw new NotImplementedException();
    }

    public void DisableOnPickup() {
        throw new NotImplementedException();
    }

    public IItem GetItem() {
        throw new NotImplementedException();
    }

    public int GetValue() {
        throw new NotImplementedException();
    }

    public void PickupAction(GameObject gameObject) {
        throw new NotImplementedException();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
