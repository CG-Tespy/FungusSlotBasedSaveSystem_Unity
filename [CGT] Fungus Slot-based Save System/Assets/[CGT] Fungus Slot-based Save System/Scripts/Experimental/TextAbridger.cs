using UnityEngine;
using UnityEngine.UI;
using TMProText = TMPro.TextMeshProUGUI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    
    /// <summary>
    /// Abridges the contents of Unity Text or TextMeshPro UGUI components
    /// based on user input.
    /// </summary>
    public class TextAbridger : MonoBehaviour
    {
        [Tooltip("Whether or not this does its job every frame.")]
        public bool applyOnUpdate = false;
        [Tooltip("How many characters this allows the text field to have.")]
        [Range(1, int.MaxValue - 100)]
        public int charLimit = 100;
        [Tooltip("What is put at the end of the text field to suggest it is abridged.")]
        public string cutoffMarker = "...";
        public dynamic TextField { get; protected set; }

        protected virtual void Awake()
        {
            GetTextField();
        }

        protected virtual void GetTextField()
        {
            TextField = GetComponent<Text>();
            if (TextField == null)
                TextField = GetComponent<TMProText>();
        }

        protected virtual void ValidateTextField()
        {
            if (TextField == null)
            {
                string errorMessage = this.name + @"'s TextAbridger component needs a Unity UI Text or TextMeshPro UGUI
component!";
                throw new System.MissingFieldException(errorMessage);
            }
        }

        protected virtual void Update()
        {
            if (!applyOnUpdate)
                return;

            Apply();
        }

        /// <summary>
        /// Abridges the text field's contents if necessary.
        /// </summary>
        public virtual void Apply()
        {
            if (TextNeedsToBeAbridged())
            {
                CutDownText();
                AddCutoffToText();
            }
        }

        protected virtual bool TextNeedsToBeAbridged()
        {
            return TextField.text.Length > charLimit;
        }

        protected virtual void CutDownText()
        {
            string cutText = TextField.text.Substring(0, charLimit - cutoffMarker.Length);
            TextField.text = cutText;
        }

        protected virtual void AddCutoffToText()
        {
            TextField.text = string.Concat(TextField.text, cutoffMarker);
        }

    }

}