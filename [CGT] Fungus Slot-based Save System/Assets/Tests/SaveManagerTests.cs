using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;
using CGTUnity.Fungus.SaveSystem;
using SaveManager = CGTUnity.Fungus.SaveSystem.SaveManager;
using System.IO;


namespace Tests
{
    public class SaveManagerTests
    {
        string testScenePath = "Prefabs/TestScenes/saveManagerTestScene";
        GameObject testScenePrefab;
        GameObject testScene;
        Flowchart flowchart;
        TransformVariable flowchartTransVar;
        GameSaver gameSaver;
        GameLoader gameLoader;
        SaveManager saveManager;
        SaveReader saveReader;

        Transform firstObj, secondObj, thirdObj, fourthObj;
        IntegerVariable someInt;

        #region SetUp/TearDown
        [SetUp]
        public void SetupScene()
        {
            LoadScene();
            GetReferencesFromScene();
        }

        void LoadScene()
        {
            testScenePrefab = Resources.Load<GameObject>(testScenePath);
            testScene = MonoBehaviour.Instantiate(testScenePrefab);
        }

        void GetReferencesFromScene()
        {
            flowchart = GameObject.FindObjectOfType<Flowchart>();
            flowchartTransVar = flowchart.GetVariable<TransformVariable>("thisTrans");
            gameSaver = GameObject.FindObjectOfType<GameSaver>();
            gameLoader = GameObject.FindObjectOfType<GameLoader>();
            saveManager = GameObject.FindObjectOfType<SaveManager>();
            saveReader = saveManager.SaveReader;
            someInt = flowchart.GetVariable<IntegerVariable>("someInt");
            GetRefsToGameObjects();
        }

        void GetRefsToGameObjects()
        {
            saveManager = GameObject.FindObjectOfType<SaveManager>();
            firstObj = GameObject.Find("firstObj").transform;
            secondObj = GameObject.Find("secondObj").transform;
            thirdObj = GameObject.Find("thirdObj").transform;
            fourthObj = GameObject.Find("fourthObj").transform;
        }

        [TearDown]
        public void ClearScene()
        {
            DestroyAllGameObjects();
        }

        void DestroyAllGameObjects()
        {
            foreach (var gameObject in Object.FindObjectsOfType<GameObject>())
            {
                MonoBehaviour.Destroy(gameObject);
            }
        }

        #endregion

        [UnityTest]
        //[Ignore("")]
        public IEnumerator SaveOverwrittenCorrectlyWithoutUI()
        {
            // Arrange
            int slotNumber = 0;
            int someIntOrig = someInt.Value;
            int someIntNewVal = someIntOrig + 1 * 10;
            string saveDir = Path.Combine(saveManager.SaveDirectory, "saveData_00.save");

            // Act
            saveManager.AddSave(slotNumber, true);
            // Read the save from disk
            var firstSave = saveReader.ReadOneFromDisk(saveDir);
            
            someInt.Value = someIntNewVal;
            yield return new WaitForSeconds(0.5f);

            saveManager.AddSave(slotNumber, true);
            // Read the save again
            var secondSave = saveReader.ReadOneFromDisk(saveDir);

            bool correct = secondSave.LastWritten != firstSave.LastWritten;

            // Assert
            Assert.IsTrue(correct);
        }

        void MoveObjectsAround()
        {
            firstObj.transform.position += Vector3.right * 3;
            secondObj.transform.position += Vector3.down * 3;
            thirdObj.transform.position += Vector3.up * 3;
            fourthObj.transform.position += Vector3.left * 3;
        }
    }
}
