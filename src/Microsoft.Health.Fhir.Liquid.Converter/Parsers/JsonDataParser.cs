﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using Microsoft.Health.Fhir.Liquid.Converter.Exceptions;
using Microsoft.Health.Fhir.Liquid.Converter.Extensions;
using Microsoft.Health.Fhir.Liquid.Converter.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Health.Fhir.Liquid.Converter.Parsers
{
    public class JsonDataParser : IDataParser
    {
        public object Parse(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new DataParseException(FhirConverterErrorCode.NullOrWhiteSpaceInput, Resources.NullOrWhiteSpaceInput);
            }

            try
            {
                var jObject = JToken.Parse(json);
                var obj = jObject.ToObject();
                return obj;
            }
            catch (Exception ex)
            {
                throw new DataParseException(FhirConverterErrorCode.InputParsingError, string.Format(Resources.InputParsingError, ex.Message), ex);
            }
        }
    }
}