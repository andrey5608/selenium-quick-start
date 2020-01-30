using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

[Binding]
public class ScenarioContextInjectionSteps
{
    private readonly ScenarioContext scenarioContext;

    public ScenarioContextInjectionSteps(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext ?? throw new ArgumentNullException("scenarioContext");
        scenarioContext.Set("this is", "test");
    }
   
    [When(@"I use ScenarioContext.Current")]
    public void WhenIUseContextCurrent()
    {
        Console.WriteLine($"keys:'{string.Join(",", scenarioContext.Keys)}'");
        Console.WriteLine($"values:'{string.Join(",", scenarioContext.Values)}'");
    }
}