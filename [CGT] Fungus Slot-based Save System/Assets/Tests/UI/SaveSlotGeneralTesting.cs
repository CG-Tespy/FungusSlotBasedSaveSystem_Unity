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
    public class SaveSlotGeneralTesting : SaveSlotTestingSuite
    {
        
        [Test]
        public void SlotComponentsAreRegistered()
        {
            // Act
            // Execute this test for each save slot in the scene
            bool failed = false;
            foreach (var slot in saveSlots)
            {
                if (!ComponentsAreRegisteredIn(slot))
                {
                    failed = true;
                    break;
                }
            }

            // Assert
            Assert.IsTrue(!failed);
        }

        bool ComponentsAreRegisteredIn(ModularSaveSlot slot)
        {
            var components = GetSaveSlotComponentsFor(slot);
            components.Remove(slot); // GetComponentsInChildren is a bit weird

            foreach (var component in components)
            {
                if (!slot.Subcomponents.Contains(component))
                {
                    Debug.LogError("Components not registered correctly in " + slot.name);
                    return false;
                }
            }

            return true;
        }

        List<SlotComponent> GetSaveSlotComponentsFor(ModularSaveSlot slot)
        {
            var componentArr = slot.GetComponentsInChildren<SlotComponent>();
            var slotComponents = new List<SlotComponent>(componentArr);

            return slotComponents;
        }

    
    }
}
