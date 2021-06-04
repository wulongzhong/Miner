using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBevBase : MonoBehaviour {
    protected virtual void Awake() {

    }

    protected virtual void Start() {
        
    }

    protected virtual void Update() {
        
    }

    public virtual void onShow() {
        gameObject.SetActive(true);
    }
    public virtual void onHide() {
        gameObject.SetActive(false);
    }
}
