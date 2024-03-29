﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly ICategoryRepository _repository;
        public GetAllCategoriesQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
