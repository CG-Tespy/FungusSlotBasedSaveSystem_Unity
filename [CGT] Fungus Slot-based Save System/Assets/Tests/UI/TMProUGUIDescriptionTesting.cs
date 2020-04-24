using CGTUnity.Fungus.SaveSystem.Experimental;

namespace CGT_SBSS_Tests
{
    public class TMProUGUIDescriptionTesting : 
        SaveSlotDescriptionTestingSuite<TMProSaveSlotDescription>
    {
        public override string pathToScenePrefab { get; set; } = "ScenePrefabs/TMProSaveSlotTestScene";
    }
}
