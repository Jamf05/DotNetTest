using DotNetTest.Domain.AggregatesModel.ClientAggregate;
using DotNetTest.Domain.Models;
using FluentValidation;
using MediatR;

namespace DotNetTest.Api.Application.Commands;

public class CreateInvoiceCommand : IRequest<bool>
{
    public DateTime InvoiceDate = DateTime.Now;
    public int ClientId { get; set; }
    public int InvoiceNumber { get; set; }
    public IList<InvoiceCreationDto> DetailsList { get; set; } = null!;
    
    public CreateInvoiceCommand() {}

    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.InvoiceNumber).NotEmpty();
            RuleFor(x => x.DetailsList).NotEmpty();
            RuleForEach(x => x.DetailsList).Must(x => x.Quantity > 0);
        }
    }
}