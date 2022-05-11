using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQuery : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
