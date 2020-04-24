using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public abstract class TextAbridger<TTextField> : MonoBehaviour
    {
        [Tooltip("Whether or not it does its job each frame.")]
        public bool auto = true;

        [SerializeField]
        [Tooltip("How many characters this allows the text field to have.")]
        [Range(1, int.MaxValue - 100)]
        int charLimit = 150;

        [SerializeField]
        [Tooltip("What is put at the end of the text field to suggest it is abridged.")]
        string cutoffMarker = "...";
        public TTextField TextField { get; protected set; }

        dynamic dTextField { get { return TextField; } }

        public int CharLimit
        {
            get { return charLimit; }
            set
            {
                charLimit = value;
                WarnForCharLimitIssues();
            }
        }

        public string CutoffMarker
        {
            get { return cutoffMarker; }
            set
            {
                if (value == null)
                    cutoffMarker = "";
                else
                    cutoffMarker = value;
            }
        }

        protected virtual void ValidateTextField()
        {
            if (TextField == null)
            {
                string errorMessage = this.name + @"'s TextAbridger component needs a text field to work with!";
                throw new System.MissingFieldException(errorMessage);
            }
        }

        protected virtual void Awake()
        {
            GetTextField();
        }

        protected virtual void GetTextField()
        {
            TextField = GetComponent<TTextField>();
        }

        protected virtual void Update()
        {
            if (!auto)
                return;

            Apply();
        }

        protected virtual void WarnForCharLimitIssues()
        {
            if (CharLimit < CutoffMarker.Length)
                Debug.LogWarning("The char limit being shorter than the cutoff marker may lead to issues!");
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
            return dTextField.text.Length > CharLimit;
        }

        protected virtual void CutDownText()
        {
            string cutText = dTextField.text.Substring(0, CharLimit - CutoffMarker.Length);
            dTextField.text = cutText;
        }

        protected virtual void AddCutoffToText()
        {
            dTextField.text = string.Concat(dTextField.text, CutoffMarker);
        }

    }

}
