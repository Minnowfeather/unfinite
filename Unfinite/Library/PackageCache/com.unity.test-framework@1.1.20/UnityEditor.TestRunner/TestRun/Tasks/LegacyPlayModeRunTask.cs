<<<<<<< HEAD
using System.Collections;
using System.Linq;
using UnityEngine.TestTools.TestRunner;

namespace UnityEditor.TestTools.TestRunner.TestRun.Tasks
{
    internal class LegacyPlayModeRunTask : TestTaskBase
    {
        public LegacyPlayModeRunTask() : base(true)
        {
            
        }
        public override IEnumerator Execute(TestJobData testJobData)
        {
            var settings = PlaymodeTestsControllerSettings.CreateRunnerSettings(testJobData.executionSettings.filters.Select(filter => filter.ToRuntimeTestRunnerFilter(testJobData.executionSettings.runSynchronously)).ToArray());
            var launcher = new PlaymodeLauncher(settings);
            
            launcher.Run();

            while (PlaymodeLauncher.IsRunning)
            {
                yield return null;
            }
        }
    }
=======
using System.Collections;
using System.Linq;
using UnityEngine.TestTools.TestRunner;

namespace UnityEditor.TestTools.TestRunner.TestRun.Tasks
{
    internal class LegacyPlayModeRunTask : TestTaskBase
    {
        public LegacyPlayModeRunTask() : base(true)
        {
            
        }
        public override IEnumerator Execute(TestJobData testJobData)
        {
            var settings = PlaymodeTestsControllerSettings.CreateRunnerSettings(testJobData.executionSettings.filters.Select(filter => filter.ToRuntimeTestRunnerFilter(testJobData.executionSettings.runSynchronously)).ToArray());
            var launcher = new PlaymodeLauncher(settings);
            
            launcher.Run();

            while (PlaymodeLauncher.IsRunning)
            {
                yield return null;
            }
        }
    }
>>>>>>> c3ca347710ba35b5e2dad3b8aeaab413e2dd1090
}