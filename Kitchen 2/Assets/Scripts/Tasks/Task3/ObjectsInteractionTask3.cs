using System;
using UnityEngine;

public class ObjectsInteractionTask3 : MonoBehaviour
{
    [SerializeField] private GameObject _lampRoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnLampsOnOff(_lampRoot.GetComponentsInChildren<Lamp>());
        }
    }

    private void TurnLampsOnOff(Lamp[] lamps)
    {
        for (int i = 0; i < lamps.Length; i++)
        {
            lamps[i].Interact();
        }
    }

}