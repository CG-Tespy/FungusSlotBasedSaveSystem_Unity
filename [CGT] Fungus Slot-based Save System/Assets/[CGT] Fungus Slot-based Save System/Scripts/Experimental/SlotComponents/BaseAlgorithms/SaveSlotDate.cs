using UnityEngine;
using System.Globalization;
using DateTime = System.DateTime;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Base class for save slot components displaying mainly the date.
    /// </summary>
    public abstract class SaveSlotDate<TTextField> : SlotText, ISlotDateDisplayer, IDateFormatHandler
        where TTextField : class
    {
        [SerializeField]
        string format = "G";

        public virtual string Format
        {
            get { return format; }
            set
            {
                if (value == null)
                    NullOrEmptyFormatAlert();
                else
                    format = value;
            }
        }

        protected virtual void NullOrEmptyFormatAlert()
        {
            var errorMessage = "Cannot have a null or empty date format!";
            throw new System.ArgumentException(errorMessage);
        }

        public DateTime Date { get; set; }
        protected CultureInfo localCulture = CultureInfo.CurrentUICulture;

        public new TTextField TextField
        {
            get { return base.TextField; }
            set { base.TextField = value; }
        }

        protected virtual void Awake()
        {
            TextField = GetComponent<TTextField>();
        }

        public override void UpdateText()
        {
            UpdateDate();
            string toDisplay = DecideWhatToDisplay();
            base.TextField.text = toDisplay;
        }

        protected virtual void UpdateDate()
        {
            Date = SaveData.LastWritten;
        }

        protected virtual string DecideWhatToDisplay()
        {
            bool invalidDate = Date.Equals(default);

            if (invalidDate)
                return "";
            else
                return Date.ToString(format, localCulture);
        }
    }

}