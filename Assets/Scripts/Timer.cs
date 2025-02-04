using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private float _time;
    [HideInInspector] public float _currentTime { get; private set; }
    void Start()
    {    
        DOTween.To(OnUpdate, 0, 1, _time).SetEase(Ease.Linear);
    }

    void OnUpdate(float deltaTime)
    {
        _currentTime = deltaTime;
        _bar.fillAmount = deltaTime;
    }
}
