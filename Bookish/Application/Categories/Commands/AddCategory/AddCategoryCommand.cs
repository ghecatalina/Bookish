using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<Category>
    {
        public string CategoryName { get; set; }
    }
}
