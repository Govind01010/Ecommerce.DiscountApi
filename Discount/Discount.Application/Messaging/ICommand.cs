using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discount.Domain.Shared;
using MediatR;

namespace Discount.Application.Messaging
{
    public interface ICommand:IRequest<Result>
    {

    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
