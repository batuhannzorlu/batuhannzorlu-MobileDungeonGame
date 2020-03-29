using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealthManager : MonoBehaviour
{
   
    public Slider SliderPrefab;
    public Slider slider;
    public Transform SliderPos;

    void Start()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        slider = Instantiate(SliderPrefab, Vector3.zero, Quaternion.identity) as Slider;
        slider.transform.SetParent(canvas.transform);
        slider.transform.localScale = new Vector3(1, 1, 1);
    }  
    void Update()
    {
        Vector3 _SliderPos = Camera.main.WorldToScreenPoint(SliderPos.position);
        slider.transform.position = _SliderPos;
    }
}
