using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct GeneralStat
{
    public static int MaxHealthError { get { return 500; } }

    [SerializeField] private int _Health;
    [SerializeField] private int _MaxHealth;
    [SerializeField] private int _MovementSpeed;

    //public int Health { get => _Health; set { Mathf.Clamp(_Health, 0, _MaxHealth); } }
    //public int MaxHealth { get => _MaxHealth; set => Mathf.Clamp(_MaxHealth, 0, MaxHealthError); }
    //public int MovementSpeed { get => _MovementSpeed; set { _MovementSpeed = MovementSpeed; } }

    public void SetHealth(int amount)
    {
        _Health = Mathf.Clamp(amount, 0, _MaxHealth);
    }
    public void SetMaxHealth(int amount)
    {
        _MaxHealth = Mathf.Clamp(amount, 0, MaxHealthError);
    }
    public void SetMovementSpeed(int speed)
    {
        _MovementSpeed = speed;
    }




}

[System.Serializable]
public struct CombatStat
{
    [SerializeField] private int _AttackDamage;
    [SerializeField] private int _Resistance;

    public void SetAttackDamage(int damage)
    {
        _AttackDamage = damage;
    }
    public void SetResistance(int resistance)
    {
        _Resistance = resistance;
    }
}



[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour, ISelectable
{
    [SerializeField] private GeneralStat mGeneralStat;
    [SerializeField] private CombatStat mCombatStat;
    protected bool _isSelected;
    public GeneralStat GeneralStat { get { return mGeneralStat; }/* set { mGeneralStat = GeneralStat; }*/ }
    public CombatStat CombatStat { get { return mCombatStat; } }



    #region Interface Implementation

    public void Select()
    {
        _isSelected = true;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    public void Deselect()
    {
        _isSelected = false;
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    #endregion
}
