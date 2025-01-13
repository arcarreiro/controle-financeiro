﻿namespace ControleFinanceiro.Core.ValueObjects;
using Dapper;
using System.Data;

public class EmailTypeHandler : SqlMapper.TypeHandler<Email>
{

    public override Email? Parse(object value)
    {
        return new Email(value.ToString() ?? throw new ArgumentNullException(nameof(value)));
    }

    public override void SetValue(IDbDataParameter parameter, Email value)
    {
        parameter.Value = value.Endereco;
    }
}

