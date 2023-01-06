namespace AQC.Manifestly.Core.Domain.Extensions
{
    using AQC.Manifestly.Core.Client.Contracts;
    using AQC.Manifestly.Core.Client.Models;
    using AQC.Manifestly.Core.Domain.Contracts.Extensions;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ManifestlyClientDataExtensions : IManifestlyClientDataExtensions
    {
        private readonly ILogger<ManifestlyClientDataExtensions> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly IManifestlyClient _client;

        public ManifestlyClientDataExtensions(ILogger<ManifestlyClientDataExtensions> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

            var scope = _serviceProvider.CreateScope();

            _client = scope.ServiceProvider.GetRequiredService<IManifestlyClient>();

        }

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

        public async Task<List<UserData>> GetUserDataByDepartmentIdAsync(int departmentId)
        {
            var data = new List<UserData>();

            var response = await _client.ListAllUsersByDepartmentIdAsync(departmentId);

            if (response != null)
            {
                var users = response.Users;
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        data.Add(new UserData
                        {
                            Id = user.Id,
                            Email = user.Email,
                            Name = user.Name,
                            SimpleDisplayName = user.SimpleDisplayName,
                            Username = user.Username,
                        });
                    }
                }
                else
                {
                    _logger.LogInformation("No {0} data found in: {1}", nameof(users), nameof(response));
                }
            }
            else
            {
                _logger.LogError("No data found in: {0}", nameof(response));
            }

            return data;
        }

        public async Task<List<RunData>> GetRunDataByWorkflowIdAsync(int workflowId)
        {
            var data = new List<RunData>();

            var responseBase = await _client.ListAllRunsByWorkflowIdAsync(workflowId);

            if (responseBase != null)
            {
                if (responseBase.Meta != null)
                {
                    for (int currentPage = responseBase.Meta.CurrentPage; currentPage <= responseBase.Meta.TotalPages; currentPage++)
                    {
                        var response = await _client.ListAllRunsByWorkflowIdAsync(workflowId, currentPage);

                        var runs = response.Runs;
                        if (runs != null)
                        {
                            foreach (var run in runs)
                            {
                                data.Add(new RunData
                                {
                                    Id = run.Id,
                                    Title = run.Title,
                                    DetailedTitle = run.DetailedTitle,
                                    Description = run.Description,
                                    PercentCompleted = run.PercentCompleted,
                                    Summary = run.Summary,
                                    StartedAt = run.StartedAt,
                                    CompletedAt = run.CompletedAt,
                                    LateAt = run.LateAt,
                                    State = run.State,
                                    ArchiveUrl = run.ArchiveUrl,
                                    WorkflowId = workflowId,
                                });
                            }
                        }
                        else
                        {
                            _logger.LogInformation("No {0} data found in: {1}", nameof(runs), nameof(response));
                        }
                    }
                }
                else
                {
                    _logger.LogInformation("No {0} data found in: {1}", nameof(responseBase.Meta), nameof(responseBase));
                }
            }
            else
            {
                _logger.LogError("No data found in: {0}", nameof(responseBase));
            }

            return data;
        }

        public async Task<List<RunStepData>> GetRunStepDataByRunIdAsync(int runId)
        {
            var data = new List<RunStepData>();

            var response = await _client.ListAllRunStepsByRunIdAsync(runId);

            if (response != null)
            {
                var runSteps = response.RunSteps;
                if (runSteps != null)
                {
                    foreach (var runStep in runSteps)
                    {
                        var runStepItem = new RunStepData();

                        runStepItem.Id = runStep.Id;
                        runStepItem.RunId = runStep.RunId;

                        if (runStep.UserId != null && runStep.User != null)
                        {
                            runStepItem.UserId = runStep.UserId;
                            runStepItem.User = new UserData
                            {
                                Id = runStep.User!.Id,
                                Email = runStep.User.Email,
                                Name = runStep.User.Name,
                                SimpleDisplayName = runStep.User.SimpleDisplayName,
                                Username = runStep.User.Username,
                            };
                        }

                        runStepItem.Title = runStep.Title;
                        runStepItem.Skipped = runStep.Skipped;
                        runStepItem.CompletedAt = runStep.CompletedAt;
                        runStepItem.LateAt = runStep.LateAt;

                        if (runStep.Comments != null)
                        {
                            var runStepComments = new List<RunStepCommentData>();

                            foreach (var runStepComment in runStep.Comments)
                            {
                                runStepComments.Add(new RunStepCommentData
                                {
                                    Id = runStepComment.Id,
                                    CreatedAt = runStepComment.CreatedAt,
                                    CommentWithLinks = runStepComment.CommentWithLinks,
                                    UpdatedAt = runStepComment.UpdatedAt,
                                    Identifier = runStepComment.Identifier,
                                });
                            }

                            runStepItem.Comments = runStepComments;
                        }

                        data.Add(runStepItem);
                    }
                }
                else
                {
                    _logger.LogInformation("No {0} data found in: {1}", nameof(runSteps), nameof(response));
                }
            }
            else
            {
                _logger.LogError("No data found in: {0}", nameof(response));
            }

            return data;
        }
    }
}
