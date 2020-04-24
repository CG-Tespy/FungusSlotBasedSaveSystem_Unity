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
    public class BasicSaveSlotDescriptionTesting : SaveSlotTestingSuite
    {
        SaveSlotDescription descDisplayer = null;
        TextAbridger textAbridger = null;
        string expected = "";

        [Test]
        public void CorrectDescriptionsDisplayed()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasSaveData(slot);
            }

            // Act
            foreach (var slot in saveSlots)
            {
                descDisplayer = slot.GetComponentInChildren<SaveSlotDescription>();
                var fullDesc = slot.SaveData.Description;
                var descInComponent = descDisplayer.TextField.text;
                var halfDescInComponent = descInComponent.Substring(0, descInComponent.Length / 2);
                // ^ May not always want to display the whole desc in the slot

                // Assert
                bool fullDescHasHalfTheDisplayedDesc = fullDesc.Contains(halfDescInComponent);
                Assert.IsTrue(fullDescHasHalfTheDisplayedDesc);

            }

        }

        [Test]
        public void DisplayNothingWithNullSaveData()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasSaveData(slot);
                descDisplayer = slot.GetComponentInChildren<SaveSlotDescription>();
                slot.SaveData = nullSaveData; // So the components get updated
            }

            expected = "";

            // Act
            foreach (var slot in saveSlots)
            {
                descDisplayer = slot.GetComponentInChildren<SaveSlotDescription>();
                var actual = descDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);

            }
        }
    }
}
