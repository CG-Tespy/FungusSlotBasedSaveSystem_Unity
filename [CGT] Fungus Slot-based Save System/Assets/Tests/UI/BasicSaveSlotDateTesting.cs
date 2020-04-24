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
    public class BasicSaveSlotDateTesting : SaveSlotTestingSuite
    {
        BasicSaveSlotDate dateDisplayer = null;
        CultureInfo localCulture = CultureInfo.CurrentUICulture;
        DateTime date;
        string format;
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
                dateDisplayer = saveSlot.GetComponentInChildren<BasicSaveSlotDate>();
                format = dateDisplayer.Format;
                saveData = saveSlot.SaveData;
                date = saveData.LastWritten;
                expected = date.ToString(format, localCulture);
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
                dateDisplayer = saveSlot.GetComponentInChildren<BasicSaveSlotDate>();
                var actual = dateDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
