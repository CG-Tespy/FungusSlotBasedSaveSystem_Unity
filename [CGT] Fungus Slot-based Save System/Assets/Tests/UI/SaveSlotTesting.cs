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

namespace Tests
{
    public class SaveSlotTesting
    {
        List<ModularSaveSlot> saveSlots = null;
        readonly string pathToScenePrefab = "ScenePrefabs/SaveSlotTestScene";
        GameObject scenePrefab = null;
        GameObject scene = null;

        [SetUp]
        public void SetUp()
        {
            CreateScene();
            GetUIElements();
            AssignSaveDataToSlots();
        }

        void CreateScene()
        {
            scenePrefab = Resources.Load<GameObject>(pathToScenePrefab);
            scene = MonoBehaviour.Instantiate<GameObject>(scenePrefab);
        }

        void GetUIElements()
        {
            var slotArr = GameObject.FindObjectsOfType<ModularSaveSlot>();
            saveSlots = new List<ModularSaveSlot>(slotArr);
        }

        void AssignSaveDataToSlots()
        {
            for (int i = 0; i < saveSlots.Count; i++)
            {
                var slot = saveSlots[i];
                GameSaveData newData = new GameSaveData("test", i + 1);
                newData.Description = "This is the desc of slot number " + (i + 1);
                newData.SlotNumber = i + 1;
                slot.SaveData = newData;
            }
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(scene);
        }


        [Test]
        public void SlotComponentsAreRegistered()
        {
            // Act
            // Execute this test for each save slot in the scene
            bool failed = false;
            foreach (var slot in saveSlots)
            {
                if (!ComponentsAreRegisteredIn(slot))
                {
                    failed = true;
                    break;
                }
            }

            // Assert
            Assert.IsTrue(!failed);
        }

        bool ComponentsAreRegisteredIn(ModularSaveSlot slot)
        {
            var components = GetSaveSlotComponentsFor(slot);

            foreach (var component in components)
            {
                if (!slot.Subcomponents.Contains(component))
                {
                    Debug.LogError("Components not registered correctly in " + slot.name);
                    return false;
                }
            }

            return true;
        }


        List<SaveSlotComponent> GetSaveSlotComponentsFor(ModularSaveSlot slot)
        {
            var componentArr = slot.GetComponentsInChildren<SaveSlotComponent>();
            var slotComponents = new List<SaveSlotComponent>(componentArr);

            return slotComponents;
        }

        [Test]
        public void CorrectNumbersDisplayed()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasSaveData(slot);
                EnsureSlotHasNumberComponent(slot);
            }

            // Act
            // Apply this test to each slot
            foreach (var slot in saveSlots)
            {
                int slotNum = slot.SaveData.SlotNumber;
                var numComponent = slot.GetComponentInChildren<BasicSaveSlotNumber>();
                var textField = numComponent.GetComponent<Text>();
                bool correctNumber = textField.text.Contains(slotNum.ToString());

                // Assert
                Assert.IsTrue(correctNumber);
            }

        }

        void EnsureSlotHasSaveData(ModularSaveSlot slot)
        {
            if (slot.SaveData == null)
                throw new System.MissingFieldException(slot.name + " is missing save data!");
        }

        void EnsureSlotHasNumberComponent(ModularSaveSlot slot)
        {
            BasicSaveSlotNumber number = slot.GetComponentInChildren<BasicSaveSlotNumber>();
            if (number == null)
                throw new System.MissingFieldException(slot.name + " is missing a number component!");
        }

        bool CorrectNumberDisplayedFor(ModularSaveSlot slot)
        {
            BasicSaveSlotNumber number = slot.GetComponentInChildren<BasicSaveSlotNumber>();
            throw new System.NotImplementedException();


        }

        


    }
}
