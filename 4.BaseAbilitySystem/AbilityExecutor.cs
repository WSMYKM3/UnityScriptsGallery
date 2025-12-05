using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

class AbilityExecutor : MonoBehaviour {
    [SerializeField] AbilityData ability;
    [SerializeField] GameObject target;

    public void Execute(GameObject target) {
        foreach (var effect in ability.effects) {
            effect.Execute(gameObject, target);
        }
    }

    //set input to space key here
    void Update() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Execute(target);
        }
    }
}