
# AQC Manifestly Data Utility

This console application is designed for supporting data deserializing from Manifestly's API client and mapping for database sync.


## Environment Variables

To run this project, you will need to add the following environment variables to your appsettings.json file

`AQC_MANIFESTLY_API_KEY`

`AR_SQLDB_CONNECTION`


## Configuration

Application settings is managed within an appsettings.json file stored in the root directory of AQC.Manifestly.Utility.

#### appsettings.json Example:

```JSON
{
  "Serilog": {
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Code, Serilog.Sinks.Console",
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}"
        }
      },
      {
        "Name": "File",
        "Args": {
          "path": "./logs/log.txt",
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}",
          "rollingInterval": "Day",
          "retainedFileCountLimit": "14"
        }
      }
    ]
  },
  "Manifestly": {
    "BaseUrl": "https://api.manifest.ly/api/v1/",
    "ApiKey": "AQC_MANIFESTLY_API_KEY"
  },
  "ConnectionStrings": {
    "SqlDatabase": "Data Source=AR_SQLDB_CONNECTION"
  }
}
```

#### Program.cs then uses this file to configure the application.

```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var dbConnection = configuration.GetConnectionString("SqlDatabase");
```
    
## Features

- Manifestly API Client
- Client Data Mapping to Entity Models
- Bulk SQL Syncs


## Usage/Examples

AQC.Manifestly.Core.Client retrieves and deserilizes data into records.

```csharp
public async Task<ListAllActiveWorkflowsResponse> ListAllActiveWorkflowsByDepartmentIdAsync(int departmentId)
{
    var request = new RestRequest("checklists")
      .AddParameter("department_id", departmentId);

    var response = await _client.ExecuteGetAsync<ListAllActiveWorkflowsResponse>(request);

    if (!response.IsSuccessful)
    {
        _logger.LogError(response.ErrorMessage, response);
    }

    return response.Data!;
}
```

AQC.Manifestly.Core.Domain maps thee recorded data to transfer objects (DTOs).

```csharp
public async Task<List<WorkflowData>> GetWorkflowDataByDepartmentIdAsync(int departmentId)
{
    var data = new List<WorkflowData>();

    var response = await _client.ListAllActiveWorkflowsByDepartmentIdAsync(departmentId);

    if (response != null)
    {
        var workflows = response.Checklists;
        if (workflows != null)
        {
            foreach (var workflow in workflows)
            {
                data.Add(new WorkflowData
                {
                    Id = workflow.Id,
                    Title = workflow.Title,
                    Description = workflow.Description,
                    DepartmentId = workflow.AccountId
                });
            }
        }
        else
        {
            _logger.LogInformation("No {0} data found in: {1}", nameof(workflows), nameof(response));
        }
    }
    else
    {
        _logger.LogError("No data found in: {0}", nameof(response));
    }

    return data;
}
```

These DTOs can then be used to AutoMap data to it's related Entity.

```csharp
var workflowData = await this._dataService.GetWorkflowDataByDepartmentIdAsync(department.Id);

department.Workflows = this._mapper.Map<List<Workflow>>(workflowData);
```

