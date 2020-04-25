using CGT.Unity.Fungus.SBSaveSys;
using NUnit.Framework;

namespace CGT_SBSS_Tests
{
    public class SaveSlotNumberTesting<TNumberDisplayer> : SaveSlotTestingSuite
        where TNumberDisplayer: class, ISlotText, IPrefixHandler, IPostfixHandler
    {
        [Test]
        public virtual void DisplayNumberWithSaveData()
        {
            // Arrange
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasSaveData(slot);
                EnsureSlotHasNumberComponent(slot);
            }

            // Act
            // Apply this test to each slot
            foreach (var slot in SaveSlots)
            {
                int slotNum = slot.SaveData.SlotNumber;
                var numComponent = slot.GetComponentInChildren<TNumberDisplayer>();
                var textField = numComponent.TextField;
                var expected = numComponent.Prefix + slotNum + numComponent.Postfix;

                // Assert
                Assert.IsTrue(textField.text == expected);
            }

        }

        void EnsureSlotHasNumberComponent(SaveSlot slot)
        {
            var number = slot.GetComponentInChildren<TNumberDisplayer>();
            if (number == null)
                throw new System.MissingFieldException(slot.name + " is missing a number component!");
        }

        [Test]
        public virtual void DisplayNumberWithNullSaveData()
        {
            // Arrange
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasNumberComponent(slot);
                slot.SaveData = GameSaveData.Null;
            }

            // Act
            // Apply this test to each slot
            foreach (var slot in SaveSlots)
            {
                var numComponent = slot.GetComponentInChildren<TNumberDisplayer>();
                int slotNum = slot.transform.GetSiblingIndex();
                var textField = numComponent.TextField;
                var expected = numComponent.Prefix + slotNum + numComponent.Postfix;

                // Assert
                Assert.IsTrue(textField.text == expected);
            }
        }

    }
}
