using UnityEngine;
using System.Collections;

namespace UIHealthAlchemy
{
    public class ChangeSize : MonoBehaviour
    {

        public float delta = 0.05f;
        public float period = 4;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float koef = Mathf.Sin(Time.time * period);
            koef *= koef * koef * koef;
            transform.localScale = ((1 - delta) + delta * koef) * Vector3.one;

        }
    }
}
