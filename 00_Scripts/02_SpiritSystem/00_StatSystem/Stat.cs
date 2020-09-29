using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    public bool isDirty;
    public event EventHandler OnModify;

    private int baseValue;
    public void SetBaseValue(int _newValue)
    {
        isDirty = true;
        baseValue = _newValue;
    }

    public int Value
    {
        get
        {
            if (isDirty == false)
            {
                return Value;
            }
            else
            {
                Value = CalculateValue();
                isDirty = false;
                return Value;
            }
        }
        set{}
    }

    public List<StatModifier> StatModifiers;
    public void AddModifier(StatModifier modifier)
    {
        StatModifiers.Add(modifier);
        StatModifiers.Sort(CompareModifierOrder);
        isDirty = true;
        if (OnModify != null)
        {
            OnModify(this, EventArgs.Empty);
        }
    }
    public int CompareModifierOrder(StatModifier modA, StatModifier modB)
    {
        if (modA.Target == modB.Target)
        {
            return modA.Type - modB.Type;
        }
        return modA.Target - modB.Target;
    }
    public bool RemoveModifier(StatModifier modifier)
    {
        if (StatModifiers.Remove(modifier))
        {
            isDirty = true;
            if (OnModify != null)
            {
                OnModify(this, EventArgs.Empty);
            }
            return true;
        }
        return false;
    }
    public int RemoveAllModifierFromSource(object source)
    {
        int _removedCount = 0;

        for (int i = StatModifiers.Count - 1; i >= 0; i--)
        {
            if (StatModifiers[i].Source == source)
            {
                StatModifiers.RemoveAt(i);
                _removedCount++;
            }
        }

        if (_removedCount > 0)
        {
            isDirty = true;
            if (OnModify != null)
            {
                OnModify(this, EventArgs.Empty);
            }
        }

        return _removedCount;
    }

    public int CalculateValue()
    {

        float _effectiveValue = baseValue;

        int _sumPercentAdd = 0;

        for (int i = 0; i < StatModifiers.Count; i++)
        {
            if (StatModifiers[i].Type == StatModifierType.Flat)
            {
                _effectiveValue += StatModifiers[i].Value;
            }
            else if (StatModifiers[i].Type == StatModifierType.PercentAdd)
            {
                _sumPercentAdd += StatModifiers[i].Value;
                if (i + 1 > StatModifiers.Count || StatModifiers[i + 1].Type != StatModifierType.PercentAdd || StatModifiers[i + 1].Target != StatModifierTarget.Value)
                {
                    _effectiveValue *= 1 + _sumPercentAdd/100;
                    _sumPercentAdd = 0;
                }
            }
            else if (StatModifiers[i].Type == StatModifierType.PercentMult)
            {
                _effectiveValue *= 1 + StatModifiers[i].Value/100;
            }
        }
        
        return (int)_effectiveValue;
    }


    public StatInstance(int value = 0)
    {
        StatModifiers = new List<StatModifier>();

        baseValue = value;

        isDirty = true;
    }
}