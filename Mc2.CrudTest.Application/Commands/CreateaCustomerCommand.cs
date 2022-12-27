using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands;

public sealed record CreateaCustomerCommand(string firstname, string lastname, DateOnly dateOfBirth, string phoneNumber, string emailAddress, string bankAccountNumber);
