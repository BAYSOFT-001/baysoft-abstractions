// See https://aka.ms/new-console-template for more information
using BAYSOFT.Abstractions.Crosscutting.Extensions;
using BAYSOFT.Abstractions.Crosscutting.Pluralization;
using BAYSOFT.Abstractions.Crosscutting.Pluralization.English;
using System.Net.WebSockets;

var pluralizer = Pluralizer.GetInstance().AddEnglishPluralizer();

Console.WriteLine("Hello, World!");
Console.WriteLine("----");

var word = "orderedProduct";
var wordCase = word.IdentifyCase();

var wordPluralized = pluralizer.Pluralize(word, "en-US");

Console.WriteLine($"{word} - {wordCase} - {wordPluralized}");
Console.WriteLine("----");

var words = word.GetWords();

Console.WriteLine($"Words: {string.Join(", ", words)}");

Console.WriteLine($"Pascal: {word.ToPascalCase()} : {wordPluralized.ToPascalCase()}");
Console.WriteLine($"Camel: {word.ToCamelCase()} : {wordPluralized.ToCamelCase()}");
Console.WriteLine($"Snake: {word.ToSnakeCase()} : {wordPluralized.ToSnakeCase()}");
Console.WriteLine($"Kebab: {word.ToKebabCase()} : {wordPluralized.ToKebabCase()}");
Console.WriteLine($"Constant: {word.ToConstantCase()} : {wordPluralized.ToConstantCase()}");
Console.WriteLine($"Title: {word.ToTitleCase()} : {wordPluralized.ToTitleCase()}");
Console.WriteLine($"Sentence: {word.ToSentenceCase()} : {wordPluralized.ToSentenceCase()}");