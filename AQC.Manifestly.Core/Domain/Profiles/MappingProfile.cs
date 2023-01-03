namespace AQC.Manifestly.Core.Domain.Profiles
{
    using AQC.Manifestly.Core.Client.Models;
    using AQC.Manifestly.Core.Domain.Entities;
    using AutoMapper;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkflowData, Workflow>();
            CreateMap<RunData, Run>();
            CreateMap<RunStepData, RunStep>();
            CreateMap<UserData, User>();
            CreateMap<RunStepCommentData, RunStepComment>();
        }
    }
}
