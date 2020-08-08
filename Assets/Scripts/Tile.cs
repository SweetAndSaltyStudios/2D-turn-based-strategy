using TMPro;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Tile : MonoBehaviour
    {
        #region VARIABLES

        private SpriteRenderer spriteRenderer;
        private TextMeshPro coordinatesText;
        private Color defaultColor;
        private Color activeColor;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);
            coordinatesText = GetComponentInChildren<TextMeshPro>(true);
        }

        private void Start()
        {
            defaultColor = spriteRenderer.color;
            activeColor = Color.grey;

            coordinatesText.enabled = false;
            coordinatesText.text = gameObject.name;

            if(transform.position.y > 0)
            {
                spriteRenderer.sortingOrder = (int)-(transform.position.y + 2);
            }
        }

        private void OnMouseEnter()
        {
            coordinatesText.enabled = true;
            spriteRenderer.color = activeColor;
        }

        private void OnMouseUp()
        {
            GameManager.Instance.Unit.SetPosition(transform.position);
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = defaultColor;
            coordinatesText.enabled = false;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}

