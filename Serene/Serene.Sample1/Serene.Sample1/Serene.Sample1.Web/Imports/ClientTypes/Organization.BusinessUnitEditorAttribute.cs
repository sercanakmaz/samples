using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serene.Sample1.Organization
{
    public partial class BusinessUnitEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "Serene.Sample1.Organization.BusinessUnitEditor";

        public BusinessUnitEditorAttribute()
            : base(Key)
        {
        }
    }
}

