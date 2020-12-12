<<<<<<< HEAD
using UnityEngine;

namespace UnityEditor.TestTools.TestRunner.CommandLineTest
{
    internal class ExitCallbacksDataHolder : ScriptableSingleton<ExitCallbacksDataHolder>
    {
        [SerializeField] 
        public bool AnyTestsExecuted;
        [SerializeField]
        public bool RunFailed;
    }
=======
using UnityEngine;

namespace UnityEditor.TestTools.TestRunner.CommandLineTest
{
    internal class ExitCallbacksDataHolder : ScriptableSingleton<ExitCallbacksDataHolder>
    {
        [SerializeField] 
        public bool AnyTestsExecuted;
        [SerializeField]
        public bool RunFailed;
    }
>>>>>>> c3ca347710ba35b5e2dad3b8aeaab413e2dd1090
}