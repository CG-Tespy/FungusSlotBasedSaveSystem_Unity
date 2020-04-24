using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;
using CGTUnity.Fungus.SaveSystem;
using CGTUnity.Fungus.SaveSystem.Experimental;
using System.Linq;
using UnityEngine.UI;
using System.Globalization;
using System;
using TMProText = TMPro.TextMeshProUGUI;

namespace Tests
{
    public class SaveSlotTestingSuite
    {
        public virtual List<ModularSaveSlot> saveSlots { get; set; }
        public virtual string pathToScenePrefab { get; set; } = "ScenePrefabs/SaveSlotTestScene";
        public virtual GameObject scenePrefab { get; set; }
        public virtual GameObject scene { get; set; }
        public virtual GameObject slotHolder { get; set; }
        public virtual GameSaveData[] saveDatas { get; set; }

        public GameSaveData nullSaveData = GameSaveData.Null;

        [SetUp]
        public virtual void SetUp()
        {
            CreateScene();
            GetUIElements();
            SetupSaveDatas();
            AssignSaveDataToSlots();
        }

        protected virtual void CreateScene()
        {
            scenePrefab = Resources.Load<GameObject>(pathToScenePrefab);
            scene = MonoBehaviour.Instantiate<GameObject>(scenePrefab);
        }

        protected virtual void GetUIElements()
        {
            slotHolder = GameObject.Find("SlotHolder");
            var slotArr = slotHolder.GetComponentsInChildren<ModularSaveSlot>();
            saveSlots = new List<ModularSaveSlot>(slotArr);
        }

        protected virtual void AssignSaveDataToSlots()
        {
            for (int i = 0; i < saveSlots.Count; i++)
            {
                var slot = saveSlots[i];
                slot.SaveData = saveDatas[i];
            }
        }

        protected virtual void SetupSaveDatas()
        {
            saveDatas = new GameSaveData[saveSlots.Count];

            for (int i = 0; i < saveSlots.Count; i++)
            {
                var newData = new GameSaveData("test", i + 1);
                newData.Description = "This is the desc of slot number " + (i + 1);
                saveDatas[i] = newData;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            GameObject.Destroy(scene);
        }

        public virtual void EnsureSlotHasSaveData(ModularSaveSlot slot)
        {
            if (slot.SaveData == null)
                throw new System.MissingFieldException(slot.name + " is missing save data!");
        }

    }
}
