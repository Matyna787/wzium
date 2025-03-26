using Microsoft.Extensions.Hosting;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services.ApplicationCommands;
using NetCord.Rest;
using System.Data;
using System.IO.Pipelines;

var builder = Host.CreateDefaultBuilder(args)
    .UseDiscordGateway()
    .UseApplicationCommands();

var kubuś = File.ReadAllBytes("kubuś.png");
var kiwuś = File.ReadAllBytes("kiwuś.png");
var gajul = File.ReadAllBytes("gajul.png");
var kotki = File.ReadAllBytes("kotki.png");
var wzium_new = File.ReadAllBytes("wzium_new.png");
var backupowy_pimpek = File.ReadAllBytes("backup'owy pimpek.png");


var host = builder.Build()
    .AddSlashCommand("square", "Square!", (double a) => $"{(a < 0 ? $"({a})" : a.ToString())}² = {a * a}")
    .AddSlashCommand("multiply", "Multiply!", (double a, double b) => $"{a}×{b} = {a * b}")
    .AddSlashCommand("add", "Add!", (double a, double b) => $"{a}+{b} = {a + b}")
    .AddSlashCommand("substract", "Substract!", (double a, double b) => $"{a}-{b} = {a - b}")
    .AddSlashCommand("divide", "Divide!", (double a, double b) => $"{a}/{b} = {a / b}")
    .AddSlashCommand("sqrt", "Square root!", (double a) => $"{a}^{0.5} = {Math.Sqrt(a)}")
    .AddSlashCommand("cube", "Cube!", (double a) => $"{(a < 0 ? $"({a})" : a.ToString())}³ = {a * a * a}")
    .AddSlashCommand("calc", "Calc", (string expr) => new DataTable().Compute(expr, null).ToString())
    .AddSlashCommand("kubuś", "Kubuś!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("kubuś.png", new MemoryStream(kubuś, 0, kubuś.Length))]))
    .AddSlashCommand("kiwuś", "Kiwuś!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("kiwus.png", new MemoryStream(kiwuś, 0, kiwuś.Length))]))
    .AddSlashCommand("gajul", "Gajul!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("gajul.png", new MemoryStream(gajul, 0, gajul.Length))]))
    .AddSlashCommand("kotki", "Kotki!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("kotki.png", new MemoryStream(kotki, 0, kotki.Length))]))
    .AddSlashCommand("wzium", "Wzium!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("wzium_new.png", new MemoryStream(wzium_new, 0, wzium_new.Length))]))
    .AddSlashCommand("backupowy_pimpek", "Backup'owy_pimpek!", () => new InteractionMessageProperties().WithAttachments([new AttachmentProperties("backupowy pimpek.png", new MemoryStream(backupowy_pimpek, 0, backupowy_pimpek.Length))]))
    .UseGatewayEventHandlers();

    await host.RunAsync();
