using UnityEngine;
using Fungus;

namespace CGTUnity.Fungus.SaveSystem
{
    [EventHandlerInfo("Scene",
                        "Save Data Loaded",
                        "Execute this block when Game Save Data is loaded.")]
    public class SaveDataLoaded : EventHandler
    {
        protected virtual void OnSaveDataLoaded(string key)
        {
            if (this.HasNoKeys || this.HasTheKey(key))
            {
                ExecuteBlock();
                return;
            }
        }

        protected bool HasNoKeys { get { return ProgressMarkerKeys.Length == 0; } }

        [SerializeField] protected string[] ProgressMarkerKeys;

        protected bool HasTheKey(string key)
        {
            return this.ProgressMarkerKeys.Contains(key);
        }

        public static void NotifyEventHandlers(string savePointKey)
        {
            // Execute any SavePointLoaded event handler that has either no keys, or the key passed
            // to this func.
            var eventHandlers = FindObjectsOfType<SaveDataLoaded>();
            for (int i = 0; i < eventHandlers.Length; i++)
            {
                var eventHandler = eventHandlers[i];
                eventHandler.OnSaveDataLoaded(savePointKey);
            }

        }
    }
}