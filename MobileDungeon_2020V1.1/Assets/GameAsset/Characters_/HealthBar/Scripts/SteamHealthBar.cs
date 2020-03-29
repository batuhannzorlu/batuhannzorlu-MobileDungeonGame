using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UIHealthAlchemy
{
    //[ExecuteInEditMode]
    public class SteamHealthBar : RectHealhBar
    {
        [SerializeField] private Image glass;
        [SerializeField] private Sprite[] glassSprites;
        public Image crackGlass;
        [SerializeField] private Sprite[] crackSprites;
        [SerializeField] private Material bubblesMat;

        [SerializeField]
        public override float Value
        {
            get
            {
                return base.Value;
            }

            set
            {
                base.Value = value;
                float val = base.Value;
                if (val > 0.25f)
                    glass.sprite = glassSprites[0];
                else
                    glass.sprite = glassSprites[1];

                if (val > 0.75f)
                {
                    crackGlass.color = new Color(1, 1, 1, 0);
                }
                else
                {
                    crackGlass.color = new Color(1, 1, 1, 1);
                    if (val > 0.5f)
                        crackGlass.sprite = crackSprites[0];
                    else
                        crackGlass.sprite = crackSprites[1];
                }
                if (bubblesMat != null)
                {
                    float yScale = bubblesMat.GetTextureScale("_BublesTex").y;
                    bubblesMat.SetTextureScale("_BublesTex", new Vector2(yScale * CurrLine.rect.width / CurrLine.rect.height, yScale));
                    bubblesMat.SetTextureOffset("_BublesTex", new Vector2(-Time.time / 2, 0));
                }
            }
        }
    }
}
