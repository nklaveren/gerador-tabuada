var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

app.MapPost("/files", async (FilesRequest files) =>
{
    var proccessItem = new MultiplicationTable(new WriteFile());
    var results = await Task.WhenAll(files.Ids.Select(id=>proccessItem.Proccess(id)));
    return Results.Ok(results);
});

app.UseCors();
app.Run();
 