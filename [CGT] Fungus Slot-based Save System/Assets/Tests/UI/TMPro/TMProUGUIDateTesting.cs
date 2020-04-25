using CGT.Unity.Fungus.SBSaveSys;

namespace CGT_SBSS_Tests
{
    public class TMProUGUIDateTesting : SaveSlotDateTesting<TMProSaveSlotDate>
    {
        public override string PathToScenePrefab { get; set; } = "ScenePrefabs/TMProSaveSlotTestScene 1";
        /*
        [Test]
        public override void CorrectDateDisplayed()
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
                dateDisplayer = saveSlot.GetComponentInChildren<TMProSaveSlotDate>();
                Debug.Break();
                format = dateDisplayer.Format;
                saveData = saveSlot.SaveData;
                date = saveData.LastWritten;
                expected = date.ToString(format, localCulture);
                var actual = dateDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(actual, expected);
            }

        }
        */
    }
}
