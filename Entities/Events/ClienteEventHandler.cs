using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class ClienteEventHandler :
     INotificationHandler<ClienteRegisterEvent>

    {
        public Task Handle(ClienteRegisterEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }
    }
}