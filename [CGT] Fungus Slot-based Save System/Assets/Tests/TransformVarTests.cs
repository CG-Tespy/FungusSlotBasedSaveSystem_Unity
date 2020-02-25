using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Fungus;
using CGTUnity.Fungus.SaveSystem;
using UnityEngine.SceneManagement;

using SaveManager = CGTUnity.Fungus.SaveSystem.SaveManager;

namespace Tests
{

    public class TransformVarTests
    {
        string testScenePath = "Prefabs/TestScenes/transformVarTestScene";
        GameObject testScenePrefab;
        GameObject testScene;
        Flowchart flowchart;
        TransformVariable flowchartTransVar;
        GameSaver gameSaver;
        GameLoader gameLoader;
        SaveManager saveManager;


        GameObject firstObj, secondObj, thirdObj, fourthObj;

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

            GetRefsToGameObjects();
        }

        void GetRefsToGameObjects()
        {
            firstObj = GameObject.Find("firstObj");
            secondObj = GameObject.Find("secondObj");
            thirdObj = GameObject.Find("thirdObj");
            fourthObj = GameObject.Find("fourthObj");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [Test]
        public void TransformVarSerializedCorrectly()
        {
            // Arrange
            // Create the save data
            TransformVarData save = CreateTransformVarData();

            // Act
            // Try saving it to a json
            string json = JsonUtility.ToJson(save, true);
            // Deserialize from that json
            TransformVarData deserializedSave = JsonUtility.FromJson<TransformVarData>(json);

            // Assert
            // See if both the original and deserialized version have the same data
            bool deserializedCorrectly = save.Equals(deserializedSave);
            Assert.IsTrue(deserializedCorrectly);
        }

        TransformVarData CreateTransformVarData()
        {
            return new TransformVarData(flowchartTransVar.Value);
        }

        [Test]
        public void TransformVarSavedCorrectly()
        {
            // Arrange
            var correctSave = new TransformVarData(flowchartTransVar.Value);
            var gameSave = gameSaver.CreateSave();

            // Act
            var saved = FindDataIn(gameSave);

            // Assert
            bool savedCorrectly = correctSave.Equals(saved);
            Assert.IsTrue(savedCorrectly);
            
        }

        [UnityTest]
        public IEnumerator TransformVarLoadedCorrectly()
        {
            // Arrange
            // Make sure we can see the before and after
            yield return new WaitForSeconds(1f);
            ApplyTransformChangesToObjects();
            yield return new WaitForSeconds(1f);
            var gameSave = gameSaver.CreateSave();

            // Act
            gameLoader.LoadState(gameSave);
            yield return new WaitForSeconds(1f);

            GetRefsToGameObjects(); // The refs we have before this will have become null

            // Check the states
            bool firstTwoObjectsSynced = firstObj.transform.position == secondObj.transform.position
                && firstObj.transform.rotation == secondObj.transform.rotation;
            bool secondTwoObjectsSynced = thirdObj.transform.up == fourthObj.transform.up &&
                thirdObj.transform.right == fourthObj.transform.right &&
                thirdObj.transform.forward == fourthObj.transform.forward;
            bool allObjectsSynced = firstTwoObjectsSynced && secondTwoObjectsSynced;

            // Assert
            Assert.IsTrue(allObjectsSynced);

        }

        void ApplyTransformChangesToObjects()
        {
            firstObj.transform.position = secondObj.transform.position;
            firstObj.transform.rotation = secondObj.transform.rotation;

            thirdObj.transform.up = fourthObj.transform.up;
            thirdObj.transform.right = fourthObj.transform.right;
            thirdObj.transform.forward = fourthObj.transform.forward;
        }

        [Test]
        public void GameSaveDataHasTransformVarData()
        {
            // Arrange
            var gameSave = gameSaver.CreateSave();

            // Act
            TransformVarData dataFound = FindDataIn(gameSave);

            // Assert
            Assert.IsNotNull(dataFound);
        }

        TransformVarData FindDataIn(GameSaveData gameSave)
        {
            TransformVarData dataFound = null;
            string dataType = typeof(TransformVarData).Name;

            foreach (var item in gameSave.Items)
            {
                if (item.DataType == dataType)
                {
                    dataFound = JsonUtility.FromJson<TransformVarData>(item.Data);
                    break;
                }
            }

            return dataFound;
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
    }
}
