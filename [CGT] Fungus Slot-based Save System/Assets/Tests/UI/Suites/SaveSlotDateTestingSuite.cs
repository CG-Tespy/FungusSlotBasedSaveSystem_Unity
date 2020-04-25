using NUnit.Framework;
using CGT.Unity.Fungus.SBSaveSys;
using DateTime = System.DateTime;
using System.Globalization;
using UnityEngine;

namespace CGT_SBSS_Tests
{
    public class SaveSlotDateTesting<TDateDisplayer> : SaveSlotTestingSuite
        where TDateDisplayer: class, IDateFormatHandler, ISlotDateDisplayer, ISlotText
    {
        protected TDateDisplayer dateDisplayer = null;
        protected CultureInfo localCulture = CultureInfo.CurrentUICulture;
        protected DateTime date;
        protected string format;
        protected string expected = "";
        protected GameSaveData saveData = null;

        [Test]
        public virtual void CorrectDateDisplayed()
        {
            // Arrange
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasSaveData(slot);
                slot.SaveData = slot.SaveData; // So the components get updated
            }

            // Act
            foreach (var saveSlot in SaveSlots)
            {
                dateDisplayer = saveSlot.GetComponentInChildren<TDateDisplayer>();

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
        public virtual void DisplayNothingWithoutSaveData()
        {
            // Arrange
            foreach (var slot in SaveSlots)
            {
                EnsureSlotHasSaveData(slot);
                slot.SaveData = nullSaveData; // So the components get updated
            }

            expected = "";

            // Act
            for (int i = 0; i < SaveSlots.Count; i++)
            {
                var saveSlot = SaveSlots[i];
                dateDisplayer = saveSlot.GetComponentInChildren<TDateDisplayer>();
                var actual = dateDisplayer.TextField.text;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}