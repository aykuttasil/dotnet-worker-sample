## .Net 5 Worker

## Publish

```bash
dotnet publish -c Release
```

## Create Windows Service

```bash
sc create YourWorkerClassName binPath= "PathToThePublishFolder\YourWorkerClassName.exe"
```

## Run Service

```bash
sc.exe start YourWorkerClassName
```

## Sources

- <https://dev.to/fernandosonego/worker-services-with-asp-net-core-18c2>
- <https://medium.com/software-development-turkey/net-core-worker-services-3434a1bf550a>
