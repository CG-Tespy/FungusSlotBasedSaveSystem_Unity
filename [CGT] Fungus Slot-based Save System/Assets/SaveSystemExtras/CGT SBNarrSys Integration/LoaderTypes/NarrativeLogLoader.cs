using UnityEngine;
using Fungus;
using System.Collections.Generic;

namespace CGTUnity.Fungus.SaveSystem
{
    /// <summary>
    /// Loads the state of one or more NarrativeLogs.
    /// </summary>
    public class NarrativeLogLoader : SaveLoader<NarrativeLogData>
    {
        protected NarrativeLog Log { get { return FungusManager.Instance.NarrativeLog; } }

        public override bool Load(NarrativeLogData logData)
        {
            EnsureTheUIIsThere();
            Log.Clear();
            PopulateLogWithEntries(logData.Entries);
            
            return true;
        }

        void EnsureTheUIIsThere()
        {
            var logUI = GameObject.FindObjectOfType<NarrativeLogEntryUI>();

            if (logUI == null)
            {
                string message =
                @"Cannot load NarrativeLogData without a 
                NarrativeLogUI component in the scene.";
                // Can't load the log without the UI, after all
                throw new System.InvalidOperationException(message);
            }
        }

        void PopulateLogWithEntries(List<NarrativeLogEntry> entries)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                var currentEntry = entries[i];
                Log.AddLine(currentEntry);
            }
        }
    }
}