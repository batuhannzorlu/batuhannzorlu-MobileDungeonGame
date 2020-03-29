using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIHealthAlchemy
{
    public class BankHealthBar : RectHealhBar
    {
        [SerializeField] private Image topLine;
        [SerializeField] private Sprite[] topLines;
        [SerializeField] private Material bubblesMat;

        public override float Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                base.Value = value;
                if (value < 0.85f)
                    topLine.sprite = topLines[0];
                else
                    topLine.sprite = topLines[1];
                if (bubblesMat != null)
                {
                    float xScale = bubblesMat.GetTextureScale("_BublesTex").x;
                    bubblesMat.SetTextureScale("_BublesTex", new Vector2(xScale, xScale * CurrLine.rect.height / CurrLine.rect.width));
                }
            }
        }
    }
}
