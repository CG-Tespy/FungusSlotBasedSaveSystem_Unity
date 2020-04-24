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

namespace CGT_SBSS_Tests
{
    public class SaveSlotNumberTesting : SaveSlotTestingSuite
    {
        [Test]
        public void DisplayNumberWithSaveData()
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
                var expected = numComponent.Prefix + slotNum + numComponent.Postfix;

                // Assert
                Assert.IsTrue(textField.text == expected);
            }

        }

        void EnsureSlotHasNumberComponent(ModularSaveSlot slot)
        {
            BasicSaveSlotNumber number = slot.GetComponentInChildren<BasicSaveSlotNumber>();
            if (number == null)
                throw new System.MissingFieldException(slot.name + " is missing a number component!");
        }

        public void DisplayNumberWithNullSaveData()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasNumberComponent(slot);
                slot.SaveData = GameSaveData.Null;
            }

            // Act
            // Apply this test to each slot
            foreach (var slot in saveSlots)
            {
                var numComponent = slot.GetComponentInChildren<TMProSaveSlotNumber>();
                int slotNum = numComponent.transform.GetSiblingIndex();
                var textField = numComponent.GetComponent<TMProText>();
                var expected = numComponent.Prefix + slotNum + numComponent.Postfix;

                // Assert
                Assert.IsTrue(textField.text == expected);
            }
        }

    }
}
