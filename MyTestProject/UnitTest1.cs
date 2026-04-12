using NUnit.Framework;
using Microsoft.Playwright.NUnit;

namespace MyTestProject;

// We use the full global prefix to stop the CS0234 error
[NUnit.Framework.Parallelizable(NUnit.Framework.ParallelizableScope.Self)]
[NUnit.Framework.TestFixture]
public class PlaywrightTests : PageTest
{
    [NUnit.Framework.Test]
    public async Task App_HomePage_ShouldHaveCorrectTitle()
    {
        var baseUrl = Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? "http://localhost:5000";
        await Page.GotoAsync(baseUrl);
        await Expect(Page).ToHaveTitleAsync(new System.Text.RegularExpressions.Regex("Home page"));
    }
}