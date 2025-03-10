﻿using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Projects.Commands.StartProject;

public class StartProjectCommand(int id) : IRequest<ResultViewModel>
{
    public int Id { get; set; } = id;
}