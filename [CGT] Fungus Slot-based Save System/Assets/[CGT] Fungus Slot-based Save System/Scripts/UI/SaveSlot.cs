using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using CGTUnity.Fungus.SaveSystem;


namespace CGTUnity.Fungus.SaveSystem
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("Slot-Based Save System/UI/Save Slot")]
    public class SaveSlot : MonoBehaviour
    {
        #region Fields
        [Tooltip("Displays the number for this slot.")]
        [SerializeField] Text numDisplay =                      null;
        [Tooltip("Displays the description for this slot.")]
        [SerializeField] Text descDisplay =                     null;
        [Tooltip("Displays the date that the slot was last saved to.")]
        [SerializeField] Text dateDisplay = null;
        protected Button clickReceiver =                        null;
        protected GameSaveData saveData =                       null;
        int number; // Cached to avoid too much casting

        #endregion

        #region Properties
        #region UI Elements
        public RectTransform rectTransform                      { get; private set; }
        

        #endregion
        
        /// <summary>
        /// Defines which slot this is in the Save Menu. First, second, etc.
        /// </summary>
        public virtual int Number                               
        { 
            get                                                 { return number; } 
            protected set
            {
                number =                                        value;
                numDisplay.text =                               "Save #" + number.ToString();
            } 
        }

        public virtual string Description
        {
            get                                                 { return descDisplay.text; }
            protected set                                       { descDisplay.text = value; }
        }

        
        public virtual string TimeLastSavedTo
        {
            get 
            {
                if (SaveData != null)
                {
                    CultureInfo currentLocale = CultureInfo.CurrentCulture;
                    return SaveData.LastWritten.ToString("f", currentLocale);
                }
                else
                    return string.Empty;
            }
        }

        public virtual GameSaveData SaveData
        {
            get                                                 { return saveData; }
            set 
            {
                if (value == null)
                {
                    string message =                            
                    @"Cannot assign null GameSaveData to a Save Slot. If you want to 
                    clear the slot, call its Clear() method instead.";
                    Debug.LogWarning(message);
                    return;
                }
                
                saveData =                                     value;
                UpdateDisplays();
                Signals.SaveSlotUpdated.Invoke(this, value);
            }
        }
        #endregion

        #region Methods
        protected virtual void Awake()
        {
            rectTransform =                                     GetComponent<RectTransform>();
            Number =                                            rectTransform.GetSiblingIndex();
            clickReceiver =                                         GetComponent<Button>();
            clickReceiver.onClick.AddListener(OnClick);
            UpdateDisplays();
        }

        protected virtual void OnDestroy()
        {
            clickReceiver.onClick.RemoveListener(OnClick);
        }

        public virtual void Clear()
        {
            saveData =                                         null;
            UpdateDisplays();
            Signals.SaveSlotUpdated.Invoke(this, SaveData);
        }

        /// <summary>
        /// Updates the UI elements in this SaveSlot based on the save data (or lack thereof) it holds.
        /// </summary>
        protected virtual void UpdateDisplays()
        {
            string newDesc =                                        null;

            if (saveData != null)
                newDesc = saveData.Description;
                
            else
                newDesc = "<No Save Data>";
            
            Description =                                           newDesc;
            dateDisplay.text = TimeLastSavedTo;

        }

        protected virtual void OnClick()
        {
            Signals.SaveSlotClicked.Invoke(this);
        }

        #endregion
    }
}