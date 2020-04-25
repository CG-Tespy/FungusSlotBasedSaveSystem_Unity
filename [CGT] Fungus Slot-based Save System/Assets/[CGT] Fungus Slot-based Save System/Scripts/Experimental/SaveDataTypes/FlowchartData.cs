using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Contains much of the state of a Flowchart.
    /// </summary>
    public class FlowchartData : SaveData
    {
        #region Fields
        [SerializeField] protected string flowchartName;
        [SerializeField] protected List<StringVar> stringVars =         new List<StringVar>();
        [SerializeField] protected List<IntVar> intVars =               new List<IntVar>();
        [SerializeField] protected List<FloatVar> floatVars =           new List<FloatVar>();
        [SerializeField] protected List<BoolVar> boolVars =             new List<BoolVar>();
        [SerializeField] protected List<BlockData> blocks =             new List<BlockData>();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the name of the encoded Flowchart.
        /// </summary>
        public string FlowchartName { get { return flowchartName; } set { flowchartName = value; } }

        /// <summary>
        /// Gets or sets the list of encoded string variables.
        /// </summary>
        public List<StringVar> StringVars { get { return stringVars; } set { stringVars = value; } }

        /// <summary>
        /// Gets or sets the list of encoded integer variables.
        /// </summary>
        public List<IntVar> IntVars { get { return intVars; } set { intVars = value; } }

        /// <summary>
        /// Gets or sets the list of encoded float variables.
        /// </summary>
        public List<FloatVar> FloatVars { get { return floatVars; } set { floatVars = value; } }

        /// <summary>
        /// Gets or sets the list of encoded boolean variables.
        /// </summary>
        public List<BoolVar> BoolVars { get { return boolVars; } set { boolVars = value; } }

        public List<BlockData> Blocks { get { return blocks; } set { blocks = value; } }
        #endregion

        #region Constructors
        public FlowchartData() { }

        public FlowchartData(Flowchart flowchart)
        {
            SetFrom(flowchart);
        }
        #endregion

        #region Public methods
        
        /// <summary>
        /// Makes the FlowchartData instance hold the state of only the passed Flowchart.
        /// </summary>
        public virtual void SetFrom(Flowchart flowchart)
        {
            Clear(); // Get rid of any old state data first

            FlowchartName =                     flowchart.name;
            SetVariablesFrom(flowchart);
            SetBlocksFrom(flowchart);
        }

        /// <summary>
        /// Clears all state this FlowchartData has.
        /// </summary>
        public override void Clear()
        {
            flowchartName =                     string.Empty;
            ClearVariables();
            ClearBlocks();
        }

        #region Static Methods
        public static FlowchartData CreateFrom(Flowchart flowchart)
        {
            return new FlowchartData(flowchart);
        }
        #endregion

        #region Helpers

        protected virtual void ClearVariables()
        {
            stringVars.Clear();
            intVars.Clear();
            floatVars.Clear();
            boolVars.Clear();
        }

        protected virtual void ClearBlocks()
        {
            blocks.Clear();
        }

        protected virtual void SetVariablesFrom(Flowchart flowchart)
        {
            for (int i = 0; i < flowchart.Variables.Count; i++) 
            {
                var variable =                  flowchart.Variables[i];

                var stringVariable =            variable as StringVariable;
                
                if (stringVariable != null)
                {
                    var d  =                    new StringVar();
                    d.Key =                     stringVariable.Key;
                    d.Value =                   stringVariable.Value;
                    StringVars.Add(d);
                }

                // Save int
                var intVariable =               variable as IntegerVariable;
                if (intVariable != null)
                {
                    var d =                     new IntVar();
                    d.Key =                     intVariable.Key;
                    d.Value =                   intVariable.Value;
                    IntVars.Add(d);
                }

                // Save float
                var floatVariable =             variable as FloatVariable;
                if (floatVariable != null)
                {
                    var d =                     new FloatVar();
                    d.Key =                     floatVariable.Key;
                    d.Value =                   floatVariable.Value;
                    FloatVars.Add(d);
                }

                // Save bool
                var boolVariable =              variable as BooleanVariable;
                if (boolVariable != null)
                {
                    var d =                     new BoolVar();
                    d.Key =                     boolVariable.Key;
                    d.Value =                   boolVariable.Value;
                    BoolVars.Add(d);
                }
            }
        
        }

        protected virtual void SetBlocksFrom(Flowchart flowchart)
        {
            // Register data for the blocks the flowchart is executing
            var executingBlocks =               flowchart.GetExecutingBlocks();
            for (int i = 0; i < executingBlocks.Count; i++)
            {
                BlockData newBlockData =        new BlockData(executingBlocks[i]);
                blocks.Add(newBlockData);
            }
        }

        #endregion

        #endregion
    }

}