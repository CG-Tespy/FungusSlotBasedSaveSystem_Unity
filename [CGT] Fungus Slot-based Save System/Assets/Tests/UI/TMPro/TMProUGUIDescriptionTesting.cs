using CGT.Unity.Fungus.SBSaveSys;

namespace CGT_SBSS_Tests
{
    public class TMProUGUIDescriptionTesting : 
        SaveSlotDescriptionTestingSuite<TMProSaveSlotDescription>
    {
        public override string PathToScenePrefab { get; set; } = "ScenePrefabs/TMProSaveSlotTestScene 1";
    }
}
