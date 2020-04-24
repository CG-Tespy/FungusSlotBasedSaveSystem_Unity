using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CGTUnity.Fungus.SaveSystem.Experimental;

namespace CGT_SBSS_Tests
{
    public class SaveSlotDescriptionTestingSuite<TDescriptionDisplayer> : SaveSlotTestingSuite
        where TDescriptionDisplayer: class, ISlotText
    {
        TDescriptionDisplayer descDisplayer = null;
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
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
                var fullDesc = slot.SaveData.Description;
                var descInComponent = descDisplayer.TextField.text;
                var halfDescInComponent = descInComponent.Substring(0, descInComponent.Length / 2);
                // ^ May not always want to display the whole desc in the slot
                Debug.Break();
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
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
                slot.SaveData = nullSaveData; // So the components get updated
            }

            expected = "";

            // Act
            foreach (var slot in saveSlots)
            {
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
                var actual = descDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);

            }
        }
    }
}
