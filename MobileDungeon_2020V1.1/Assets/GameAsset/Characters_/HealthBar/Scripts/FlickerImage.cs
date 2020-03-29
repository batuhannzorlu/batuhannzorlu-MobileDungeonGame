using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIHealthAlchemy
{
    public class FlickerImage : MonoBehaviour
    {

        [SerializeField] private Image image;
        [SerializeField] private float min = 0;
        [SerializeField] private float max = 1;
        [SerializeField] private float period = 3;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Color col = image.color;
            col.a = min + (max - min) * Mathf.Abs(Mathf.Cos(Time.time * period));
            image.color = col;
        }
    }
}
