<<<<<<< HEAD
using UnityEditor.TestTools.TestRunner.Api;

namespace UnityEditor.TestTools.TestRunner
{
    class PlayerLauncherTestRunSettings : ITestRunSettings
    {
        public bool buildOnly { set; get; }

        public string buildOnlyLocationPath { set; get; }

        public void Dispose()
        {
        }

        void ITestRunSettings.Apply()
        {
        }
    }
=======
using UnityEditor.TestTools.TestRunner.Api;

namespace UnityEditor.TestTools.TestRunner
{
    class PlayerLauncherTestRunSettings : ITestRunSettings
    {
        public bool buildOnly { set; get; }

        public string buildOnlyLocationPath { set; get; }

        public void Dispose()
        {
        }

        void ITestRunSettings.Apply()
        {
        }
    }
>>>>>>> c3ca347710ba35b5e2dad3b8aeaab413e2dd1090
}