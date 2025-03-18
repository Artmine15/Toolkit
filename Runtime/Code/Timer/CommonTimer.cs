
namespace Artmine15.Toolkit
{
    public class CommonTimer : Timer
    {
        protected override void DoOnTimeLimitExceeded()
        {
            Stop();
        }
    }
}
