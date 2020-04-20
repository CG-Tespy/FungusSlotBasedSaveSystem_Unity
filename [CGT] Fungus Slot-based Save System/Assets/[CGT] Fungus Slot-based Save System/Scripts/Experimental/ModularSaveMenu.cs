using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Fungus;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Superclass for the save menus in the system.
    /// </summary>
    public abstract class ModularSaveMenu
    {
        [SerializeField] protected GameLoader gameLoader;
        [SerializeField] protected GameSaver gameSaver;
        [SerializeField] protected ModularSaveManager saveManager;
        [SerializeField] protected SaveSlotManager saveSlotManager;

        protected virtual void Awake()
        {

        }

        void FetchLoaderAndSaverAsNecessary()
        {
            if (gameLoader == null)
                gameLoader = GameObject.FindObjectOfType<GameLoader>();
            if (gameSaver == null)
                gameSaver = GameObject.FindObjectOfType<GameSaver>();
        }
    }
}
