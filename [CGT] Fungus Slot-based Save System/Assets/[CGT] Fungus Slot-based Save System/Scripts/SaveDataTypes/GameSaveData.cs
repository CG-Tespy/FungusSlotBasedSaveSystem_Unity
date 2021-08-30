﻿using System.Collections.Generic;
using UnityEngine;
using DateTime = System.DateTime;

namespace CGTUnity.Fungus.SaveSystem
{
    /// <summary>
    /// Contains the state of an entire playthrough.
    /// </summary>
    [System.Serializable]
    public class GameSaveData : SaveData
    {
        #region Fields
        [SerializeField] string description = null;
    
        [SerializeField] int slotNumber = -1;

        [SerializeField] DateTime lastWritten;
        [SerializeField] string lastWrittenAsString = "";
        // ^ DateTimes never get properly serialized by Unity's built-in JSON functionality, 
        // hence the need for a string version that'll be used to bring lastWritten to
        // the right value

        [SerializeField] List<SaveDataItem> items = new List<SaveDataItem>();
        [SerializeField] string progressMarkerKey;

        #endregion

        #region Properties

        public virtual string Description
        {
            get                             { return description; }
            set                             { description = value; }
        }

        /// <summary>
        /// The number of the save slot this belongs to.
        /// </summary>
        public virtual int SlotNumber
        {
            get                             { return slotNumber; }
            set                             { slotNumber = value; }
        }

        public virtual System.DateTime LastWritten
        {
            get                             { return lastWritten; }
            protected set                   { lastWritten = value; }
        }

        /// <summary>
        /// Usually contains most of the individual units of save data that make up this object.
        /// </summary>
        public virtual List<SaveDataItem> Items
        {
                                            get { return items; }
        }

        /// <summary>
        /// The key for the ProgressMarker last executed.
        /// </summary>
        public virtual string ProgressMarkerKey
        {
            get                             { return progressMarkerKey; }
            set                             { progressMarkerKey = value; }
        }

        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// Warning: GameSaveDatas without scene names are not safe to load, unless your 
        /// GameLoader is set to handle such cases.
        /// </summary>
        public GameSaveData() 
        {
            description = lastWritten.ToLongDateString();
            Signals.GameSaveCreated.Invoke(this);
        }

        public GameSaveData(GameSaveData other)
        {
            SetFrom(other);
            Signals.GameSaveCreated.Invoke(this);
        }

        public GameSaveData(string sceneName, int slotNumber = -1, 
                            ICollection<SaveDataItem> items = null) : base(sceneName)
        {
            UpdateTime();
            description = lastWritten.ToLongDateString();
            this.slotNumber = slotNumber;
            if (items != null)
                this.items.AddRange(items);
            Signals.GameSaveCreated.Invoke(this);
        }

        #endregion

        public virtual void SetFrom(GameSaveData other)
        {
            base.SetFrom(other as SaveData);
            this.description = other.description;
            this.slotNumber = other.slotNumber;
            this.lastWritten = other.lastWritten;
            this.progressMarkerKey = other.progressMarkerKey;
            this.items.Clear();
            this.items.AddRange(other.items);
        }

        /// <summary>
        /// Updates this data's timestamp for when it was last written to.
        /// </summary>
        public virtual void UpdateTime()
        {
            lastWritten = DateTime.Now;
            lastWrittenAsString = lastWritten.ToString(roundTripFormat);
        }

        protected static string roundTripFormat = "O";
        // ^ To make sure that the date is deserialized correctly regardless of time zone

        /// <summary>
        /// Warning: A GameSaveData with a cleared state is not safe to load, unless your 
        /// GameLoader is coded to handle such.
        /// </summary>
        public override void Clear()
        {
            SceneName = "";
            description = "";
            progressMarkerKey = "";
            slotNumber = -1;
            lastWritten = new System.DateTime();
            items.Clear();
        }

        /// <summary>
        /// Should be called when a GameSaveData is deserialized.
        /// </summary>
        public virtual void OnDeserialize()
        {
            UpdateTimeFromString();
        }

        protected virtual void UpdateTimeFromString()
        {
            if (lastWrittenAsString.Length > 0) // To avoid errors in previous versions of this system
                lastWritten = DateTime.Parse(lastWrittenAsString);
        }

        #endregion
    }
}