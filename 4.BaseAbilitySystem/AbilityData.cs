using System;
using System.Collections.Generic;
using UnityEngine;

//menuName is the path in the create asset menu
[CreateAssetMenu(fileName = "AbilityData", menuName = "ScriptableObjects/AbilityData")]
class AbilityData : ScriptableObject {
    public string label;
    
    //[SerializeReference] is used to serialize polymorphic types
    //it allows storing different subclasses of AbilityEffect in the same list
    [SerializeReference] public List<AbilityEffect> effects;

    void OnEnable() {
        //if label is empty, use the name of the scriptable object
        if (string.IsNullOrEmpty(label)) label = name;
        //initialize effects list if it's null
        if (effects == null) effects = new List<AbilityEffect>();
    }
}


[Serializable]
//here, abstract class means this class cannot be instantiated directly,it can only be inherited by other classes
//so somthing like AbilityEffect effect = new AbilityEffect(); is not allowed, do things like class DamageEffect : AbilityEffect instead
abstract class AbilityEffect {
    //abstract method to be implemented by subclasses
    public abstract void Execute(GameObject caster, GameObject target);
}


//code below are examples subclasses of AbilityEffect that deals damage and knockback

[Serializable]
class DamageEffect : AbilityEffect {
    public int amount;
    //here, override means this method is overriding the abstract method in the base class

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Execute(GameObject caster, GameObject target) {
        target.GetComponent<Health>().ApplyDamage(amount);
        Debug.Log($"{caster.name} dealt {amount} damage to {target.name}");
    }
}

[Serializable]
class KnockbackEffect : AbilityEffect {
    public float force;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Execute(GameObject caster, GameObject target) {
        var dir = (target.transform.position - caster.transform.position).normalized;
        target.GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);
        Debug.Log($"{caster.name} knocked back {target.name} with force {force}");
    }
}

