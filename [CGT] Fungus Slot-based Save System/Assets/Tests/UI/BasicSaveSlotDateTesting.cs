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
    public class BasicSaveSlotDateTesting : SaveSlotTestingSuite
    {
        SaveSlotDate dateDisplayer = null;
        CultureInfo localCulture = CultureInfo.CurrentCulture;
        DateTime date;
        string formatSpecifier = "F";
        string expected = "";
        GameSaveData saveData = null;

        [Test]
        public void CorrectDateDisplayed()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasSaveData(slot);
                slot.SaveData = slot.SaveData; // So the components get updated
            }

            // Act
            foreach (var saveSlot in saveSlots)
            {
                dateDisplayer = saveSlot.GetComponentInChildren<SaveSlotDate>();
                saveData = saveSlot.SaveData;
                date = saveData.LastWritten;
                expected = date.ToString(formatSpecifier, localCulture);
                var actual = dateDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(actual, expected);
            }

        }

        [Test]
        public void DisplayNothingWithoutSaveData()
        {
            // Arrange
            foreach (var slot in saveSlots)
            {
                EnsureSlotHasSaveData(slot);
                slot.SaveData = nullSaveData; // So the components get updated
            }

            expected = "";

            // Act
            for (int i = 0; i < saveSlots.Count; i++)
            {
                var saveSlot = saveSlots[i];
                dateDisplayer = saveSlot.GetComponentInChildren<SaveSlotDate>();
                var actual = dateDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
