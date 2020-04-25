using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using CGT.Unity.Fungus.SBSaveSys;

namespace CGT_SBSS_Tests
{
    public class SaveSlotTestingSuite
    {
        public virtual List<SaveSlot> SaveSlots { get; set; }
        public virtual string PathToScenePrefab { get; set; } = "ScenePrefabs/SaveSlotTestScene";
        public virtual GameObject ScenePrefab { get; set; }
        public virtual GameObject Scene { get; set; }
        public virtual GameObject SlotHolder { get; set; }
        public virtual GameSaveData[] SaveDatas { get; set; }

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
            ScenePrefab = Resources.Load<GameObject>(PathToScenePrefab);
            Scene = MonoBehaviour.Instantiate<GameObject>(ScenePrefab);
        }

        protected virtual void GetUIElements()
        {
            SlotHolder = GameObject.Find("SlotHolder");
            var slotArr = SlotHolder.GetComponentsInChildren<SaveSlot>();
            SaveSlots = new List<SaveSlot>(slotArr);
        }

        protected virtual void AssignSaveDataToSlots()
        {
            for (int i = 0; i < SaveSlots.Count; i++)
            {
                var slot = SaveSlots[i];
                slot.SaveData = SaveDatas[i];
            }
        }

        protected virtual void SetupSaveDatas()
        {
            SaveDatas = new GameSaveData[SaveSlots.Count];

            for (int i = 0; i < SaveSlots.Count; i++)
            {
                var newData = new GameSaveData("test", i + 1);
                newData.Description = "This is the desc of slot number " + (i + 1);
                SaveDatas[i] = newData;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            GameObject.Destroy(Scene);
        }

        public virtual void EnsureSlotHasSaveData(SaveSlot slot)
        {
            if (slot.SaveData == null)
                throw new System.MissingFieldException(slot.name + " is missing save data!");
        }

    }
}
