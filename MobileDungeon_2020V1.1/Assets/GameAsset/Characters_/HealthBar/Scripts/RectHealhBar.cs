using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIHealthAlchemy
{
    [ExecuteInEditMode]
    public class RectHealhBar : HealthBarLogic
    {

        [SerializeField] private RectTransform FullLine;
        [SerializeField] protected RectTransform CurrLine;
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
                    this.value = value;
                    if (_Value > 1)
                        _Value = 1;
                    if (_Value < 0)
                        _Value = 0;
                    Vector2 size = CurrLine.sizeDelta;
                    if(isHorizontal)
                        size.x = FullLine.rect.width * (_Value * (Max - Min) + Min);
                    else
                        size.y = FullLine.rect.height * (_Value * (Max - Min) + Min);
                    CurrLine.sizeDelta = size;
                }
            }
        }
        [Range(0.0f, 1.0f)]
        [SerializeField]
        protected float value;
        [SerializeField] protected float Min = 0;
        [SerializeField] protected float Max = 1;
        [SerializeField] private bool isHorizontal = true;

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
