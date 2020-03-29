using UnityEngine;
using System.Collections;

namespace UIHealthAlchemy
{
    public class DemonstrationLogic : MonoBehaviour
    {

        [SerializeField] private GameObject help;
        [SerializeField] private HealthBarLogic[] healthBars;
        [SerializeField] private bool isAutoAnimation = true;
        [SerializeField] private float offset = 0;

        public void OffHelp()
        {
            help.SetActive(false);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying)
                return;

            if (Input.GetKeyDown(KeyCode.P))
                isAutoAnimation = !isAutoAnimation;

            if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
            {
                if(Mathf.FloorToInt(offset / Mathf.PI) % 2 == 0)
                    offset -= Time.deltaTime;
                else
                    offset += Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
            {
                if (Mathf.FloorToInt(offset / Mathf.PI) % 2 == 0)
                    offset += Time.deltaTime;
                else
                    offset -= Time.deltaTime;
            }

            if (isAutoAnimation)
            {
                offset += Time.deltaTime / 3;
            }

            float value = Mathf.Cos(offset) / 2 + 0.5f;
            for (int i = 0; i < healthBars.Length; i++)
            {
                if(healthBars[i] is RectHealhBar)
                    ((RectHealhBar)healthBars[i]).Value = value;
                else
                    healthBars[i].Value = value;// Mathf.Sin(Time.time / 3) / 2 + 0.5f;
            }
        }
    }
}
