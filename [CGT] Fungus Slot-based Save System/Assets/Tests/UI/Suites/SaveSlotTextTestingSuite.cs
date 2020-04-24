using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace CGT_SBSS_Tests
{
    public class SaveSlotTextTestingSuite<TText> : SaveSlotTestingSuite
    {
        public virtual TText TextComponent { get; set; }
    }
}
