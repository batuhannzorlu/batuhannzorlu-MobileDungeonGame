using UnityEngine;
using System.Collections;

namespace UIHealthAlchemy
{
    [ExecuteInEditMode]
    public class MaterialHealhBar : HealthBarLogic
    {

        [SerializeField] protected Material mat;
        protected float _Value;
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
                    _Value = value;
                    if (_Value > 1)
                        _Value = 1;
                    if (_Value < 0)
                        _Value = 0;
                    mat.SetFloat("_Value", _Value * (Max - Min) + Min);
                    this.value = value;
                }
            }
        }
        [Range(0.0f, 1.0f)]
        [SerializeField]
        protected float value;
        [SerializeField] protected float Min = 0;
        [SerializeField] protected float Max = 1;

        void Start()
        {
            Value = value;
        }

        private void Update()
        {
            Value = value;
        }
    }
}
