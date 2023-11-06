using DotNetTest.Domain.Exception;

namespace Treebu.Ledger.Domain.Exception;

public class NoFunds : ExceptionBase
{
    // 1 - 10 Excepciones de Cuentas
    public const int NO_FUNDS = 1;
    public const int INVALID_ACCOUNT = 2;

    public NoFunds(int code, string message) : base(code, message) { }
}