using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public abstract class Singelton<T> : MonoBehaviour where T : Component
    {
        #region VARIABLES

        private static T instance;

        #endregion VARIABLES

        #region PROPERTIES

        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if(instance == null)
                    {
                        var gameObject = new GameObject
                        {
                            hideFlags = HideFlags.HideAndDontSave
                        };
                        instance = gameObject.AddComponent<T>();

                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}