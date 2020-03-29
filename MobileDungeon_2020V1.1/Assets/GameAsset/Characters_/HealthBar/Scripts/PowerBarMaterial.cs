using UnityEngine;
using System.Collections;

namespace UIHealthAlchemy
{
    public class PowerBarMaterial : MaterialHealhBar
    {

        public bool isRound = false;

        public float[] valuesLines;

        public GameObject[] gos;

        [SerializeField]
        public override float Value
        {
            get
            {
                return _Value;
            }

            set
            {
                if (_Value != value)
                {
                    base.Value = value;
                    float val = base.Value;
                    int rountNum = Mathf.RoundToInt(_Value * (valuesLines.Length - 1));
                    if (isRound)
                    {
                        val = valuesLines[rountNum];
                    }
                    else
                    {
                        int floor = Mathf.FloorToInt(_Value * (valuesLines.Length - 1));
                        float off = (_Value * (valuesLines.Length - 1) - 1f * floor);
                        val = Mathf.Lerp(valuesLines[floor], valuesLines[floor + 1], off);
                    }
                    mat.SetFloat("_Value", val * (Max - Min) + Min);

                    for (int i = 0; i < Mathf.Min(gos.Length, valuesLines.Length - 1); i++)
                    {
                        gos[i].SetActive(i <= rountNum - 1);
                    }
                }
            }
        }
    }
}
