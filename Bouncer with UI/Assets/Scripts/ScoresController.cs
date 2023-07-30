using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoresController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textOfRedCylinder;
    [SerializeField] private TextMeshProUGUI _textOfGreenCylinder;
    [SerializeField] private TextMeshProUGUI _textOfYellowCylinder;
    [SerializeField] private TextMeshProUGUI _textOfPlayer;
    
    public int _redCylinderCount;
    public int _greenCylinderCount;
    public int _yellowCylinderCount;
    public int _stepCount;
    
    public static ScoresController Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _textOfRedCylinder.text = _redCylinderCount.ToString();
        _textOfGreenCylinder.text = _greenCylinderCount.ToString();
        _textOfYellowCylinder.text = _yellowCylinderCount.ToString();
        _textOfPlayer.text = _stepCount.ToString();
    }
}