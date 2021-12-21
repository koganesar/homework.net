using System.Net.Http;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using hm10;
using Microsoft.AspNetCore.Mvc.Testing;

BenchmarkRunner.Run<Benchmarkhm12>();

[MaxColumn]
[MinColumn]
public class  Benchmarkhm12
{
    private readonly WebApplicationFactory<Startup> _csFac = new();
    private readonly HttpClient _csClient;
    private readonly WebApplicationFactory<WebApplicationFs.Startup> _fsFac = new();
    private readonly HttpClient _fsClient;

    public Benchmarkhm12()
    {
        _csClient = _csFac.CreateClient();
        _fsClient = _fsFac.CreateClient();
    }

    private static void SimplePlus(HttpClient client) =>
        client.GetAsync("https://localhost:5001/calculate?expressionString=1+2").GetAwaiter().GetResult();

    [Benchmark]
    public void PlusCs() =>
        SimplePlus(_csClient);

    [Benchmark]
    public void PlusFs() =>
        SimplePlus(_fsClient);

    private static void Expr(HttpClient client) =>
        client.GetAsync("https://localhost:5001/calculate?expressionString=(2+3)/12*7+8*9").GetAwaiter().GetResult();

    [Benchmark]
    public void ExprCs() =>
        Expr(_csClient);

    [Benchmark]
    public void ExprFs() =>
        Expr(_fsClient);
}
