using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace MyTestProject;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class PlaywrightTests : PageTest
{
    [Test, Category("Smoke")]
    public async Task App_HomePage_ShouldHaveCorrectTitle()
    {
        // 1. Get the URL from the environment variable (for Docker) 
        // or default to localhost (for local testing)
        var baseUrl = Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? "http://localhost:5153";

        // 2. Navigate to the app
        await Page.GotoAsync(baseUrl);

        // 3. Assert the title
        await Expect(Page).ToHaveTitleAsync(new System.Text.RegularExpressions.Regex("Home page"));
    }

    [Test, Category("Critical")]
    public async Task App_PrivacyPage_ShouldHaveCorrectTitle()
    {
        // 1. Get the URL from the environment variable (for Docker) 
        // or default to localhost (for local testing)
        var baseUrl = Environment.GetEnvironmentVariable("TEST_BASE_URL") ?? "http://localhost:5153";

        // 2. Navigate to the app
        await Page.GotoAsync(baseUrl);

        // 3. Click the "Privacy" link in the header
        await Page.GetByRole(AriaRole.Link, new() { Name = "Privacy" }).First.ClickAsync();


        // 4. Assert the title
        await Expect(Page).ToHaveTitleAsync(new System.Text.RegularExpressions.Regex("Privacy Policy"));
    }
}