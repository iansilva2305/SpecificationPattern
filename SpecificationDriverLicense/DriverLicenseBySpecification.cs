﻿using System;
using System.Linq.Expressions;

namespace SpecificationDriverLicense
{
    public class DriverLicenseBySpecification : ExpressionSpecification<PersonaModel>
    {
        public DriverLicenseBySpecification(int edadParaEvaluar) : base(x => x.Edad > edadParaEvaluar)
        {
        }
    }
}

