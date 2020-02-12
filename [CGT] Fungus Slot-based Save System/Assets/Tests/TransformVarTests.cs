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
        TransformVariable transVar;
        GameSaver gameSaver;
        GameLoader gameLoader;
        SaveManager saveManager;

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
            transVar = GameObject.FindObjectOfType<TransformVariable>();
            gameSaver = GameObject.FindObjectOfType<GameSaver>();
            gameLoader = GameObject.FindObjectOfType<GameLoader>();
            saveManager = GameObject.FindObjectOfType<SaveManager>();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [Test]
        public void TransformVarSerializedCorrectly()
        {
            // Arrange
            // Create the save data
            TransformVarData save = new TransformVarData(transVar.Value);

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

        [Test]
        public void TransformVarSavedCorrectly()
        {
            // Arrange
            var correctSave = new TransformVarData(flowchart.transform);
            var gameSave = gameSaver.CreateSave();

            // Act
            var saved = FindDataIn(gameSave);

            // Assert
            bool savedCorrectly = correctSave.Equals(saved);
            Assert.IsTrue(savedCorrectly);
            
        }

        [Test]
        [Ignore("wait")]
        public void TransformVarLoadedCorrectly()
        {

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
