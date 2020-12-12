<<<<<<< HEAD
namespace UnityEditor.TestTools.TestRunner.Api
{
    /// <summary>
    /// An extended version of the <see cref="ICallbacks"/>, which get invoked if the test run fails due to a build error or if any <see cref="UnityEngine.TestTools.IPrebuildSetup"/> has a failure.
    /// </summary
    public interface IErrorCallbacks : ICallbacks
    {
        /// <param name="message">The error message detailing the reason for the run to fail.</param>
        void OnError(string message);
    }
}
=======
namespace UnityEditor.TestTools.TestRunner.Api
{
    /// <summary>
    /// An extended version of the <see cref="ICallbacks"/>, which get invoked if the test run fails due to a build error or if any <see cref="UnityEngine.TestTools.IPrebuildSetup"/> has a failure.
    /// </summary
    public interface IErrorCallbacks : ICallbacks
    {
        /// <param name="message">The error message detailing the reason for the run to fail.</param>
        void OnError(string message);
    }
}
>>>>>>> c3ca347710ba35b5e2dad3b8aeaab413e2dd1090
