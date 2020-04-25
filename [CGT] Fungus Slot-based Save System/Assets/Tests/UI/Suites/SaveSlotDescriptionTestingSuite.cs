using NUnit.Framework;
using CGT.Unity.Fungus.SBSaveSys;

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
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasSaveData(slot);
            }

            // Act
            foreach (var slot in SaveSlots)
            {
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
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
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasSaveData(slot);
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
                slot.SaveData = nullSaveData; // So the components get updated
            }

            expected = "";

            // Act
            foreach (var slot in SaveSlots)
            {
                descDisplayer = slot.GetComponentInChildren<TDescriptionDisplayer>();
                var actual = descDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);

            }
        }
    }
}
