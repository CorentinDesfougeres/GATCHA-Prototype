using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatUIManager : MonoBehaviour
{
    public static CombatUIManager Current;
    private CombatManager combatManager;
    public void Awake()
    {
        if (Current == null)
        {
            Current = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public UnitBehaviour SelectedUnit;
    public bool isSelectionLocked;

    public void Start()
    {
        combatManager = CombatManager.Current;
        combatManager.PlayerUnitController.OnMoveSelectionStarted += LaunchMoveSelection;
        combatManager.OnUnitEnteredFeild += SetUpUnit;
    }

    public void LaunchCombatUI()
    {

        return ;
    }

    public void OnDisable()
    {
        CombatManager.Current.OnCombatStart -= LaunchCombatUI;
    }

    public void SetUpUnit(UnitBehaviour _unit)
    {
        
    }
    public GameObject ButtonBar;
    public delegate void MoveSelectedHandler(MoveBehaviour move);
    public event MoveSelectedHandler OnMoveSelected;
    public void LaunchMoveSelection(UnitBehaviour _unit)
    {
        Debug.Log("LaunchMoveSelection");
        SelectedUnit = _unit;
        isSelectionLocked = true;
        ButtonBar.SetActive(true);
        //devrait changer les noms / images des boutons pour correspondre à la sélection (ou faire ça dans sa propre fonction automatique ?)
    }
    public void ProcessMoveButtonClick(int _id)
    {
        //OnMoveSelected.Invoke(SelectedUnit.Moves[_id]);
        combatManager.PlayerUnitController.ProcessChoice(SelectedUnit.Moves[_id], SelectedUnit);
        EndMoveSelection();
    }
    public void EndMoveSelection()
    {
        Debug.Log("EndMoveSelection");
        isSelectionLocked = false;
        ButtonBar.SetActive(false);
    }
}
