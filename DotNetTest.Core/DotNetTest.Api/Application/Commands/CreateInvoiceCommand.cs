using FluentValidation;
using MediatR;

namespace DotNetTest.Api.Application.Commands;

public class CreateInvoiceCommand : IRequest<bool>
{
    public DateTime InvoiceDate = DateTime.Now;
    public int ClientId { get; set; }
    public int InvoiceNumber { get; set; }
    public int TotalItems { get; } = 0;
    public decimal Subtotal { get; } = 0.00m;
    public decimal TaxTotal { get; } = 0.00m;
    public decimal Total { get; } = 0.00m;
    
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
            RuleFor(x => x.InvoiceNumber).NotEmpty();
        }
    }
}