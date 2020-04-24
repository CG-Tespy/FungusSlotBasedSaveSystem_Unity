using NUnit.Framework;
using CGTUnity.Fungus.SaveSystem.Experimental;
using CGTUnity.Fungus.SaveSystem;
using TMProText = TMPro.TextMeshProUGUI;

namespace CGT_SBSS_Tests
{
    public class TMProUGUINumberTesting : SaveSlotTestingSuite
    {
        public override string pathToScenePrefab { get; set; } = "ScenePrefabs/TMProSaveSlotTestScene";
        
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
                var numComponent = slot.GetComponentInChildren<TMProSaveSlotNumber>();
                var textField = numComponent.GetComponent<TMProText>();
                var expected = numComponent.Prefix + slotNum + numComponent.Postfix;

                // Assert
                Assert.IsTrue(textField.text == expected);
            }

        }

        
        void EnsureSlotHasNumberComponent(ModularSaveSlot slot)
        {
            var number = slot.GetComponentInChildren<TMProSaveSlotNumber>();
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
